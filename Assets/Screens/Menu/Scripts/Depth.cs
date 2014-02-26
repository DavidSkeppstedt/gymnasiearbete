using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {
	public int depth;
	public Texture aTexture;

	private float width = ScaleUtil.ScaleX(1711);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
			GUI.depth = depth;
			
		GUI.DrawTexture(new Rect(Screen.width/2 - width/2 , transform.position.y, ScaleUtil.ScaleX(1711), ScaleUtil.ScaleY(243)), aTexture);
	}

}
