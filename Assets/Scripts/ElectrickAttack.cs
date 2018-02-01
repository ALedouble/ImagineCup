using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrickAttack : MonoBehaviour {

	public List<AiBasic> ennemyLifeList;
	private bool stickDownLast;
	

	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
			for (int i = 0; i < ennemyLifeList.Count; i++) {
				
				
			if(ennemyLifeList[i] != null)
			{
				if (Input.GetAxis("electricChoc") > 0.5)
				{
					if(!stickDownLast){
						ennemyLifeList[i].life -= 1;
						stickDownLast = true;
					}
				}
				else 
				{
					stickDownLast = false;
				}
			}
		}
	}
}

