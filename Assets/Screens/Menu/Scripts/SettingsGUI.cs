using UnityEngine;
using System.Collections;

public class SettingsGUI : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {
		GUI.skin = skin;
		GUI.depth = 0;
		if (GUI.Button (new Rect (Screen.width / 2 -ScaleUtil.ScaleX(950) , Screen.height / 2 - ScaleUtil.ScaleY(60), ScaleUtil.ScaleX(768), ScaleUtil.ScaleY(109)), "")) {
			//Application.LoadLevel(1);
			if (MenuStateHandler.state != MenuStateHandler.States.OPTIONS) {
				MenuStateHandler.state = MenuStateHandler.States.OPTIONS;
			}else {
				MenuStateHandler.state = MenuStateHandler.States.MENU;
			}
		}




	}



}
