using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiConvoi : MonoBehaviour {

	NavMeshAgent agent;
	[SerializeField] Transform player;
	int multplier = 1;
	float range = 70;
	public int lifeConvoi = 10;
	public CannonBall ballScript;
	public GameObject destroyPrefab;
	private GameObject destroyInt;
	bool distanceSound;
	public int instanceCount = 3;
	// Use this for initialization
	
	public GameObject[] lootObjects;
	public AudioClip[] clip;
	AudioSource audio;
	
	public AudioSource mainTheme;
	public AudioClip mainClip;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		audio = GetComponent<AudioSource>();
		mainTheme = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		mainTheme.Play();
		
//		print (ballScript.shoot);
		Vector3 runto = transform.position + ((transform.position - player.position) * multplier);
		float distance = Vector3.Distance (transform.position, player.position);
		print (distance);
		if (distance < range) {
			agent.SetDestination (runto);
		}
		
		if (distance < 60 && distanceSound == false){
			audio.PlayOneShot(clip[0], 0.4f);
			audio.PlayOneShot(mainClip, 0.4f);
			distanceSound = true;
			audio.mute = false;
			mainTheme.mute = false;
			print ("oui");
		}
		
		if (distance > 60)
		{
			distanceSound = false;
			
			mainTheme.mute = true;
			audio.mute = true;
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
