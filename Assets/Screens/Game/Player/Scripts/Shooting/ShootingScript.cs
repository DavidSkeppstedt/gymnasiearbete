using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	
	public GameObject projectil;
	private bool canShoot = true;	
	private GameObject gun;
	
	// Use this for initialization
	void Start () {
		gun = GameObject.Find("weapon");
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(gun.transform.forward);
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
		
		if (Physics.Raycast(ray,out hit, 100)) {
			Debug.Log(hit.collider.gameObject.name);
			Debug.DrawLine(gun.transform.position,hit.point);
			
		
			if (Input.GetButtonDown("Fire1")) {
				if (canShoot) {
					
					canShoot = false;
					shoot(hit.collider,hit.point);
					
					
				}
			}else if (Input.GetButtonUp("Fire1")) {
					canShoot = true;
			}

		}
		
		
		
		
		
	
	}
	
	// Here we check what is shot
	private void shoot(Collider collider,Vector3 hit) {
			
		
			if (collider.name == "Cube") {
				pulseGun(hit,collider);	
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





