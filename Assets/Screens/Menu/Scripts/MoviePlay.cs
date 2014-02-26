using UnityEngine;
using System.Collections;

public class MoviePlay : MonoBehaviour {

	public MovieTexture movieTex;
	float heigth,width;

	void Awake() {
		movieTex = renderer.material.mainTexture as MovieTexture;
		movieTex.loop = true;
		movieTex.Play ();
	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
