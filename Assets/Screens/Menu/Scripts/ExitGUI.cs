using UnityEngine;
using System.Collections;

public class ExitGUI : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {
		GUI.skin = skin;
		GUI.depth = 0;
		if (GUI.Button (new Rect (Screen.width / 2 -ScaleUtil.ScaleX(950) , Screen.height / 2 + ScaleUtil.ScaleY(110), ScaleUtil.ScaleX(768), ScaleUtil.ScaleY(109)), "")) {
			Application.Quit();
		}




	}



}
