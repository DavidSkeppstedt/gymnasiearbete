using UnityEngine;
using System.Collections;

public class PlayGUI : MonoBehaviour {
	//Referar till det skinn som skall används för den här knappen.
	public GUISkin skin;
	//Beräknar den skala som behövs för att knapparna skall fungera på olika skärmstorlekar.
	//Vi har utgått från full hd upplösning. Har man mer eller mindre ändras position och storlek av knappen tack vare dessa förhållande variabler.
	float x = Screen.width / 1920f, y = Screen.height/1080f;



	void OnGUI() {
		//Tilldelar det skin som refererades innan.
		GUI.skin = skin;
		//Lägger knappen på 0 lagret på skärmen.
		GUI.depth = 0;
		//En ifsats som både initierar knappen och kollar om det blir tryck på.
		if (GUI.Button (new Rect (Screen.width / 2 -(ScaleUtil.ScaleX(950)) , Screen.height / 2 - (ScaleUtil.ScaleY(150)), ScaleUtil.ScaleX(768), ScaleUtil.ScaleY(109)), "")) {
			//Ändrar det läge som StateManager håller reda på.
			MenuStateHandler.state = MenuStateHandler.States.INTRO;
			//Application.LoadLevel(1);// Laddar in spelet.
		}




	}



}
