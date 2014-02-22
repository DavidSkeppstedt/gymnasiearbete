using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
	SimpleAi aiScript;
	bool enemyShoot = false;

	LineRenderer line;
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;
		aiScript = transform.parent.GetComponent<SimpleAi> ();

	}
	
	// Update is called once per frame
	void Update () {

		enemyShoot = aiScript.isAttacking ();

		if (enemyShoot) {
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
		
		}
	
	}

	IEnumerator FireLaser()
	{
		line.enabled = true;
		
		while(enemyShoot)
		{
			Ray ray = new Ray(transform.position, getTarget());
			RaycastHit hit;
			
			line.SetPosition(0, ray.origin);
			
			if(Physics.Raycast(ray, out hit, 100))
			{
				line.SetPosition(1, hit.point);

			}
			else
				line.SetPosition(1, ray.GetPoint(100));
			
			yield return null;
		}
		
		line.enabled = false;
	}
	

	Vector3 getTarget() {
		return new Vector3 (transform.forward.x, transform.forward.y-0.05f, transform.forward.z);



	}





}
