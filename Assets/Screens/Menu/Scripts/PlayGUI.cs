﻿using UnityEngine;
using System.Collections;

public class PlayGUI : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {
		GUI.skin = skin;
		GUI.depth = 0;
		if (GUI.Button (new Rect (Screen.width / 2 -950 , Screen.height / 2 - 150, 768, 109), "")) {
			MenuStateHandler.state = MenuStateHandler.States.MENU;
			Application.LoadLevel(1);
		}




	}



}
