using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {
	
	
	
	
	
	public GameObject[] weaponArray;
	private bool pickedupPrimary;
	private bool pickedupSecondary;
	public static int currentWeapon;
	
	// Use this for initialization
	void Start () {
		
			
		
		
		pickedupPrimary = false;
		pickedupSecondary = false;
		currentWeapon = -1;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey("1")) {
			
			if (currentWeapon != 0) {
				if (pickedupPrimary) {
					SendMessage("setGun",weaponArray[0]);
					currentWeapon = 0;
					weaponArray[0].gameObject.SetActive(true);
					weaponArray[1].gameObject.SetActive(false);
					weaponArray[2].gameObject.renderer.enabled = false;
					Debug.Log("Changed to primary");
				}
			}
			
			
		}
		
		if (Input.GetKey("2")) {
			
			if (currentWeapon != 1) {
				if (pickedupSecondary) {
					currentWeapon = 1;
					weaponArray[1].gameObject.SetActive(true);
					weaponArray[0].gameObject.SetActive(false);
					weaponArray[2].gameObject.renderer.enabled = false;
					Debug.Log("Change to seconday");
				}
			}
			
			
		}

		if (Input.GetKey ("3")) {
			if (currentWeapon != 3) {
				currentWeapon = 3;
				weaponArray[1].gameObject.SetActive(false);
				weaponArray[0].gameObject.SetActive(false);
				weaponArray[2].gameObject.renderer.enabled = true;
			}
		
		}
		
		
		
	
	}
	
	
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
