using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrickAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("electricChoc") > 0.5){
			Destroy (GameObject.FindWithTag("EnnemiTouche"));
		}
	}
}
