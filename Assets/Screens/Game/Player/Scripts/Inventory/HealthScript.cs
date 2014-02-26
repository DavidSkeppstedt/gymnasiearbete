using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public static int killed = 0;
	public int Health = 100;
	public GUIText HP_UI,HUD_ROUNDS;
	public GUITexture HUD_WEAP;
	public Texture rif,gun;
	public AudioClip playerhit;
	
	// Use this for initialization
	void Start () {
		Health = 100;
		HP_UI.text = "" + Health;
		 
	}
	
	
	void Update () {

		if (InventoryScript.currentWeapon == 0) {
						HP_UI.text = ""+Health;
						HUD_ROUNDS.text = ShootingScript.rounds+"/INF";
			HUD_WEAP.texture =gun; 
		} else {
			HP_UI.text = ""+Health;
			HUD_ROUNDS.text = ShootingScript.rifleRounds+"/INF";
			HUD_WEAP.texture =rif;
		}
		if (Health <= 0) {
			
			Die();
		}
		
	}
	
	void LoseHealth(int hp) {
		Health -=hp;
		//Debug.Log("I am hit! - " + Health);
		HP_UI.text =""+Health;
		audio.PlayOneShot (playerhit);
		
	}
	
	
	void Die() {
		//Debug.Break();
		 Application.LoadLevel(0);
		
	}
	
	




}





