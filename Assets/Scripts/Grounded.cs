using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
	public bool isGrounded = false;

	new public Collider collider;

	private void Start()
	{
		collider = GetComponent<Collider>();
	}
}
