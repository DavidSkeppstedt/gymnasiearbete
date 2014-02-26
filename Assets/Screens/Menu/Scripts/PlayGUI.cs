using UnityEngine;
using System.Collections;

public class PlayGUI : MonoBehaviour {
	public GUISkin skin;

	float x = Screen.width / 1920f, y = Screen.height/1080f;



	void OnGUI() {
		GUI.skin = skin;
		GUI.depth = 0;
		if (GUI.Button (new Rect (Screen.width / 2 -(ScaleUtil.ScaleX(950)) , Screen.height / 2 - (ScaleUtil.ScaleY(150)), ScaleUtil.ScaleX(768), ScaleUtil.ScaleY(109)), "")) {
			MenuStateHandler.state = MenuStateHandler.States.MENU;
			Application.LoadLevel(1);
		}




	}



}
