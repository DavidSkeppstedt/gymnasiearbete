using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class MovementScript : MonoBehaviour {
	
	
	//Declare variabler
	private CharacterController cc;
	private Camera camera;
	public float moveSpeed = 35f;
	public float mouseSensitivty = 5f;
	
	public float upDownRange = 60.0f;
	private float verticalRotation = 0;
	private Vector3 moveVector;
	
	
	// Use this for initialization
	void Start () {
		//Init the variables
		cc = GetComponent<CharacterController>();
		camera = GetComponentInChildren<Camera>(); // The main fps camera
		//Hide the cursor
		Screen.showCursor = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	//This method is called once every fixed frame. Used for physics calculation
	void FixedUpdate() {
	
		
		
		rotateHead();
		cc.Move(checkKeyInput()* Time.deltaTime);
		
		
		
	}
	private void rotateHead() {
		transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X")*mouseSensitivty,0));
		
		//Inverted because it will be interted otherwise :P
		verticalRotation -=Input.GetAxis("Mouse Y") * mouseSensitivty;
		verticalRotation  = Mathf.Clamp(verticalRotation,-upDownRange,upDownRange);
		camera.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);
		
		
		
		
		
		
		
		
		
	}
	
	private Vector3 checkKeyInput() {
		if (cc.isGrounded) {
			moveVector = new Vector3 (
				Input.GetAxis("Horizontal")*moveSpeed,
				0,
				Input.GetAxis("Vertical")*moveSpeed
				);
			moveVector = transform.TransformDirection(moveVector);
			if (Input.GetButton("Jump")) {
				moveVector.y = 10;
			}
	
		}
		
		moveVector.y += Physics.gravity.y *Time.deltaTime;
		
		return moveVector;
		
	}
	
	
	
}
