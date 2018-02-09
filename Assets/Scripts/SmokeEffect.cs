using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEffect : MonoBehaviour {

    public GameObject particlePrefab;
	public GameObject accelerationPrefab;
	public GameObject boat;
	public GameObject reacteur;

	private int numberParticle;
	private GameObject particleInstance;

    // Use this for initialization
    void Start () {
		reacteur.transform.eulerAngles = new Vector3(0, -20, 0); 
	}
	
	// Update is called once per frame
	void Update () {

		float moveVertical = Input.GetAxis("Vertical");
		
		
		if (moveVertical >= 0.5 && numberParticle == 0){
			particleInstance = (GameObject)Instantiate(particlePrefab, transform.position, transform.rotation);
			particleInstance.transform.parent = transform;
			numberParticle += 1;
		}
		
		if (Input.GetButton("Nitro") && moveVertical >= 0.5 && numberParticle == 0){
			particleInstance = (GameObject)Instantiate(accelerationPrefab, transform.position, transform.rotation);
			particleInstance.transform.parent = transform;
			numberParticle += 1;
		}
		
		if (moveVertical < 0){
			particlePrefab.SetActive(false);
		}
		else
		{
			particlePrefab.SetActive(true);
		}
    }
}
