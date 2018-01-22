using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeDetection : MonoBehaviour {

	public float speed;

	RaycastHit hit;
	private float distance;
	private float distance2;
	private float result;
	private float result2;
	private float differentResult;
	


	void Start(){
	}

	void Update(){
		Vector3 slopeDetector = new Vector3 (0, transform.position.y, 0);

		Vector3 frontBoat = new Vector3 (transform.position.x, transform.position.y, transform.position.z+1f);
		Vector3 behindBoat = new Vector3 (transform.position.x, transform.position.y, transform.position.z-1f);

		if (Physics.Raycast(frontBoat, Vector3.down, out hit, 700000))
		{
			distance = Vector3.Distance (slopeDetector, hit.collider.gameObject.transform.position);
			Debug.DrawRay(frontBoat, -transform.up, Color.red);

			result = hit.distance;
		}

		if (Physics.Raycast(behindBoat, Vector3.down, out hit, 700000))
		{
			distance2 = Vector3.Distance (slopeDetector, hit.collider.gameObject.transform.position);
			Debug.DrawRay(behindBoat, -transform.up, Color.blue);

			result2 = hit.distance;
		}

		differentResult = result - result2;
		Debug.Log(differentResult);
		
		Vector3 beginRotation = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

		
		if (differentResult < -0.4f)
		{
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)), Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 8)) , 0.2f);
			Debug.Log("true");
		}
		
		if (differentResult < -0.8f)
		{
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)), Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 12)) , 0.2f);
			Debug.Log("true");
		}
		
		if (differentResult < -1f)
		{
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)), Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 17)) , 0.2f);
			Debug.Log("true");
		}
		
		
		if (differentResult >= -0.4f)
		{
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)), Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0)) , 0.2f);
			Debug.Log("true");
		}
		



		
	}
}








	

//		Vector3 originSlope1 = new Vector3 (transform.position.x, transform.position.y+5f, transform.position.z + 1);
//		Vector3 originSlope2 = new Vector3 (transform.position.x, transform.position.y + 5f, transform.position.z - 1);
//		Vector3 slopeDetector = new Vector3 (0, transform.position.y, 0);
//
//		float distanceToGround = 0;
//
//		if (Physics.Raycast(originSlope1, -transform.up, out hit, 400f))
//		{
//			distance = Vector3.Distance (slopeDetector, hit.collider.gameObject.transform.position);
//
//			Debug.Log (hit.transform.name);
//		}
//
//		Debug.DrawRay(originSlope1, -transform.up, Color.green);
//
//		
//		if (Physics.Raycast(originSlope2, -transform.up, out hit, 400f))
//		{
//			distance2 = Vector3.Distance (slopeDetector, hit.collider.gameObject.transform.position);
//
//			Debug.Log (hit.transform.name);
//		}
//
//		Debug.DrawRay(originSlope2, -transform.up, Color.red);
//
//		result = distance2 - distance;
//		Debug.Log (result);
//
//		if (result != 0 && groundCheck == false)
//		{
//			groundCheck = true;
//		}
//
//		if (groundCheck == true)
//		{
//			transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)), Quaternion.Euler(new Vector3 (-15, transform.eulerAngles.y, transform.eulerAngles.z)) , Time.time * 0.3f);
//		}
//
//		if (hit.transform.name == "Plane")
//		{
//			transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)), Quaternion.Euler(new Vector3 (0, transform.eulerAngles.y, transform.eulerAngles.z)) , Time.time * 0.3f);
//		}
		