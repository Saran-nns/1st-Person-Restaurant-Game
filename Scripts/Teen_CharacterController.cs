using UnityEngine;
using System.Collections;

public class Teen_CharacterController : MonoBehaviour {


	public float inputDelay = 0.1f;  // To create dead zone(Time interval between input and output)
	public float forwardVel = 12;    // Forward Velocity; 
	public float rotateVel = 100;    // Rotation Speed

	// Private members

	Quaternion targetRotation;      // Responsible for the next rotation that the agent trying to turn.
	Rigidbody rBody;                // Rigid body reference
	float forwardInput, turnInput;  // Inputs to the agent

	//Define the property for targetRotation that access Target rotation from the Camera controller

	public Quaternion TargetRotation {
		get {
			return targetRotation;
		}
	}

	/// Methods we are going to use or in other words Skeleton of the script.

	void Start()
	{
		targetRotation = transform.rotation;         // Set the targetRotation as initial or current rotation transform
		if (GetComponent<Rigidbody> ())              // Check whether the Character has Rigid body component attached, else log error.
			rBody = GetComponent<Rigidbody> ();      // Get the Rigid body component
		else
			Debug.LogError ("The character needs a rigidbody");
		forwardInput = turnInput = 0;

	}
	void GetInput()
	{
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	// To effect changes every frame with the Update and FixedUpdate functions 

	void Update()      // Called every frame for moving non-physics objects e.g Camera
	{
		GetInput ();  // Gather input for the update function
		Turn();

	}

	//Update physics object based components

	void FixedUpdate()
	{
		Run ();                          //Update rigid body's velocity

	}
	void Run()
	{
		if (Mathf.Abs (forwardInput) > inputDelay) {
			//Move
			rBody.velocity = transform.forward * forwardInput * forwardVel;
		} else {
			//zero Velocity
			rBody.velocity = Vector3.zero;

		}
	}
	void Turn()
	{
		if (Mathf.Abs (turnInput) > inputDelay) 
	{
		
			targetRotation*=Quaternion.AngleAxis(rotateVel*turnInput*Time.deltaTime, Vector3.up);
			transform.rotation=targetRotation;

	}
}
}