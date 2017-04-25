using UnityEngine;
using System.Collections;

public class NavChar : MonoBehaviour 
{
	NavMeshAgent agent;
	public Transform target;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update ()
	{
		agent.SetDestination (target.position);

	}
}
