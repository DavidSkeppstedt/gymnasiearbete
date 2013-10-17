using UnityEngine;
using System.Collections;

public class SimpleAi : MonoBehaviour {
	
	
	private float distanceToPlayer;
	public Transform target;
	private float lookDistance;
	private float attackRange;
	private float dampning;
	private float moveSpeed;
	private bool shouldShoot = false;
	
	// Use this for initialization
	void Start () {
		distanceToPlayer = 0;
		lookDistance = 100;
		attackRange = 50;
		dampning = 6.0f;
		
		moveSpeed = 23.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		distanceToPlayer = Vector3.Distance(target.position,transform.position);
		Debug.Log(distanceToPlayer);
		if (distanceToPlayer < lookDistance) {
			
			//move towrads player.
			renderer.material.color = Color.yellow;
			lookAt();
			moveTo();
			shouldShoot = false;
			
		}
		
		if (distanceToPlayer > lookDistance) {
			//Patroll!
			renderer.material.color = Color.white;
			shouldShoot = false;
		}
		
		if (distanceToPlayer < attackRange) {
				//attack the player.
				renderer.material.color = Color.red;
			shouldShoot = true;
		}
		
		
	
	}



	void lookAt() {
		var rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*dampning);
		
		
		
		
	}
	
	void moveTo() {
		if (!shouldShoot){
		transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
		}
	}
	
}