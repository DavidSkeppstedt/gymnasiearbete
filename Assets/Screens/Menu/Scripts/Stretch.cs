using UnityEngine;
using System.Collections;

public class Stretch : MonoBehaviour {

	public Texture aTexture;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.depth = 1;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), aTexture);


	}


}
