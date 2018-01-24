using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	
	public GameObject prefab;
	private float InstantiationTimer = 1f;
	
	void Start() {

	}
	
	void Update(){
		if (Input.GetAxis("electricChoc") < -0.5)
		{
			InstantiationTimer -= Time.deltaTime;
			if (InstantiationTimer <= 0)
			{
				GameObject CannonBalls = Instantiate(prefab) as GameObject;
				prefab.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
				InstantiationTimer = 1f;
			}
		}
	}
	

}
	