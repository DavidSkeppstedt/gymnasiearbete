using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class SimpleAi : MonoBehaviour {
	
	
	private float distanceToPlayer;
	public Transform target;
	private float lookDistance;
	private float attackRange;
	private float dampning;
	private float moveSpeed;
	private float runDistance;
	private bool shouldShoot = false;
	private bool canSee = false;
	private bool shouldRun = false;
	
	
	
	
	private CharacterController cc;
	private float gravity = 20;
	private Vector3 moveDirection = Vector3.zero;
	
	
	
	// Use this for initialization
	void Start () {
		distanceToPlayer = 0;
		lookDistance = 100;
		attackRange = 50;
		dampning = 6.0f;
		runDistance = 30.0f;
		moveSpeed = 23.0f;
		cc = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		
		
		
		distanceToPlayer = Vector3.Distance(target.position,transform.position);
		
		
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd,out hit, 100)){
            print("There is: " + hit.collider.gameObject.name);
        	Debug.DrawLine(cc.transform.position,hit.point);
			if (hit.collider.gameObject.name == "level") {
				canSee =false;
			}
			
    	}else {
			canSee = true;
			
		}
		
		
		Debug.Log(distanceToPlayer);
		if (distanceToPlayer < lookDistance) {
			
			//move towrads player.
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
				
				shouldShoot = true;
		}
		
		if (distanceToPlayer < runDistance) {
			shouldRun = true;
		}else {
			shouldRun = false;
		}
		
	
	}



	void lookAt() {
		var rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*dampning);
		renderer.material.color = Color.red;
		
		
		
	}
	
	void moveTo() {
		if (!shouldShoot && canSee){
			renderer.material.color = Color.yellow;
			
			//transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
			moveDirection = transform.forward;
			moveDirection *=moveSpeed*2;
		}else {
			moveDirection.x = 0;
			moveDirection.z = 0;
		}
		
		if (shouldRun) {
			moveDirection = -transform.forward;
			moveDirection *=moveSpeed;
		}
		
			moveDirection.y -= gravity * Time.deltaTime;	
			cc.Move(moveDirection*Time.deltaTime);
			
		
	}
	
	
	void attack () {
		if (shouldShoot) {
			//Shoot here!
			
			
		}
		
		
	}
	
	
	
}