using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToLoot : MonoBehaviour {

	public GameObject loot;
	private Rigidbody rb;
	private float timeGravity = 1f;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		float speed = 7;
		rb.isKinematic = false;
		Vector3 force = -transform.up * 5;
		force = new Vector3(force .x, 0.5f, force .z);
		rb.AddForce(force * speed );
		Physics.IgnoreCollision(loot.GetComponent<Collider>(), GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		timeGravity -= Time.deltaTime;
		
		if ( timeGravity > 0 )
		{
		}
		
		if ( timeGravity <= 0 )
		{
			rb.constraints = RigidbodyConstraints.FreezeRotationX;
			rb.constraints = RigidbodyConstraints.FreezeRotationZ; 
			rb.velocity = -Vector3.up * 10; 
		}
	}
}
