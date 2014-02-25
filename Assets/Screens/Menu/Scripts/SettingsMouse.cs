using UnityEngine;
using System.Collections;

public class SettingsMouse : MonoBehaviour {

	public static float hValue = 0.5f;
	public GUISkin skin;
	float scaleX = Screen.width/1920f;
	float scaleY = Screen.height/1080f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Settings")) {
			if (MenuStateHandler.state != MenuStateHandler.States.OPTIONS) {
				MenuStateHandler.state = MenuStateHandler.States.OPTIONS;
				Screen.lockCursor = false;
				Screen.showCursor = true;
			}else {
				MenuStateHandler.state = MenuStateHandler.States.MENU;
				if (Application.loadedLevel == 1)
					Screen.lockCursor = true;

			}
		}


	}


	void OnGUI() {
		GUI.skin = skin;
		GUI.depth = 0;
	if (MenuStateHandler.state == MenuStateHandler.States.OPTIONS) {
		
		GUI.BeginGroup(new Rect(Screen.width / 2 + 200, Screen.height / 2 - 75, 400, 150));
			GUI.Box(new Rect(0,0,400,150),"Settings");

			GUI.Label(new Rect(150, 25, 300, 20), "Mouse Sensitivty");
			MenuStateHandler.MOUSE_SENS = hValue = GUI.HorizontalSlider(new Rect(155,50, 100, 30), hValue, 0.1F, 1.0F);	
			GUI.Label(new Rect(190, 65, 100, 20), ""+Mathf.Round(hValue*450f));
		GUI.EndGroup();

	}





	}




}
