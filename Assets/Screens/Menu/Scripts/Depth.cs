using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {
	public int depth;
	public Texture aTexture;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.depth = depth;
		GUI.DrawTexture(new Rect(transform.position.x, transform.position.y, 1711, 243), aTexture);
	}

}
