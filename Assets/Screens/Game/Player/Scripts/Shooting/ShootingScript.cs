using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	
	private GameObject door;
	public GameObject sparkWall;
	public AudioClip rifleSound,gunSound,outofrounds;
	public GameObject muzzleFlash,rifleFlash;
	private bool canShoot = true;
	private bool changeWeapon = false;
	private GameObject gun;
	private float downTime = 0.09f;
	private bool countDown = false;
	public static float shootDistance = 19.0f;
	public static bool reloading = false;

	public static int rounds = 15;
	public static int rifleRounds = 30;





	
	// Use this for initialization
	void Start () {
		gun = GameObject.Find("Gun");
		Screen.lockCursor = true;
		door = GameObject.Find("Level");

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





	public void ShootGun() {
		RaycastHit hit;
		
		Vector3 fwd = transform.TransformDirection(gun.transform.forward);
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
		int layerMask = 1<<9;
		layerMask =~layerMask;
	



		rounds -=1;
		audio.PlayOneShot(gunSound);
		StartCoroutine(muzzleOn());

		canShoot = false;
		countDown = true;

		if (Physics.Raycast(ray,out hit, shootDistance,layerMask)) {
			Debug.DrawLine(gun.transform.position,hit.point);
			shoot(hit.collider,hit.point);
			
		}

	}


	public void ShootRifle() {
		RaycastHit hit;
		
		Vector3 fwd = transform.TransformDirection(gun.transform.forward);
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
		int layerMask = 1<<9;
		layerMask =~layerMask;
		
		
		
		rifleRounds -=1; 
		audio.PlayOneShot(rifleSound);
		StartCoroutine(rifleFlashOn());

		canShoot = false;
		countDown = true;
		
		if (Physics.Raycast(ray,out hit, shootDistance,layerMask)) {
			Debug.DrawLine(gun.transform.position,hit.point);
			shoot(hit.collider,hit.point);
			
		}

		
	}



	// Update is called once per frame
	void Update () {

		/*


		if (Input.GetButtonDown("Fire1") && canShoot && !changeWeapon && (rounds > 0 && InventoryScript.currentWeapon == 0 || rifleRounds > 0 && InventoryScript.currentWeapon == 1) && !reloading) {

			ShootGun();
			/*
			if (InventoryScript.currentWeapon == 0) {
				rounds -=1;
				audio.PlayOneShot(gunSound);
				StartCoroutine(muzzleOn());

			}else {
				rifleRounds -=1; 
				audio.PlayOneShot(rifleSound);
				StartCoroutine(rifleFlashOn());
			}

			canShoot = false;
			countDown = true;


			if (Physics.Raycast(ray,out hit, shootDistance,layerMask)) {
				Debug.DrawLine(gun.transform.position,hit.point);
					shoot(hit.collider,hit.point);

			}*/
		//}

		/*
		if (Input.GetButtonDown ("Fire1") && canShoot && !changeWeapon && (rounds > 0 && InventoryScript.currentWeapon == 0 || rifleRounds > 0 && InventoryScript.currentWeapon == 1) && !reloading) {
			if (InventoryScript.currentWeapon == 0) {
				audio.PlayOneShot(gunSound);
			}
		
		}*/





		if (Input.GetButtonDown("Fire1") && (rounds <= 0 && InventoryScript.currentWeapon == 0 || rifleRounds <= 0 && InventoryScript.currentWeapon == 1)) {

			audio.PlayOneShot(outofrounds);
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

		//Instansierar hitsparks
		GameObject clone = Instantiate(sparkWall, hit, collider.transform.rotation) as GameObject;

		//Skickar ett meddelande till finde entitn att den skadas och på så vis exeveras kod hos den.
		if (collider.name == "Enemy") {
			collider.SendMessage("takeHit");
		}
		
		
		
	}

	IEnumerator muzzleOn() {

		muzzleFlash.SetActive (true);
		yield return new WaitForSeconds(0.1f);
		muzzleFlash.SetActive (false);
	}

	IEnumerator rifleFlashOn() {
		
		rifleFlash.SetActive (true);
		yield return new WaitForSeconds(0.1f);
		rifleFlash.SetActive (false);
	}
	
	
	

	
}