using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2 -50 , Screen.height / 2 + 10, 100, 40), "Play")) {
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (Screen.width / 2 -50, Screen.height / 2 + 60, 100, 40), "Quit")) {
			Application.Quit();
		}



	}



}
