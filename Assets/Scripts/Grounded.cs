using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
	public bool isGrounded = false;

	public Vector3 groundNormal = Vector3.up;

	public int numContactPoints = 0;

	new public Collider collider;

	private void Start()
	{
		collider = GetComponent<Collider>();
	}
}
