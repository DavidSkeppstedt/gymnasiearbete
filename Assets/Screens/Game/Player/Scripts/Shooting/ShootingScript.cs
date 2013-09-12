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
		
		
		if (Input.GetButtonDown("Fire1")) {
			if (canShoot) {
				Debug.Log("Shoot!");
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
