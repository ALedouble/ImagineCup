using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

	public class AiBasic : MonoBehaviour {
	
	public float lookRadius = 10f;
	public GameObject boat; 
	
	public Transform target;
	public NavMeshAgent agent;
	
	private bool attach;
	Collider boxCollider;
	
	void Start(){
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		boxCollider = GetComponent<BoxCollider>();
	}
	
	void Update(){
		float distance = Vector3.Distance(target.position, transform.position);
		
		if (distance <= lookRadius && attach == false)
		{
			agent.SetDestination(target.position);

			if (distance <= agent.stoppingDistance)
			{
				FaceTarget();
			}
		}
		
		if (distance < 3)
		{
		if (attach == false)
			{ 
				transform.parent = boat.transform;
				transform.position = boat.transform.position + new Vector3(Random.Range(-0.3f,0.6f), Random.Range(0f,0.6f), Random.Range(-0.3f,0.6f));
				agent.speed = 0;
				boxCollider.isTrigger = true;
				attach = true;
				transform.gameObject.tag = "EnnemiTouche";
				agent.enabled = false;
				Physics.gravity = Vector3.zero;
			}
		}
	}
	
	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position);
		Quaternion lookRotation = Quaternion.LookRotation( new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

}
