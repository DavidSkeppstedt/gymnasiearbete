using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	
	private GameObject door;
	public AudioClip weaponSound;
	public LineRenderer renderObj;
	private bool canShoot = true;	
	private GameObject gun;
	private float downTime = 0.09f;
	private bool countDown = false;
	public float shootDistance = 150.0f;
	// Use this for initialization
	void Start () {
		gun = GameObject.Find("Puls");
		Screen.lockCursor = true;
		door = GameObject.Find("Level");
	}
	
	
	void setGun(GameObject other) {
		gun = other;
		
		
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		RaycastHit hit;
		if (gun != null){
			
		Vector3 fwd = transform.TransformDirection(gun.transform.forward);
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
		
		if (Physics.Raycast(ray,out hit, shootDistance)) {
			Debug.Log(hit.collider.gameObject.name);
			Debug.DrawLine(gun.transform.position,hit.point);
			
		
			if (Input.GetButtonDown("Fire1")) {
				this.audio.PlayOneShot(weaponSound);//Play a sound!s
				if (canShoot) {
					
					canShoot = false;
					shoot(hit.collider,hit.point);
					
					renderObj.SetPosition(0,gun.transform.position);
					//renderObj.transform.rotation = transform.rotation;
					//Vector3 ss = new Vector3(transform.position.x,transform.position.y,transform.position.z+transform.forward.z*100);
					if (hit.point != null) {
 					
					renderObj.SetPosition(1,hit.point);
					}else {
						renderObj.SetPosition(1,new Vector3(gun.transform.position.x,gun.transform.position.y,gun.transform.position.z+100));
					}
					
					countDown = true;
					
				}
			}else if (Input.GetButtonUp("Fire1")) {
					canShoot = true;
					renderObj.enabled = false;
			}

		}
		
		if (countDown) {
			renderObj.enabled = true;
			downTime -=Time.deltaTime;
			if (downTime <=0) {
				renderObj.enabled = false;
				countDown = false;
				downTime= 0.09f;
			}	
			
			
		}
		
		
		
	}
}
	
	// Here we check what is shot
	private void shoot(Collider collider,Vector3 hit) {
			
		
			if (collider.name == "Cube") {
				pulseGun(hit,collider);	
			
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





