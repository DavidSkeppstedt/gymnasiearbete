using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	
	private GameObject door;
	public GameObject sparkWall;
	public AudioClip weaponSound;

	private bool canShoot = true;
	private bool changeWeapon = false;
	private GameObject gun;
	private float downTime = 0.09f;
	private bool countDown = false;
	public static float shootDistance = 19.0f;
	public static bool reloading = false;

	public static int rounds = 15;
	public static int rifleRounds = 30;

	//public Rigidbody grenade;
	private GameObject uiGrenade;
	
	// Use this for initialization
	void Start () {
		gun = GameObject.Find("Gun");
		Screen.lockCursor = true;
		door = GameObject.Find("Level");
		uiGrenade = GameObject.Find("Grenade");
	}
	
	
	void setGun(GameObject other) {
		gun = other;
		
		
	}

	public void setCanShoot(bool toogle) {
		this.changeWeapon = toogle;
	}

	public bool getCanShoot() {
		return this.changeWeapon;

	}

	
	// Update is called once per frame
	void Update () {

		
		RaycastHit hit;

		Vector3 fwd = transform.TransformDirection(gun.transform.forward);
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
		int layerMask = 1<<9;
		layerMask =~layerMask;


		if (Input.GetButton("Fire1") && canShoot && !changeWeapon && (rounds > 0 && InventoryScript.currentWeapon == 0 || rifleRounds > 0 && InventoryScript.currentWeapon == 1) && !reloading) {

			if (InventoryScript.currentWeapon == 0) {
				rounds -=1;
			}else {
				rifleRounds -=1; 
			}

			canShoot = false;
			countDown = true;


			if (Physics.Raycast(ray,out hit, shootDistance,layerMask)) {
				Debug.DrawLine(gun.transform.position,hit.point);
					shoot(hit.collider,hit.point);

			}
		}

		if (countDown) {
			downTime -=Time.deltaTime;
			if (downTime <=0) {
				
				countDown = false;
				downTime= 0.28f;
				canShoot = true;
			}	
		}



		
	}
	
	// Here we check what is shot
	private void shoot(Collider collider,Vector3 hit) {


		GameObject clone = Instantiate(sparkWall, hit, collider.transform.rotation) as GameObject;

		if (collider.name == "Cube") {
			pulseGun(hit,collider);		
		}

		if (collider.transform.root.gameObject.name == "MAP2" || 
		    collider.transform.root.gameObject.name == "DoorController" ) {

			//instantiate a particle object at the position of the hit
			//GameObject clone = Instantiate(sparkWall, hit, collider.transform.rotation) as GameObject;





		}



		if (collider.name == "Sphere_1") {
			door.SendMessage("OpenDoor");
		}
		
		if (collider.name == "Enemy") {
			collider.SendMessage("takeHit");
		}
		
		
		
	}
	
	
	
	
	//Here we apply wich gun we want,
	
	//This is the pulseGun!
	private void pulseGun(Vector3 hit, Collider collider) {
		
		Rigidbody r= collider.rigidbody;
		r.AddTorque(hit*150,ForceMode.Impulse);
		r.AddForceAtPosition(2000*transform.forward,hit);
	}	
	
	
	
	
	
}