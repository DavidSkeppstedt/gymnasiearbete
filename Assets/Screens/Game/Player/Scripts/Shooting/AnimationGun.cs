using UnityEngine;
using System.Collections;

public class AnimationGun : MonoBehaviour {
	//De olika animationsvariablerna som är unika för varje vapen.
	public string fireAnim;
	public string idleAnim;
	public string upAnimation;
	public string downAnimation;
	public string reloadAnimation;

	public GameObject player;


	// Update is called once per frame
	void Update () {
			//Olika kontroller för att spela upp rätt typ av animation och hindra från att man kan skjuta när vissa animationer spelas.
		if (InventoryScript.currentWeapon == 0 ) {
		if (Input.GetButtonDown ("Fire1") && (ShootingScript.rounds > 0 && InventoryScript.currentWeapon == 0 || ShootingScript.rifleRounds > 0 && InventoryScript.currentWeapon == 1)) {

			if (!animation.IsPlaying(reloadAnimation) && !animation.IsPlaying(upAnimation) && !animation.IsPlaying (downAnimation) && !animation.IsPlaying(fireAnim)) {
				animation.Play(fireAnim,PlayMode.StopAll);
				player.SendMessage("ShootGun");
			}
		}
		}

		if (InventoryScript.currentWeapon == 1 ) {
			if (Input.GetButton ("Fire1") && (ShootingScript.rounds > 0 && InventoryScript.currentWeapon == 0 || ShootingScript.rifleRounds > 0 && InventoryScript.currentWeapon == 1)) {
				
				if (!animation.IsPlaying(reloadAnimation) && !animation.IsPlaying(upAnimation) && !animation.IsPlaying (downAnimation) &&!animation.IsPlaying(fireAnim)) {
					animation.Play(fireAnim,PlayMode.StopAll);
					player.SendMessage("ShootRifle");
				}
			}
		}





		if (Input.GetButton ("Reload") && !animation.IsPlaying(upAnimation) && !animation.IsPlaying (downAnimation)) {
			animation.Play(reloadAnimation,PlayMode.StopAll);
			audio.Play ();

			if (InventoryScript.currentWeapon == 0) {
				ShootingScript.rounds = 15;
			}else {
				ShootingScript.rifleRounds = 30;
			}



		}


		if (animation.IsPlaying (reloadAnimation)) {
			ShootingScript.reloading = true;
		} else {
			ShootingScript.reloading = false;
		}



		if (!animation.IsPlaying (downAnimation)) {
			animation.PlayQueued (idleAnim);
		}
	
	}



	void playUp() {
		animation.Play (upAnimation, PlayMode.StopAll);
	}
	
	void playDown() {
		animation.Play (downAnimation, PlayMode.StopAll);
	}


}
