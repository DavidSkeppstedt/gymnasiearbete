using UnityEngine;
using System.Collections;
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
	private bool shouldPatroll = false;
	private bool stopMe = false;
	private int p = 3;
	
	
	private CharacterController cc;
	private float gravity = 20;
	private Vector3 moveDirection = Vector3.zero;
	
	
	
	// Use this for initialization
	void Start () {
		distanceToPlayer = 0;
		lookDistance = 80;
		attackRange = 30;
		dampning = 6.0f;
		runDistance = 20.0f;
		moveSpeed = 23.0f;
		cc = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
		//Distances till spelaren.
		distanceToPlayer = Vector3.Distance(target.position,transform.position);	
		
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd,out hit, 100)){
            
        	Debug.DrawLine(cc.transform.position,hit.point);
			if (hit.collider.gameObject.name == "level") {
				canSee =false;
			}
			
		}else {
			
			canSee = true;
		}
		
		//Debug.Log("Distance:" + distanceToPlayer +" Can See:" +canSee + " Should Shoot:" + shouldShoot + " Should Run:" + shouldRun + " Should Patroll:" + shouldPatroll);
	
		//Ser inte spelaren och patrulerar
		if (distanceToPlayer > lookDistance) {
			//Patroll!
			renderer.material.color = Color.white;
			
		
			patroll();
		}
		
		
		//Ser spelaren
		if (distanceToPlayer < lookDistance) {
			shouldShoot = false;
			//move towrads player.
			lookAt();
			moveTo();
			
			
		}
		
		
		
		//Om den ser spelaren och ska attackera
		if (distanceToPlayer < attackRange) {
				//attack the player.
				
				shouldShoot = true;
				attack ();
		}
		
		//Om spelaren är för nära och ska backa.
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
			shouldPatroll = false;

	}
	
	void moveTo() {
		//Debug.Break();
		
		if (!shouldShoot){
			renderer.material.color = Color.yellow;
			moveDirection = transform.forward;
			moveDirection *=moveSpeed*2;
			
			Debug.Log("Here");
			
		}
		
		if (stopMe) {
			moveDirection.x = 0;
			moveDirection.z = 0;
			Debug.Log("not here either");
			//Debug.Break();
			
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
			stopMe= true;
			renderer.material.color = Color.blue;
		}else {
			//stopMe = false;
		}
		
		
	}
	
	void patroll() {
		shouldPatroll = true;
		moveDirection.y -= gravity*Time.deltaTime;	
		moveDirection.x = p;
		cc.Move(moveDirection*Time.deltaTime);
		
	}
	
	
	void OnControllerColliderHit (ControllerColliderHit hit) { 
    	 if (hit.normal.y < 0.707){
			p *=-1;
  		}
	}
	
	
	
}