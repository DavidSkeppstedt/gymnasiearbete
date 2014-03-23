using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {
	//Detta skript används för att kunna skapa roterande pickups som är placerade runt om i världen
	//Spelare skall också då kunna ta upp den och får den till sin inverntory.
	public int index;
	private Vector3 rotationVector;
	
	// Use this for initialization
	void Start () {
		rotationVector = new Vector3(0,30,0);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		gameObject.transform.Rotate(rotationVector * Time.deltaTime);//roterar GameObjectet
	
	}
	//När spelaren kolliderar med pickup.
	void OnTriggerEnter(Collider other) {
//		Debug.Log("index" + index);
        
		other.SendMessage("pickUp",index);
		Destroy(this.gameObject);
		
		
    }
	
	
}
