using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrickAttack : MonoBehaviour {

	public List<AiBasic> ennemyLifeList;
	public GameObject electrickPrefab;
	public AiBasic ennemy;
	public AudioClip clip;
	AudioSource audio;


	private bool stickDownLast;
	private GameObject electrickParticle;

	
	// Use this for initialization
	void Start () {
	audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
			for (int i = 0; i < ennemyLifeList.Count; i++) {
				
				
			if(ennemyLifeList[i] != null)
			{
				if (Input.GetAxis("electricChoc") > 0.5)
				{
					if(!stickDownLast){
						audio.PlayOneShot(clip, 1F);
						Vector3 particlePosition = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z);
						electrickParticle = (GameObject)Instantiate(electrickPrefab, particlePosition, transform.rotation);
						electrickParticle.transform.parent = transform;
						ParticleSystem parts = electrickParticle.GetComponent<ParticleSystem> ();
						float totalduration = parts.duration + parts.startLifetime;
						Destroy (electrickParticle, totalduration);
						stickDownLast = true;
						if (ennemyLifeList[0].attach == true)
						{
							ennemyLifeList[0].life -= 1;
						}
						
						if (ennemyLifeList[1].attach == true)
						{
							ennemyLifeList[1].life -= 1;
						}
						
						if (ennemyLifeList[2].attach == true)
						{
							ennemyLifeList[2].life -= 1;
						}
						
						if (ennemyLifeList[3].attach == true)
						{
							ennemyLifeList[3].life -= 1;
						}
						
						if (ennemyLifeList[4].attach == true)
						{
							ennemyLifeList[4].life -= 1;
						}
						
						if (ennemyLifeList[5].attach == true)
						{
							ennemyLifeList[5].life -= 1;
						}
						
						if (ennemyLifeList[6].attach == true)
						{
							ennemyLifeList[6].life -= 1;
						}
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

