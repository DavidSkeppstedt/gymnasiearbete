﻿using UnityEngine;
using System.Collections;

public class DoorOpenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (HealthScript.killed == 3) {
			Destroy(this.gameObject);
			
		} 
	
	}
}
