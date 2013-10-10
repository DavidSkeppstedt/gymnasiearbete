using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {
	
	public int index;
	private Vector3 rotationVector;
	
	// Use this for initialization
	void Start () {
		rotationVector = new Vector3(0,3,0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		gameObject.transform.Rotate(rotationVector);
	
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log("index" + index);
        
		other.SendMessage("pickUp",index);
		Destroy(this.gameObject);
		
		
    }
	
	
}
