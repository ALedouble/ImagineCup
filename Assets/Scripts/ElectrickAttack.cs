using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrickAttack : MonoBehaviour {

	private bool stickDownLast;
	private int lifeEnnemy; 
	
	// Use this for initialization
	void Start () {
		lifeEnnemy = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("electricChoc") > 0.5)
		{
		
			if(!stickDownLast)
			{
				lifeEnnemy += 1;
				Destroy (GameObject.FindWithTag("EnnemiTouche"));
			}
		
			if(stickDownLast){
				stickDownLast = false;
			}
		}
	}
}
