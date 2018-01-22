using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeBoat : MonoBehaviour {

	public GameObject boatController;

	private Vector3 startPos;
	private Vector3 endPos;
	private float distance = 10f;
	private float lerpTime = 0.5f;
	private float currentLerpTime = 0;
	private bool strafing = false;
	Rigidbody myRb;
	
	
	// Use this for initialization
	
	void Start () {
		myRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton ("Strafe1"))
		{
			transform.right += Vector3.right * 5;
		}
		
		
		
	}
}
