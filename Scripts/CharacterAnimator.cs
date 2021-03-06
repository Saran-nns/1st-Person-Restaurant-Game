using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour {

	public CharacterController controller;
	public Animator animator;
	private int speedid;

	void Start () {
		animator = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
		speedid = Animator.StringToHash("Speed");
	}

	void Update () {
		float speed = controller.velocity.magnitude;
		animator.SetFloat(speedid, speed);
	}
}