using UnityEngine;
using System.Collections;
public class SimpleAi : MonoBehaviour {
	
	public float health = 100.0f;
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

	private int p = 3;
	private bool canShoot = true;
	private bool isShooting = false;
	private float timer = 1;
	private bool shouldMove = false;
	
	private CharacterController cc;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 direction;
	
	
	// Use this for initialization
	void Start () {
		distanceToPlayer = 0;
		lookDistance = 20;
		attackRange = 8;
		dampning = 6.0f;
		runDistance = 4.0f;
		moveSpeed = 3.0f;
		cc = GetComponent<CharacterController>();
	
	}

	public bool isAttacking() {
		return isShooting;
	}
	
	void takeHit() {
		
		if (health >= 0) {
			//Skada från pistol
			if (InventoryScript.currentWeapon == 0) {
				health -=25;
			}

			if (InventoryScript.currentWeapon == 1) {
				health -=30;
			}

		}else {
			Destroy(transform.gameObject);
			HealthScript.killed +=1;
		}
		
		
	}
	
	void FixedUpdate(){

		if (shouldPatroll) {
			
			cc.SimpleMove(moveDirection);
		}


		if (shouldMove && canSee) {
			moveDirection = transform.forward;
			moveDirection *=moveSpeed*2;
			cc.SimpleMove(moveDirection);
			//Debug.Log("Run Towards");
		}

		if (shouldRun && canSee) {
			//Debug.Log("Run");
			moveDirection = target.transform.forward;
			moveDirection *=moveSpeed;
			cc.SimpleMove(moveDirection);
		} 


	}


	// Update is called once per frame
	void Update () {

		//Tar fram 3d koordinaten från target
		Vector3 targetPos = target.position;
		targetPos = new Vector3(targetPos.x,targetPos.y,targetPos.z);

		//Distances till spelaren.
		distanceToPlayer = Vector3.Distance(targetPos,transform.position);
		direction = (target.position - transform.position).normalized;
	
		//Kollar om man är tillträckligt nära för att spara på CPU-power
		//Och på så sätt slippa dyra operationer/beräkningar
		//Debug.Log (canSee + ":" +distanceToPlayer);
		//Method call
		lookAt ();

		if (distanceToPlayer < 20) {
			//Method call
			castRay ();
						


			if (shouldPatroll) {
				shouldPatroll = false;
				moveDirection = Vector3.zero;
			}

			shouldMove = true;




			if (distanceToPlayer < attackRange && distanceToPlayer > runDistance && canSee) {
			//	Debug.Log("Attack");
				shouldShoot = true;	
				shouldMove = false;
				shouldRun = false;
				attack();
			}else {
				shouldShoot = false;
				isShooting = false;
			}
			if (distanceToPlayer < runDistance && canSee) {
				shouldMove = false;
				shouldRun = true;
				shouldShoot = false;

			}else {
				shouldRun = false;
			}





		}  

		if (!canSee) {
			moveDirection.z = p;
			shouldPatroll = true;
		}
	
	
	}

	void castRay(){
		RaycastHit hit;
		direction = (target.position - transform.position).normalized;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		
		if (Physics.Raycast (transform.position, direction, out hit, 20)) {

			
			Debug.DrawLine (transform.position, hit.transform.position);
			
			if (hit.collider.gameObject.name == "PlayerObject") {

				canSee = true;
			} else {
				canSee = false;
			}
			
			
		}

	}


	void lookAt() {
			if (true) {
				//Hittar rotations skillnaden mellan spelaren och alienen
				var rotation = Quaternion.LookRotation (target.position - transform.position);
				//Räknar ut hur den skall interpolera rotationen för att det ska ske bra ut.
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * dampning);
			}
			
			
	}

	
	
	void attack () {
		if (shouldShoot && canSee) {
			if (canShoot) {
				//Shoot here!
				isShooting = true;
				//renderer.material.color = Color.blue;
				target.gameObject.SendMessage("LoseHealth",6);
				canShoot = false;
				timer = 0.9f;
			}else {
				if (timer > 0) {
					//Debug.Log(timer);
					timer -= Time.deltaTime;

					
				}else {
					canShoot = true;

				}
	
			}
			
		}
		
		
	}
	
	void patroll() {

			moveDirection.x = p;
			cc.Move(moveDirection*Time.deltaTime);
		
	}
	
	
	void OnControllerColliderHit (ControllerColliderHit hit) { 
    	 if (hit.normal.y < 0.710){
			p *=-1;
  		}
	}
	
	
	
}