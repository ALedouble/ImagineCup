using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

	public class AiBasic : MonoBehaviour {
	
	public float lookRadius = 10f;
	public GameObject boat; 
	
	public Transform target;
	public NavMeshAgent agent;
	public GameObject lifeBar;
	
	public bool attach;
	public int life;
	public bool playerDead;
	Collider boxCollider;
	
	private bool destroyEnnemi;
	private float attackTimer = 2f;
	
	void Start(){
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		boxCollider = GetComponent<BoxCollider>();
	}
	
	void Update(){
		Attack ();
		isDeath();
		float distance = Vector3.Distance(target.position, transform.position);
		
		if (distance <= lookRadius && attach == false)
		{
			agent.SetDestination(target.position);

			if (distance <= agent.stoppingDistance)
			{
				FaceTarget();
			}
		}
		
		if (distance < 4.5f)
		{
			if (attach == false)
			{ 
				transform.parent = boat.transform;
				transform.position = boat.transform.position + new Vector3(Random.Range(-0.3f,0.6f), Random.Range(0.6f,1.6f), Random.Range(-0.3f,0.6f));
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

	void isDeath()
	{
		if (life == 0 && attach == true) 
		{
			Destroy (GameObject.FindWithTag ("EnnemiTouche"));
			destroyEnnemi = true;
		}
	}

	void Attack()
	{
		if (attach == true) 
		{
			attackTimer -= Time.deltaTime;
			if (attackTimer <= 0)
			{
				lifeBar.transform.localScale -= new Vector3 (0.15f, 0, 0);
				attackTimer = 2;
			}
		}

		if (lifeBar.transform.localScale.x <= 0) {
			playerDead = true;
			StartCoroutine (MenuCoroutine());
		}
	}


	IEnumerator MenuCoroutine()
	{
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Menu");
	}

}
