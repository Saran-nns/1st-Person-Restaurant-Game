using UnityEngine;
using System.Collections;

public class interactionScript : MonoBehaviour {

	public float interactDistance=3f;


	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit,interactDistance))
			{
				if (hit.collider.CompareTag ("DoorToilet"))
				{
					hit.collider.transform.parent.GetComponent<DoorScript> ().ChangeDoorState ();
			    }

		    }

	    }
   }
}
