using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	//Om något kolliderar här så är det game over.
	void OnTriggerEnter(Collider other) {
		//The Game is over
		Application.LoadLevel (2);

	}
}
