using UnityEngine;
using System.Collections;

public class Anim : MonoBehaviour {
	
	float p = -1f;
	// Use this for initialization
	void Start () {
	//animation.Play("Fire");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) {
			animation.Play("Fire",PlayMode.StopAll);
			Camera.main.transform.Rotate(new Vector3(0,0,0.50f*p));
			p *=-1; 
		}else if (!Input.anyKey) {
			animation.Play("Idle",PlayMode.StopAll);
			
		}
		
		if (Input.GetKey(KeyCode.R) ){
			animation.Play("Sprinting",PlayMode.StopAll);
		}
		
		if (Input.GetButton("Right")) {
			animation.Play("Zoom",PlayMode.StopAll);
		}
	
	}
}
