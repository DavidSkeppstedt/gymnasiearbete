using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {
	//Variabler för att kontrollera vilka vapen spelaren har tagit upp och vilka lägen dessa vapen är i.
	public GameObject[] weaponArray;
	private bool pickedupPrimary;
	private bool pickedupSecondary;
	private bool changing,downGun,upGun,downRifle,upRifle,toggled;
	public static int currentWeapon;
	private ShootingScript shootScript;
	
	// Use this for initialization
	void Start () {
		
		
		
		shootScript =GameObject.Find("PlayerObject").GetComponent("ShootingScript") as ShootingScript;
		pickedupPrimary = true;
		pickedupSecondary = false;

		currentWeapon = 0;
		changing =downGun=downRifle=upRifle=upGun=toggled= false;
		
	}
	
	// Update is called once per frame
	void Update () {


		//Från Gevär till Pistol
		if (Input.GetKey("1")) {
			
			if (currentWeapon != 0) {
				if (pickedupPrimary) { //Byter till pistolen här.
					//SendMessage("setGun",weaponArray[0]);
					weaponArray[1].gameObject.SendMessage("playDown");
					currentWeapon = 0;
					changing = true;
					ShootingScript.shootDistance = 19f;

					//weaponArray[0].gameObject.SetActive(true);
					//weaponArray[1].gameObject.SetActive(false);

					//Debug.Log("Changed to primary" + (1.0f / Time.deltaTime));
				}
			}
			
			
		}


		//Från Pistol till gevär
		if (Input.GetKey("2")) {
			
			if (currentWeapon != 1) {
				if (pickedupSecondary && !changing) {

					weaponArray[0].gameObject.SendMessage("playDown");
				
					currentWeapon = 1;
					changing = true;
					ShootingScript.shootDistance = 38f;

					//weaponArray[1].gameObject.SetActive(true);
					//weaponArray[0].gameObject.SetActive(false);

//					Debug.Log("Change to seconday" + (1.0f / Time.deltaTime));
				}
			}
			
			
		}

		//Om man håller på att byta så ändrar man lite variabler.
		if (changing) {
			toggled =true;
			shootScript.setCanShoot(true);

			if (currentWeapon == 1) {
				fromGunToRifle("Pistol_Down","Rifle_Up",0,1);
			}

			if (currentWeapon == 0) {
				fromRifleToGun("Rifle_Down","Pistol_Up",1,0);
			}




		}else { //Annars nej, kan inte skjuita.

			if (toggled){
				toggled = false;
				shootScript.setCanShoot(false);
			}
		}


		

		
		
		
		
	}
	//metoder för att bya från pistol till gäver, ändrar främst i olika variabler.
	void fromGunToRifle(string downAnimation,string upAnimation, int deactive,int active) {
		if (!weaponArray[deactive].animation.IsPlaying (downAnimation) && !downGun) {
			//Detta innbär att animationen är klar
			//Då skall vi slå på nästa vapen
			//Först avaktivera nuvarande
			weaponArray[deactive].gameObject.SetActive(false);
			upGun = false;
			downRifle = false;
			downGun = true;

		}
		if (downGun) {
			//Detta innebär att det vapen vi byter ifrån är nere och vi skall starta animationen på	
			//Det nya vapnen
			if (upGun == false) {
				//Först aktiverar vi det
				weaponArray[active].gameObject.SetActive(true);
				//Sen spelar vi up animationen
				weaponArray[active].gameObject.SendMessage("playUp");
				upGun = true;

			}

			if (!weaponArray[active].gameObject.animation.IsPlaying(upAnimation)) {
				changing = false;
		}



	}
}
	//Samma som ovan fast med gevär till pistol.
	void fromRifleToGun(string downAnimation,string upAnimation, int deactive,int active) {
		if (!weaponArray[deactive].animation.IsPlaying (downAnimation) && !downRifle) {
			//Detta innbär att animationen är klar
			//Då skall vi slå på nästa vapen
			//Först avaktivera nuvarande
			weaponArray[deactive].gameObject.SetActive(false);
			upRifle = false;
			downGun = false;
			downRifle = true;
			
		}
		if (downRifle) {
			//Detta innebär att det vapen vi byter ifrån är nere och vi skall starta animationen på	
			//Det nya vapnen
			if (!upRifle) {
				//Först aktiverar vi det
				weaponArray[active].gameObject.SetActive(true);
				//Sen spelar vi up animationen
				weaponArray[active].gameObject.SendMessage("playUp");
				upRifle = true;
			}
			if (!weaponArray[active].animation.IsPlaying(upAnimation)) {
				changing = false;
			}
		}
	}





	
	//metod för att kontrollera om man tar upp det bättre vapnet och på så sätt tillåter att man byter til det via knapparna 1 och 2.
	
	void pickUp(int index) {
		switch (index) {
		case 0:
			pickedupSecondary = true;
			break;
		case 1:
			pickedupPrimary = true;
			
			
			break;
			
			
			
		}
		
		
		
		
		
	}
	
	
	
	
}