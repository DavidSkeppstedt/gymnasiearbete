using UnityEngine;
using System.Collections;

public class ScaleUtil : MonoBehaviour
{
	public static float SCALEX = Screen.width / 1920f, SCALEY = Screen.height/1080f;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	public static float ScaleX(float x) {
		return x * SCALEX;
	} 
	
	public static float ScaleY(float y) {
		return y * SCALEY;
	} 




}

