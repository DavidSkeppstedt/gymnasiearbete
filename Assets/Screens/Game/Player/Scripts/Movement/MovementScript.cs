using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class MovementScript : MonoBehaviour {
	
	
	//Declare variabler
	private CharacterController cc;
	private Camera camera;
	public float moveSpeed = 45f;
	public float mouseSensitivty = 5f;
	
	public float upDownRange = 60.0f;
	private float verticalRotation = 0;
	
	
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
	
		
		
		rotateHead();
		cc.Move(transform.TransformDirection(checkKeyInput())*moveSpeed * Time.deltaTime);
		
		
		
	}
	private void rotateHead() {
		transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X")*mouseSensitivty,0));
		
		//Inverted because it will be interted otherwise :P
		verticalRotation -=Input.GetAxis("Mouse Y") * mouseSensitivty;
		verticalRotation  = Mathf.Clamp(verticalRotation,-upDownRange,upDownRange);
		camera.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);
		
		
		
		
		
		
		
		
		
	}
	
	private Vector3 checkKeyInput() {
		
		
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		float y = Physics.gravity.y;
		
		return new Vector3(x,y,z);
		
	}
	
	
	
}
