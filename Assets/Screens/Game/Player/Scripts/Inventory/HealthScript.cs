using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public static int killed = 0;
	public int Health = 100;
	public GUIText HP_UI;
	
	// Use this for initialization
	void Start () {
		Health = 100;
		HP_UI.text = "HP:" + Health;
		
	}
	
	
	void Update () {

		if (InventoryScript.currentWeapon == 0) {
						HP_UI.text = "HP:" + Health + " Killed:" + killed + " Rounds:" + ShootingScript.rounds;
		} else {
			HP_UI.text = "HP:" + Health + " Killed:" + killed + " Rounds:" + ShootingScript.rifleRounds;
		}
		if (Health <= 0) {
			
			Die();
		}
		
	}
	
	void LoseHealth(int hp) {
		
		Health -=hp;
		//Debug.Log("I am hit! - " + Health);
		
		
		HP_UI.text = "HP:" + Health + " Killed:" + killed;
		
		
	}
	
	
	void Die() {
		//Debug.Break();
		 Application.LoadLevel(0);
		
	}
	
	




}





