using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
	//Referens till ett annat skript som skall kontrollera saker.
	SimpleAi aiScript;
	//Ett bolvärde som kollar om AI skjuter eller inte.
	bool enemyShoot = false;
	//Själva laser objektet som skall renderas.
	LineRenderer line;
	// Use this for initialization
	void Start () {
		//Inställningar och initiering för laser objektet sker.
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;
		aiScript = transform.parent.GetComponent<SimpleAi> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Ger det värde som stämmer överens på den enskilda fienden
		enemyShoot = aiScript.isAttacking ();
		//Om ovan värde är sant så ska Ai skwjuta laser.
		if (enemyShoot) {
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
		
		}
	
	}

	IEnumerator FireLaser()
	{
		//Sätter på lasern
		line.enabled = true;
		//Så länge Ai skjuter
		while(enemyShoot)
		{
			//Kasta en stråle mot spelaren.
			Ray ray = new Ray(transform.position, getTarget());
			RaycastHit hit;
			//Sätt utgångspunkten för lasern från Ain.
			line.SetPosition(0, ray.origin);
			//Om lasern träffar
			if(Physics.Raycast(ray, out hit, 100))
			{
				//sätt slutposition för laser.
				line.SetPosition(1, hit.point);

			}
			else
				//Om den missar, låt lasern fortsätta 100 världsenheter i luften
				line.SetPosition(1, ray.GetPoint(100));
			
			yield return null;
		}
		
		line.enabled = false;
	}
	

	Vector3 getTarget() {
		//Returnerar Vector positionen av spelaren i världsrymden.
		return new Vector3 (transform.forward.x, transform.forward.y-0.05f, transform.forward.z);



	}





}
