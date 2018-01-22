using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteringRam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider myTrigger) 
	{
		if(myTrigger.gameObject.tag == "Ennemi")
		{
			Destroy(myTrigger.gameObject);
		}

	}
}