using UnityEngine;
using System.Collections;

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

	private int cooldown;
	private float elevation;
	private Rigidbody myRigidbody;
	private bool nitro;
	private float distanceGround;
	private Vector3 moveInput;
	private Vector3 moveVelocity;
	private RaycastHit hit;
	private Camera mainCamera;
	private int BatteringNumber;
	private float resultHeight;
	

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
		BatteringRam ();
		IsGrounded();



		

		float moveVertical = Input.GetAxis ("Vertical"); /// Devant
		float moveHorizontal = Input.GetAxis ("Horizontal"); /// Sur les 
		float rotateVertical = Input.GetAxis ("RVertical"); /// Devant
		float rotateHorizontal = Input.GetAxis ("RHorizontal"); /// Sur les côtés

		/// Code de déplacement

		Vector3 forwredv3 = transform.forward;     
		Vector3 forwredv3fixed = new Vector3 (forwredv3.x, 0, forwredv3.z);
		moveInput = forwredv3fixed * Input.GetAxis ("Vertical");
		moveVelocity = moveInput * moveSpeed;

		/// Nitro
        if ((moveVertical >= 0.5f))           
        {
            nitro = true;
        }
        else
        {
            nitro = false;
        }

        if (Input.GetButton("Nitro") && nitro == true && moveSpeed < 90)
        {
            Camera.main.fieldOfView += 0.2f;
            moveSpeed += 1;
        }

		if (nitro == false && moveSpeed > 60) 
		{
			Camera.main.fieldOfView -= 0.2f;
			moveSpeed -= 1;
		}

		if (moveVertical <= -0.5f && moveSpeed > 10){
			moveSpeed -= 3;
		}

		if (moveVertical >= -0.5f && moveSpeed < 60){
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
            transform.Rotate(Vector3.up, Input.GetAxis("RHorizontal") * 2.1f);
			transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

	void BatteringRam()
	{
		if (Input.GetButton("BatteringRam") && BatteringNumber == 0)
		{
			BatteringRamInstance = (GameObject)Instantiate(batteringPrefab, transform.position, Quaternion.identity);
			BatteringRamInstance.transform.parent = transform;
			BatteringRamInstance.transform.localPosition = new Vector3(-0.432f, 5.333f, 2.414f);
			BatteringRamInstance.transform.rotation = transform.rotation;
			BatteringNumber += 1;
		}	

		if (GameObject.Find ("Bélier(Clone)") && Input.GetButtonUp("BatteringRam")) 
		{
			Destroy(BatteringRamInstance);
		}

		if (!GameObject.Find ("Bélier(Clone)") && BatteringNumber == 1) 
		{
			BatteringNumber -= 1;
		}
	}

	void IdleRotation()
    {
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
			elevation = Vector3.Distance (height, hit.collider.gameObject.transform.position);
			Debug.DrawRay(middleBoat, -transform.up, Color.blue);
			
			resultHeight = hit.distance;
		}

		if (resultHeight > 0.7)
		{
			transform.GetComponent<Rigidbody>().AddForce(0, -6000f, 0);
		}
	}

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }


	
	IEnumerator cooldownStrafe()
	{
		yield return new WaitForSeconds (0f);
		cooldown = 0;
	}

}