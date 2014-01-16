using UnityEngine;
using System.Collections;

public class AnimationGun : MonoBehaviour {

	public string fireAnim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Fire1")) {
			animation.Play(fireAnim,PlayMode.StopAll);
		}


	
	}
}
