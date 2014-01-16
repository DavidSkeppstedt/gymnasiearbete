using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public GameObject map;
	public string open;
	public string close;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name =="PlayerObject") {
			map.animation.PlayQueued (open);
		}

	}
	void OnTriggerExit(Collider other) {
		if (other.name =="PlayerObject") {
			map.animation.PlayQueued(close);
		}

	}



}
