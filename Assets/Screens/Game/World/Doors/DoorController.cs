using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public GameObject map;
	public string open;
	public string close;
	public AudioClip open_door,close_door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name =="PlayerObject") {
			map.animation.PlayQueued (open);
			audio.PlayOneShot(open_door);
		}

	}
	void OnTriggerExit(Collider other) {
		if (other.name =="PlayerObject") {
			map.animation.PlayQueued(close);
			audio.PlayOneShot(close_door);
		}

	}



}
