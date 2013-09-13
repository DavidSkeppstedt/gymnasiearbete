using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	
	public GameObject projectil;
	private bool canShoot = true;	
	private GameObject gun;
	
	// Use this for initialization
	void Start () {
		gun = GameObject.Find("weapon");
	}
	
	// Update is called once per frame
	void Update () {
		
		
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(gun.transform.forward);
		if (Physics.Raycast(gun.transform.position,fwd,out hit, 25)) {
			Debug.Log(hit.collider.gameObject.name);
			Debug.DrawLine(transform.position,hit.point);
		}
		
		
		
		if (Input.GetButtonDown("Fire1")) {
			if (canShoot) {
				
				canShoot = false;
				shoot();
				
			}
		}else if (Input.GetButtonUp("Fire1")) {
			canShoot = true;
		}
		
	
	}
	
	
	private void shoot() {
		
		Vector3 pos = gun.transform.position;
		//pos.z +=2;
		GameObject o = Instantiate(projectil,pos,gun.transform.rotation) as GameObject;
	
		o.rigidbody.AddForce(o.transform.forward*1000);
		Destroy(o,120);
		
		
		
	
		
		
	}
	


}
