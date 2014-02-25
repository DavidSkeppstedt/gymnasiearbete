using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class MovementScript : MonoBehaviour {
	
	
	//Declare variabler
	private CharacterController cc;
	protected Camera camera;
	public float moveSpeed = 4.8f;
	public float mouseSensitivty = 225f;
	
	
	public float upDownRange = 60.0f;
	private float verticalRotation = 0;
	private Vector3 moveVector;


	private float oldR;
	private float oldH;
	private float oldCY;
	//private bool canJump = true;
	// Use this for initialization
	void Start () {
		//Init the variables
		cc = GetComponent<CharacterController>();

		camera = GetComponentInChildren<Camera>(); // The main fps camera
		//Hide the cursor
		Screen.showCursor = false;
		Screen.lockCursor = true;
		oldR =cc.radius; 
		oldH = cc.height;
		oldCY = Camera.main.transform.position.y;
		mouseSensitivty *= MenuStateHandler.MOUSE_SENS;

		
	}
	
	// Update is called once per frame
	void Update () {

		mouseSensitivty = 225*MenuStateHandler.MOUSE_SENS;


		rotateHead();


		
		cc.Move(checkKeyInput()* Time.deltaTime);
		crouch();

	}



		



	private void crouch(){
		if (Input.GetButton("Crouch")) {
			
			cc.height = 1.29f;
			cc.radius = 0.5f;
			//Camera.main.transform.localPosition = new Vector3(0,-.7f,0);

		}else {
			if (cc.height != oldH) {
			cc.height = oldH;
			cc.radius = oldR;
			//Camera.main.transform.localPosition = new Vector3(0,0,0);
			transform.position = new Vector3(transform.position.x,transform.position.y +0.105f,transform.position.z);
			}

		}



	}


	private void rotateHead() {
		transform.Rotate(new Vector3(0,(Input.GetAxis("Mouse X")*mouseSensitivty)*Time.deltaTime,0));
		
		//Inverted because it will be inverted otherwise :P
		verticalRotation -=(Input.GetAxis("Mouse Y") * mouseSensitivty)*Time.deltaTime;
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

			if (Input.GetButtonDown("Jump")) {
				moveVector.y = 4;

				
			}
			
		}




		moveVector.y += Physics.gravity.y *Time.deltaTime;
		
		return moveVector;
		
	}
	
	
	
}