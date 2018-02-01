using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrickAttack : MonoBehaviour {

	public List<AiBasic> ennemyLifeList;
	public GameObject electrickPrefab;


	private bool stickDownLast;
	private GameObject electrickParticle;

	
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
						Vector3 particlePosition = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z);
						electrickParticle = (GameObject)Instantiate(electrickPrefab, particlePosition, transform.rotation);
						electrickParticle.transform.parent = transform;
						stickDownLast = true;
						ParticleSystem parts = electrickParticle.GetComponent<ParticleSystem> ();
						float totalduration = parts.duration + parts.startLifetime;
						Destroy (electrickParticle, totalduration);
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

