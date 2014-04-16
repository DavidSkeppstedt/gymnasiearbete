using UnityEngine;
using System.Collections;

public class ScreenScale : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		transform.localScale = new Vector3(width, 0.1f, height);



		}	
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}

