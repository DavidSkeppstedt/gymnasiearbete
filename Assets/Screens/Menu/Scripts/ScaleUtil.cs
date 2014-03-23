using UnityEngine;
using System.Collections;

public class ScaleUtil : MonoBehaviour
{	
	//En klass som gör skalningsjobbet för knappar och andra UI element enklare.
	//här fås förhållandet fram för olika skärmar.
	public static float SCALEX = Screen.width / 1920f, SCALEY = Screen.height/1080f;

	//Här är getter metoder som returnerar den skalade storleken på en knapp.
	public static float ScaleX(float x) {
		return x * SCALEX;
	} 
	
	//Här är getter metoder som returnerar den skalade storleken på en knapp.
	public static float ScaleY(float y) {
		return y * SCALEY;
	} 




}

