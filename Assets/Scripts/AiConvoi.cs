using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NUnit.Framework.Internal.Filters;

public class AiConvoi : MonoBehaviour {

	NavMeshAgent agent;
	[SerializeField] Transform player;
	int multplier = 1;
	float range = 30;
	public int lifeConvoi = 10;
	public CannonBall ballScript;
	public GameObject destroyPrefab;
	private GameObject destroyInt;
	
	public int instanceCount = 3;
	// Use this for initialization
	
	public GameObject[] lootObjects;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
//		print (ballScript.shoot);
		Vector3 runto = transform.position + ((transform.position - player.position) * multplier);
		float distance = Vector3.Distance (transform.position, player.position);
		if (distance < range) {
			agent.SetDestination (runto);
		}
		
		isDead();
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "CannonBall(Clone)") 
		{
			lifeConvoi -= 1;
		}
	}
		
	void isDead(){
		if (lifeConvoi == 0)
		{
			Destroy(gameObject);
			destroyInt =  (GameObject)Instantiate(destroyPrefab, transform.position, transform.rotation);
			ParticleSystem parts = destroyInt.GetComponent<ParticleSystem> ();
			float totalduration = parts.duration + parts.startLifetime;
			Destroy (destroyInt, totalduration);
			objectLoot();
		}
	}
	
	void objectLoot(){
		for (int i = 0; i < instanceCount; ++i) {
			int lootNumber = Random.Range(0, 1);
			GameObject loot = (GameObject)Instantiate(lootObjects[lootNumber], transform.position, Quaternion.EulerRotation(-90, 0, 0));
		}
	}
}
