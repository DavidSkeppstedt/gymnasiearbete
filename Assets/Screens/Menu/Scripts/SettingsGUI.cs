using UnityEngine;
using System.Collections;

public class SettingsGUI : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {
		GUI.skin = skin;
		GUI.depth = 0;
		if (GUI.Button (new Rect (Screen.width / 2 -950 , Screen.height / 2 - 60, 768, 109), "")) {
			//Application.LoadLevel(1);
		}




	}



}
