using UnityEngine;
using System.Collections;

public class ReturnToMenu : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Return)) {
			Application.LoadLevel(0); //Ladda menyn
			Screen.lockCursor = false; //släpp musen
			Screen.showCursor = false; // visa musen-
		}
	}
}
