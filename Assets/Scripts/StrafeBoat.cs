using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeBoat : MonoBehaviour {

	public GameObject boatController;
	public float TimerCooldownBegin;
	public float TimerCooldownEnd;

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
	
		print (strafing);
		
		if (Input.GetButton ("Strafe1") && strafing == false)
		{
			StartCoroutine(CooldownBegin());
			transform.position += transform.right * 0.4f;
		}
		
		
		if (Input.GetButton ("Strafe2") && strafing == false)
		{
			StartCoroutine(CooldownBegin());
			transform.position -= transform.right * 0.4f;
		}
		
		
	}
	
	IEnumerator	CooldownBegin()
	{
		yield return new WaitForSeconds(TimerCooldownBegin);
		strafing = true;
		StartCoroutine(CooldownEnd());
	}
	
	IEnumerator	CooldownEnd()
	{
		yield return new WaitForSeconds(TimerCooldownEnd);
		strafing = false;
	}
}
