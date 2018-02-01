using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrickAttack : MonoBehaviour {

	public AiBasic ennemyLife;
	private bool stickDownLast;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("electricChoc") > 0.5)
		{
		
			if(!stickDownLast)
			{
				if (ennemyLife.attach == false) {
					ennemyLife.life -= 1;
				}
			}
		
			if(stickDownLast){
				stickDownLast = false;
			}
		}
	}
}
