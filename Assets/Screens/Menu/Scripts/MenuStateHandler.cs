using UnityEngine;
using System.Collections;

public class MenuStateHandler : MonoBehaviour {
	
	//Deklarerar en typ för att hålla reda på vilket beteende som skall ske på skärmen
	public enum States{
		MENU,
		OPTIONS,
		ABOUT,
	}


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






	
}
