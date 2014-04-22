using UnityEngine;
using System.Collections;

public class StoryMovieScript : MonoBehaviour {

	float scaleX,scaleY;
	// Use this for initialization
	void Start () {
		scaleX = Screen.width / 1920f;
		scaleY = Screen.height / 1080f;
		if (scaleX < 1 || scaleY < 1) {
		transform.localScale = new Vector3 (transform.localScale.x * scaleX, transform.localScale.y * scaleY, transform.localScale.z * scaleY);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




}
