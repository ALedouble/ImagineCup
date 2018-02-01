using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour {

	public int instanceCount = 3;
	// Use this for initialization

	public GameObject[] lootObjects;// objects which can be dropped as loot
	private Rigidbody rb;
	
	void Start(){
		for (int i = 0; i < instanceCount; ++i) {
			int lootNumber = Random.Range(0, 1);
			GameObject loot = (GameObject)Instantiate(lootObjects[lootNumber], transform.position, Quaternion.EulerRotation(-90, 0, 0));
		}
	}
		
	void Update(){

		
	}
		
}

