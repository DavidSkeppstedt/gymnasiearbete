using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	//De variabler som behövs för skriptet.
	private GameObject door;
	public GameObject sparkWall;
	public AudioClip rifleSound,gunSound,outofrounds; //Alla olika skjutljud
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
		//Kollar så att man har en pistol på sig.
		gun = GameObject.Find("Gun");
		Screen.lockCursor = true;
		door = GameObject.Find("Level");

	}
	
	
	void setGun(GameObject other) {
		gun = other;
		
		
	}
	//Setter för att skjuta, används ex av AnimGun osv.
	public void setCanShoot(bool toogle) {
		this.changeWeapon = toogle;
	}
	//Returenerar om man kan skjuta.
	public bool getCanShoot() {
		return this.changeWeapon;

	}



	//Metod för att skjuta med pistolen.
	public void ShootGun() {
		RaycastHit hit;
		//En riktiningsvektor rakt fram.
		Vector3 fwd = transform.TransformDirection(gun.transform.forward);
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
		int layerMask = 1<<9; // Gör så att man inte kan träffa triggers
		layerMask =~layerMask;
	


		//minskar ammonitionen
		rounds -=1;
		audio.PlayOneShot(gunSound); // spelar upp ljud
		StartCoroutine(muzzleOn());

		canShoot = false;
		countDown = true;
		//Skjuter den riktiga strålen.
		if (Physics.Raycast(ray,out hit, shootDistance,layerMask)) {
			Debug.DrawLine(gun.transform.position,hit.point);
			shoot(hit.collider,hit.point);
			
		}

	}

	//Samma som ovan fast med gevärt.
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




		/*Här kollas det om man har slut på skott på vapnet och således spelar upp ett slut på skott ljud.*/
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

		//Instansierar hitsparks, partiklar som visar var man träffar.
		GameObject clone = Instantiate(sparkWall, hit, collider.transform.rotation) as GameObject;

		//Skickar ett meddelande till finde entitn att den skadas och på så vis exeveras kod hos den.
		if (collider.name == "Enemy") {
			collider.SendMessage("takeHit");
		}
		
		
		
	}
	//Metoder för att sätta på muzzelflashen i några sekunder för en snyggare vapen effekt.
	IEnumerator muzzleOn() {

		muzzleFlash.SetActive (true);
		yield return new WaitForSeconds(0.1f);
		muzzleFlash.SetActive (false);
	}
//Stänger av ovan.
	IEnumerator rifleFlashOn() {
		
		rifleFlash.SetActive (true);
		yield return new WaitForSeconds(0.1f);
		rifleFlash.SetActive (false);
	}
	
	
	

	
}