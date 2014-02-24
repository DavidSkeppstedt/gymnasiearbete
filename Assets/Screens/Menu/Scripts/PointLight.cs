using UnityEngine;
using System.Collections;

public class PointLight : MonoBehaviour {

	public GameObject pointlight;

	private float time = 1;
	private float counter = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (counter < time) {
			counter += Time.deltaTime;

		} else {



			//Do stuff
			
			if (pointlight.activeSelf) {
				pointlight.SetActive(false);
			}else {
				pointlight.SetActive(true);
			}
			
			counter = 0;

		}


	
	}
	





}
