using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	Rigidbody rb;
	public GameObject boat;
	private float timer = 4f;
	private float freezeTimer = 0f;
	private float moveVertical;
	
	
	// Use this for initialization
	void Start () {
		moveVertical = Input.GetAxis ("Vertical"); /// Devant
		Vector3 forwredv3 = Camera.main.transform.forward;     
		Vector3 forwredv3fixed = new Vector3 (0, 5, 0);
		
		rb = GetComponent<Rigidbody>();
		
		
		if (moveVertical > 0)
		{
			rb.velocity = forwredv3 * 40 * moveVertical;
		}
		
		if (moveVertical == 0)
		{
			rb.velocity = forwredv3 * 40;
		}
		
		

	}
	
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime; 
		
		if (timer < 0){
			rb.AddForce( -transform.up * 200f);
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
}
