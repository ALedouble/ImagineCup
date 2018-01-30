using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	
	public GameObject prefab;
	public GameObject cannonLaucher;
	private float InstantiationTimer = 1f;
	private bool stickDownLast;
	
	
	void Start() {

	}
	
	void Update(){
		if (Input.GetAxisRaw("electricChoc") < -0.5)
		{
				if(!stickDownLast){
				
					GameObject CannonBalls = Instantiate(prefab) as GameObject;
					prefab.transform.position = new Vector3 (cannonLaucher.transform.position.x, cannonLaucher.transform.position.y + 0.8f, cannonLaucher.transform.position.z);
					InstantiationTimer = 1f;
					stickDownLast = true;
				}
			}
			else 
			{
				stickDownLast = false;
				prefab.transform.position = new Vector3 (cannonLaucher.transform.position.x, cannonLaucher.transform.position.y + 0.8f, cannonLaucher.transform.position.z);
			}
		}
	}
	


	