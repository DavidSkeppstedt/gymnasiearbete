using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	//Variabler som behövs för att sköta öppning och stängning av dörrar i spelets bana, deras ljud som skall spelas upp och rätt aniimationer.
	public GameObject map;
	public string open;
	public string close;
	public AudioClip open_door,close_door;
	//Om man närmar sig dörren, öppnas den och rätt ljud spelas.
	void OnTriggerEnter(Collider other) {
		if (other.name =="PlayerObject") {
			map.animation.PlayQueued (open);
			audio.PlayOneShot(open_door);
		}

	}
	//Om man går ifrån , stängs dörren  och rätt ljud spelas.
	void OnTriggerExit(Collider other) {
		if (other.name =="PlayerObject") {
			map.animation.PlayQueued(close);
			audio.PlayOneShot(close_door);
		}

	}



}
