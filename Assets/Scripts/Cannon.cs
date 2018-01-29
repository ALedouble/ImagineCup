using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	
	public GameObject prefab;
	public GameObject cannonLaucher;
	private float InstantiationTimer = 1f;
	
	
	void Start() {

	}
	
	void Update(){
		if (Input.GetAxisRaw("electricChoc") < -0.5)
		{
			InstantiationTimer -= Time.deltaTime;
			if (InstantiationTimer <= 0)
			{
				GameObject CannonBalls = Instantiate(prefab) as GameObject;
				prefab.transform.position = new Vector3 (cannonLaucher.transform.position.x, cannonLaucher.transform.position.y, cannonLaucher.transform.position.z);
				InstantiationTimer = 1f;
			}
		}
	}
	

}
	