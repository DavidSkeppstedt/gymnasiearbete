using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class MovementScript : MonoBehaviour {
	
	
	//Declare variabler
	private CharacterController cc;
	protected Camera camera;
	public float moveSpeed = 4.8f;
	public float mouseSensitivty = 225f;
	
	//Variabler för musrörelse.
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
		cc = GetComponent<CharacterController>(); // får tillgång till rörelse modulen.

		camera = GetComponentInChildren<Camera>(); // The main fps camera får tillgång till kameran
		//Hide the cursor
		Screen.showCursor = false; // 
		Screen.lockCursor = true; // låster muspekaren
		 // init olika enheter som används för att återställa en duckning sen.
		oldR =cc.radius; 
		oldH = cc.height;
		oldCY = Camera.main.transform.position.y;
		mouseSensitivty *= MenuStateHandler.MOUSE_SENS; //Ställer in muskänsligheten efter de inställningar spelaren har möjlighet att göra under spelets gångs och i menyn.

		
	}
	
	// Update is called once per frame
	void Update () {
		//Hämtar den muskänsligheten som spelaren vill använda.
		mouseSensitivty = 225*MenuStateHandler.MOUSE_SENS;


		rotateHead();


		//ANvänd CC för att röra sig.
		cc.Move(checkKeyInput()* Time.deltaTime);
		crouch(); // Metod för att kontrollera om spelaren vill huka sig.

	}



		



	private void crouch(){
		if (Input.GetButton("Crouch")) { // Om huka knappen är intryck
			//gör så att man blir mindre och kortarte
			cc.height = 1.29f; //
			cc.radius = 0.5f;
			//Camera.main.transform.localPosition = new Vector3(0,-.7f,0);

		}else { // Bör deb släpps, återsller man alla värden.
			if (cc.height != oldH) {
			cc.height = oldH;
			cc.radius = oldR;
			//Camera.main.transform.localPosition = new Vector3(0,0,0);
			transform.position = new Vector3(transform.position.x,transform.position.y +0.105f,transform.position.z);
			}

		}



	}

	//Roterar kameran efter spelarens musrörelser.
	private void rotateHead() {
		transform.Rotate(new Vector3(0,(Input.GetAxis("Mouse X")*mouseSensitivty)*Time.deltaTime,0));
		
		//Inverted because it will be inverted otherwise :P
		verticalRotation -=(Input.GetAxis("Mouse Y") * mouseSensitivty)*Time.deltaTime;
		verticalRotation  = Mathf.Clamp(verticalRotation,-upDownRange,upDownRange);
		camera.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);
	
	}
	//Kollar vilka knappar som trycks in och hämtar olika rörelser variabler om rörelseknappar trycks in, detta för att sen kunna returnera
	//deb riktningsvektor som CCn vill ha för att röra spelaren.
	private Vector3 checkKeyInput() {
		if (cc.isGrounded) {
			moveVector = new Vector3 (
				Input.GetAxis("Horizontal")*moveSpeed,
				0,
				Input.GetAxis("Vertical")*moveSpeed
				);

			moveVector = transform.TransformDirection(moveVector);
			//Ger en knuff uppåt om spelare trycker på hopp.
			if (Input.GetButtonDown("Jump")) {
				moveVector.y = 4;

				
			}
			
		}



	//Låter Spelaren påvekeras av gravitationen.
		moveVector.y += Physics.gravity.y *Time.deltaTime;
		
		return moveVector;
		
	}
	
	
	
}