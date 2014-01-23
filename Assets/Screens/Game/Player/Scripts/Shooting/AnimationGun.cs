using UnityEngine;
using System.Collections;

public class AnimationGun : MonoBehaviour {

	public string fireAnim;
	public string idleAnim;
	public string upAnimation;
	public string downAnimation;
	public string reloadAnimation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetButton ("Fire1")) {

			if (!animation.IsPlaying(reloadAnimation)) {
				animation.Play(fireAnim,PlayMode.StopAll);
			}
		}


		if (Input.GetKey (KeyCode.R)) {
			animation.Play(reloadAnimation,PlayMode.StopAll);
		}

		animation.PlayQueued(idleAnim);
	
	}
}
