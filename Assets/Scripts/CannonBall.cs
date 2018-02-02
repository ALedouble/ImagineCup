using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	public GameObject explosionPrefab;
	Rigidbody rb;
	public GameObject boat;
	private float timer = 0.25f;
	private float freezeTimer = 0f;
	private float moveVertical;
	private GameObject explosionBomb;
	public bool shoot;
	
	
	// Use this for initialization
	void Start () {
		moveVertical = Input.GetAxis ("Vertical"); /// Devant
		Vector3 forwredv3 = Camera.main.transform.forward;     
		Vector3 forwredv3fixed = new Vector3 (0, 5, 0);
		
		rb = GetComponent<Rigidbody>();
	
		rb.velocity = Camera.main.transform.forward * 140;
		}
		

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime; 
		
		if (timer < 0){
			rb.AddForce( -transform.up * 2000f);
			rb.useGravity = true;
		}
		else
		{
			rb.useGravity = false;
		}
		
		freezeTimer += Time.deltaTime;
		
		if (freezeTimer < 0.05f)
		{
			rb.constraints = RigidbodyConstraints.FreezePositionY;
		}
		else
		{
			rb.AddForce( -transform.up * 200f);
			rb.constraints = RigidbodyConstraints.None;
		}
	}


	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Sol_desert") {
			explosionBomb =  (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
			ParticleSystem parts = explosionBomb.GetComponent<ParticleSystem> ();
			float totalduration = parts.duration + parts.startLifetime;
			Destroy (explosionBomb, totalduration);
		}
		
		if (collision.gameObject.name == "Convoi") {
			explosionBomb =  (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
			ParticleSystem parts = explosionBomb.GetComponent<ParticleSystem> ();
			float totalduration = parts.duration + parts.startLifetime;
			Destroy (explosionBomb, totalduration);
			shoot = true;
		}
	}
}
