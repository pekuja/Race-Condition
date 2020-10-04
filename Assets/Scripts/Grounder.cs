using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounder : MonoBehaviour
{
	Grounded[] grounded;

	int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
		grounded = GetComponentsInChildren<Grounded>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		++counter;
		foreach (Grounded g in grounded)
		{
			g.isGrounded = false;
			g.numContactPoints = 0;
		}
    }

	private void OnCollisionStay(Collision collision)
	{
		ContactPoint[] contacts = new ContactPoint[collision.contactCount];
		collision.GetContacts(contacts);
		foreach (Grounded g in grounded)
		{
			foreach (ContactPoint contact in contacts)
			{
				if (contact.thisCollider == g.collider)
				{
					g.groundNormal = (g.groundNormal * g.numContactPoints + contact.normal) / (g.numContactPoints + 1);
					g.numContactPoints++;
					g.isGrounded = true;

					break;
				}
			}
		}
	}
}
