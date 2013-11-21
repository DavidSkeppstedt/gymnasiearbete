using UnityEngine;
using System.Collections;

public class Anim : MonoBehaviour {
	
	float p = -1f;
	private bool zoom = false;
	private bool sprint = false;
	// Use this for initialization
	void Start () {
	//animation.Play("Fire");
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (Input.GetButton("Fire1")) {
			
			if (zoom) {
				animation.Play("ZoomFire",PlayMode.StopAll);
			}else {
				animation.Play("Fire",PlayMode.StopAll);
				Camera.main.transform.Rotate(new Vector3(0,0,0.50f*p));
				p *=-1; 		
					
			}
			
			
		
		}else if (!Input.anyKey) {
			animation.Play("Idle",PlayMode.StopAll);
			
		}
		
		if (Input.GetKeyDown(KeyCode.LeftShift) ){
			sprint =true;
			animation.Play("Sprinting",PlayMode.StopAll);
		
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
				if (sprint) {
				animation.Play("Idle",PlayMode.StopAll);
				sprint = false;
				}
		}
		
		
		
		if (Input.GetButtonDown("Right")) {
			zoom = true;
			animation.Play("Zoom",PlayMode.StopAll);
		}
		
		
		if (Input.GetButtonUp("Right")) {
			if (zoom) {
				animation.Play("Idle",PlayMode.StopAll);
				zoom = false;
			}
		}
	
	}
}
