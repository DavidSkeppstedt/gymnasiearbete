using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	
	private GameObject door;
	public GameObject sparkWall;
	public AudioClip weaponSound;

	private bool canShoot = true;	
	private GameObject gun;
	private float downTime = 0.09f;
	private bool countDown = false;
	public float shootDistance = 19.0f;
	private int grInt = 3;
	public Rigidbody grenade;
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
	
	
	void throwGrenade() {
		if (Input.GetButtonDown("Fire1") && grInt >0 ) {
			Rigidbody clone;
			clone = Instantiate(grenade, uiGrenade.transform.position, Camera.main.transform.rotation) as Rigidbody;
			clone.AddForce(Camera.main.transform.forward * 1000);
			grInt -=1; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (InventoryScript.currentWeapon);
		
		RaycastHit hit;
		
		if (InventoryScript.currentWeapon == 3) {
			throwGrenade();
			
		}
		
		
		if (gun != null && InventoryScript.currentWeapon != 3){
			
			Vector3 fwd = transform.TransformDirection(gun.transform.forward);
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
			int layerMask = 1<<9;
			layerMask =~layerMask;   
			if (Physics.Raycast(ray,out hit, shootDistance,layerMask)) {
				//Debug.Log(hit.collider.gameObject.name);
				Debug.DrawLine(gun.transform.position,hit.point);
				
				
				if (Input.GetButton("Fire1")) {
					//this.audio.PlayOneShot(weaponSound);//Play a sound!s
					if (canShoot) {
						
						canShoot = false;
						shoot(hit.collider,hit.point);
						
						//renderObj.SetPosition(0,gun.transform.position);
						//renderObj.transform.rotation = transform.rotation;
						//Vector3 ss = new Vector3(transform.position.x,transform.position.y,transform.position.z+transform.forward.z*100);
						if (hit.point != null) {
							
						//	renderObj.SetPosition(1,hit.point);
						}else {
							//renderObj.SetPosition(1,new Vector3(gun.transform.position.x,gun.transform.position.y,gun.transform.position.z+100));
						}
						
						countDown = true;
						
					}
				}
				
			}
			
			if (countDown) {
				//renderObj.enabled = true;
				downTime -=Time.deltaTime;
				if (downTime <=0) {
					//renderObj.enabled = false;
					countDown = false;
					downTime= 0.28f;
					canShoot = true;
				}	
				
				
			}
			
			
			
		}
	}
	
	// Here we check what is shot
	private void shoot(Collider collider,Vector3 hit) {
		//Debug.Log("C" + collider.transform.root.gameObject.name);
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