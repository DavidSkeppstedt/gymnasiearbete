using UnityEngine;
using System.Collections;
public class SimpleAi : MonoBehaviour {
	
	//Deklarerar en hel del variabler för Ai
	
	//Hur mycket skada den kan ta
	public float health = 100.0f;
	//Ett avstånd till spelaren
	private float distanceToPlayer;
	//En vektor till måletm, spelaren
	public Transform target;
	//Hur långt Ai kan se för att upptäcka spelarenn
	private float lookDistance;
	//Hur nära Ain måste vara för att attackera spelaren.
	private float attackRange;
	//Dämpar den sfäriska interpolationen när Ai roteras.
	private float dampning;
	//Hur snabbt den får gå.
	private float moveSpeed;
	//Avstånden från seplaren när Ai skall fly från den.
	private float runDistance;
	//Om den ska skjutaw
	private bool shouldShoot = false;
	//Om inga väggar är i vägen.
	private bool canSee = false;
	//Om den ska fly
	private bool shouldRun = false;
	//Eller om den bara ska patrullera
	private bool shouldPatroll = false;
	//En slumpvariabelstart
	private int p = 3;
	//Om Ai kan skjuta
	private bool canShoot = true;
	//Om den skjuter
	private bool isShooting = false;
	//Tiden mellan varje skott
	private float timer = 1;
	//OM den skall rörar sig
	private bool shouldMove = false;
	//Modulen som förenklar rörelse.
	private CharacterController cc;
	//En vektor för rörelsen av AI som initsieras med 0,0,0
	private Vector3 moveDirection = Vector3.zero;
	//Vektor för åt vilket håll AI skall rörar sig.
	private Vector3 direction;
	
	
	// Use this for initialization
	void Start () {
		//Inställningar av alla variabler.
		distanceToPlayer = 0;
		lookDistance = 20;
		attackRange = 8;
		dampning = 6.0f;
		runDistance = 4.0f;
		moveSpeed = 3.0f;
		cc = GetComponent<CharacterController>();
	
	}
	//Returernar om Ai skjuter
	public bool isAttacking() {
		return isShooting;
	}
	
	//Metod för att se om Ai tar skada
	void takeHit() {
		
		//Om den har mer liv än 0
		if (health >= 0) {
			//Skada från pistol
			if (InventoryScript.currentWeapon == 0) {
				health -=25; //minska liv med 25
			}
			//Skada från gevär
			if (InventoryScript.currentWeapon == 1) {
				health -=30; // ovan
			}

		}else { // Om inte liven räcker
			//Ta bort Ain den.
			Destroy(transform.gameObject);
			HealthScript.killed +=1;
		}
		
		
	}
	//Physic update loop för Ain
	void FixedUpdate(){
		
		//Om Ain ska patrullerar rör den sig i en slumpad väg.
		if (shouldPatroll) {
			
			cc.SimpleMove(moveDirection);
		}

		//Om den kan ska röra sig och ser spelaren, kommer AI röra sig mot spelaren
		if (shouldMove && canSee) {
			moveDirection = transform.forward;
			moveDirection *=moveSpeed*2;
			cc.SimpleMove(moveDirection);
			//Debug.Log("Run Towards");
		}
		//Om ska fly och ser spelaren, kommer AI röra från mot spelaren
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
		lookAt (); //Metod för att låta ain rotera mot spelaren.

		if (distanceToPlayer < 20) { // kollar om avståndet till spelaren är mindre än 20.
			//Method call
			castRay ();//Då kastas en stråle från Ain.
						

			//Om den patrulerar
			if (shouldPatroll) {
				shouldPatroll = false; // slutar med patrull
				moveDirection = Vector3.zero; // sätter direction vektor till 0
			}

			shouldMove = true; // återställer should move variabel.



			//Om avståndet till spelaren är minder än att och större än fly och Ai kan se så attackerar AIn.
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
			
			//Annars flyr den från seplaren
			if (distanceToPlayer < runDistance && canSee) {
				shouldMove = false;
				shouldRun = true;
				shouldShoot = false;

			}else {
				shouldRun = false;
			}





		}  
		//Om den inte kan se spelaren pga vägg eller liknande så får den en ny direktion att gå.
		if (!canSee) {
			moveDirection.z = p;
			shouldPatroll = true;
		}
	
	
	}
	
	//Metod som kastar stråle från Ain för att kolla om AI ser spelaren. Den har ett se värde på 20 världsenheter.
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
				//Räknar ut hur den skall interpolera rotationen för att det ska ske bra ut. Och roterar AIn.
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * dampning);
			}
			
			
	}

	
	//metod för att attackera spelaren
	//Om den ska skjuta och ser och kan skjuta så skadas spelaren och en timer börjar. Annars räknar timern bara ner tills nästa gång den kan skjuta.
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
	//Patrullerar metoden, låter Ain patrullera i en godtycklig riktning.
	void patroll() {

			moveDirection.x = p;
			cc.Move(moveDirection*Time.deltaTime);
		
	}
	
	//Kontrollerar så att Ain vänder sig vid kontroll med väg där normalens vinkel är mindre än .710 rad.
	void OnControllerColliderHit (ControllerColliderHit hit) { 
    	 if (hit.normal.y < 0.710){
			p *=-1;
  		}
	}
	
	
	
}