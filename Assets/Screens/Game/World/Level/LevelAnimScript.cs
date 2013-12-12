using UnityEngine;
using System.Collections;

public class LevelAnimScript : MonoBehaviour {
	
	private bool open = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OpenDoor() {
		if (!open) {
			open = true;
			animation.Play("Open",PlayMode.StopAll);
		}
	}
}
