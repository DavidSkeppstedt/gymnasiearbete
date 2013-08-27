using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class MovementScript : MonoBehaviour {
	
	
	//Declare variabler
	private CharacterController cc;
	private Camera camera;
	public float moveSpeed = 45f;
	// Use this for initialization
	void Start () {
		//Init the variables
		cc = GetComponent<CharacterController>();
		camera = GetComponentInChildren<Camera>(); // The main fps camera
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	//This method is called once every fixed frame. Used for physics calculation
	void FixedUpdate() {
	
		
		
		
		cc.Move(checkKeyInput()*moveSpeed * Time.deltaTime);
		
		
		
	}
	
	
	private Vector3 checkKeyInput() {
		
		
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		float y = Physics.gravity.y;
		
		return new Vector3(x,y,z);
		
	}
	
	
	
}
