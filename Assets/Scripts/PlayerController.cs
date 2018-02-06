using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform weaponPosition;
    public bool useController;
    public float force;
    public bool elevator;
	public GameObject batteringPrefab;
	public GameObject BatteringRamInstance;
	public SlopeDetection sloping;
	public GameObject meshBoat;
	public GameObject desert;
	public float moveVertical; 
	public GameObject dustInstance;
	public AiBasic aiScript;

	private float moveHorizontal;
	private int cooldown;
	private float elevation;
	private Rigidbody myRigidbody;
	private bool nitro;
	private float distanceGround;
	private Vector3 moveInput;
	private Vector3 moveStrafe;
	public Vector3 moveVelocity;
	private RaycastHit hit;
	private Camera mainCamera;
	private int BatteringNumber;
	private float resultHeight;
	private GameObject dustPrefab;
	private bool dust;
	

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
		BatteringNumber = 0;
		cooldown = 0;		
    }

    void Update()
    {
		UseController ();
		IdleRotation ();
		IsGrounded();
		isDead ();

		moveVertical = Input.GetAxis ("Vertical"); /// Devant
		moveHorizontal = Input.GetAxis ("Horizontal"); /// Sur les 
		float rotateVertical = Input.GetAxis ("RVertical"); /// Devant
		float rotateHorizontal = Input.GetAxis ("RHorizontal"); /// Sur les côtés

		/// Code de déplacement

		Vector3 forwredv3 = transform.forward;     
		Vector3 forwredv3fixed = new Vector3 (forwredv3.x, 0, forwredv3.z);
		moveInput = forwredv3fixed * Input.GetAxis ("Vertical");
		moveStrafe = transform.right * 0.5f * Input.GetAxis("Horizontal");
		moveVelocity = (moveInput + moveStrafe) * moveSpeed;

		/// Nitro
		if (moveVertical >= 0.5 && moveSpeed > 40 && Camera.main.fieldOfView < 90)           
        {
        	StartCoroutine(Acceleration());
			Camera.main.fieldOfView += 0.3f;
			
        }
        
		if (moveVertical <= 0.5 && moveSpeed > 60 && Camera.main.fieldOfView > 60)           
		{
			Camera.main.fieldOfView -= 0.5f;
			
		}
		else if (Input.GetButton("Nitro") && moveSpeed < 90)
		{
			moveSpeed += 1;
		}
        

			
		if ((moveVertical > 0.5f || moveVertical < -0.5f) && dust == false) {
			Vector3 particlePosition = new Vector3 (transform.position.x, transform.position.y + 5f, transform.position.z);
			dustPrefab = (GameObject)Instantiate (dustInstance, particlePosition, transform.rotation);
			dustPrefab.transform.parent = transform;
			dust = true;
		}

		if (dustPrefab != null) 
		{
			if ((moveVertical == 0 || moveVertical == 0)) {
				ParticleSystem parts = dustPrefab.GetComponent<ParticleSystem> ();
				float totalduration = parts.duration + parts.startLifetime;
				Destroy (dustPrefab, totalduration);
				dust = false;
			}
		}

		if (moveVertical < 0.5 && moveSpeed > 30)           
		{
			StartCoroutine(Decelerate());
		}
       

		if (Input.GetButton("Nitro") && nitro == false && moveSpeed > 60) 
		{
//			Camera.main.fieldOfView -= 0.2f;
			moveSpeed -= 1;
		}

		if (moveVertical <= -0.5f && moveSpeed > 30){
			moveSpeed -= 0.15f;
		}

		if (moveVertical >= -0.5f && moveSpeed < 30){
			moveSpeed += 3;
		}
    }

    void UseController()
    {
        if (!useController)
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLenght;

            if (groundPlane.Raycast(cameraRay, out rayLenght))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }

        if (useController)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("RHorizontal") * 2.6f);
			transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
	void IdleRotation()
    {
    
		float rotateHorizontal = Input.GetAxis ("RHorizontal");
		if (transform.position.y < 0.3)
		{
			elevator = true;
		}
		
		if (transform.position.y > 0.6)
		{
			elevator = false;
		}
		


			float rotz = Mathf.PingPong (Time.time * 4, 20);
		
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotz - 10);			


		
    }

	void IsGrounded()
	{

		Vector3 middleBoat = new Vector3 (meshBoat.transform.position.x, meshBoat.transform.position.y, meshBoat.transform.position.z);
		Vector3 height = new Vector3 (0, transform.position.y, 0);

		if (Physics.Raycast(middleBoat, Vector3.down, out hit, 700000))
		{
			elevation = Vector3.Distance (height, transform.position);
			Debug.DrawRay(middleBoat, -transform.up, Color.blue);
			
			resultHeight = hit.distance;
		}

		if (resultHeight > 4f)
		{
			transform.GetComponent<Rigidbody>().AddForce(0, -30000f, 0);
		}
		if (resultHeight < 1f)
		{
			transform.GetComponent<Rigidbody>().AddForce(0, 0, 0);
		}
	}

    void FixedUpdate()
    {
       myRigidbody.velocity = moveVelocity;
    }


	
	IEnumerator Acceleration()
	{
		moveSpeed += 0.15f;
		yield return new WaitForSeconds (4f);
	}
	
	IEnumerator Decelerate()
	{
		moveSpeed -= 0.15f;
		yield return new WaitForSeconds (4f);
	}

	void isDead()
	{
		if (aiScript.playerDead == true) {
			Destroy (this.gameObject);
		}
	}

}