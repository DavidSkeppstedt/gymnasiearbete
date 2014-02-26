using UnityEngine;
using System.Collections;

public class MenuStateHandler : MonoBehaviour {

	public enum States{
		MENU,
		OPTIONS,
		ABOUT,
	}



	public static float MOUSE_SENS = 0.5f;

	public static States state;

	void Awake() {

		DontDestroyOnLoad (transform.gameObject);
		state = States.MENU;

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (state);

	}






	
}
