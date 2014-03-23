using UnityEngine;
using System.Collections;

public class MoviePlay : MonoBehaviour {
	
	//En referens till den film som skall spelas upp.
	public MovieTexture movieTex;
	float heigth,width;

	void Awake() {
		//Ställer in de uppgifter som krävs för att filmen skall spelas och loopas.
		movieTex = renderer.material.mainTexture as MovieTexture;
		movieTex.loop = true;
		movieTex.Play ();
	}


}
