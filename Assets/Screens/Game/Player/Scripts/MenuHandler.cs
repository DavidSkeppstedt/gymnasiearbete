using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour
{
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.Escape)) {
				Screen.lockCursor = true;
				Screen.showCursor = true;
				Application.LoadLevel(0);			
			}
			
		}
}

