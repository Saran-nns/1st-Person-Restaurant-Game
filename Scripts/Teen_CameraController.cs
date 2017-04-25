using UnityEngine;
using System.Collections;

public class Teen_CameraController : MonoBehaviour {



	public Transform target;
	public float lookSmooth = 0.09f;                           //Approximate time for the camera to refocus (Damp Time)
	public Vector3 offsetFromTarget = new Vector3 (0, 6, -8);
	public float xTilt = 10;

	//Private Members

	Vector3 destination = Vector3.zero;
	Teen_CharacterController charController;
	float rotateVel = 0;

	void Start()
	{
		SetCameraTarget (target);
	}
	void SetCameraTarget(Transform t)
	{
		target = t;

		if (target != null)
		{
			if (target.GetComponent<Teen_CharacterController> ())
			{
				charController = target.GetComponent<Teen_CharacterController> ();
			} 
			else
				Debug.LogError ("Your camera's target needs a character controller ");
		} 
		else
			Debug.LogError ("Your camera needs a target");
	}
	void LateUpdate()
	{
		// Moving
	    MoveToTarget ();
		//Rotating
	    LookAtTarget ();
	}
	void MoveToTarget()
	{
		destination = charController.TargetRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;

}
	void LookAtTarget()
	{
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y,ref rotateVel,lookSmooth);
		tranform.rotation=Quaternion.Euler(tranform.eulerAngles.x, eulerYAngle,0);
	}
}
