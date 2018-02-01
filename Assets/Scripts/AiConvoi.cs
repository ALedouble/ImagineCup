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

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 runto = transform.position + ((transform.position - player.position) * multplier);
		float distance = Vector3.Distance (transform.position, player.position);
		if (distance < range) {
			agent.SetDestination (runto);
		}
	}
}
