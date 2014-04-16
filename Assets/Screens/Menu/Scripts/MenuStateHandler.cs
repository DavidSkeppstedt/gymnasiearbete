using UnityEngine;
using System.Collections;

public class MenuStateHandler : MonoBehaviour {
	
	//Deklarerar en typ för att hålla reda på vilket beteende som skall ske på skärmen
	public enum States{
		INTRO,
		MENU,
		OPTIONS,
		ABOUT,
	}

	public GameObject movie;


	//Även en statics variabel som används för musinställningar.
	public static float MOUSE_SENS = 0.5f;

	public static States state;
	
	void Awake() {
		//Gör så att scriptet inte laddas ur minnet vid byte vid scen , detta för att behålla viktiga variabler.
		DontDestroyOnLoad (transform.gameObject);
		state = States.MENU;
		Screen.showCursor = true;
	}

	void Start() {
		Screen.showCursor = true;
		Screen.lockCursor = false;
	}


	void Update() {
		if (state == States.INTRO) {
			if (GameObject.Find("GUI") != null) {
				GameObject.Find("GUI").SetActive(false);
				GameObject.Find("Movie").SetActive(false);
				GameObject.Find("Title").SetActive(false);
				Camera.main.audio.Stop();
			}
			if (movie != null) {
				movie.SetActive(true);
			}
		}


		if (Input.anyKeyDown) {
			if (state == States.INTRO) {
				state = States.MENU;
				Application.LoadLevel(1);
			}
		}


	}



	
}
