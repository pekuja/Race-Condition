using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Rigidbody target;

	private Vector3 offset;

	private float yRotation;

	private Vector3 currentOffset;
	private Vector3 currentPosition;
	private Vector3 currentUp;

	private Vector3 filteredVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
		offset = target.transform.InverseTransformVector(transform.position - target.position);
		currentOffset = offset;

		currentPosition = target.position;
		currentUp = target.transform.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		filteredVelocity = Vector3.Lerp(filteredVelocity, target.velocity, 0.1f);

		bool inReverse = Vector3.Dot(filteredVelocity, target.transform.forward) < 0.0f;

		Vector3 forward = (filteredVelocity.magnitude < 0.1f ? target.transform.forward : (inReverse ? -filteredVelocity.normalized : filteredVelocity.normalized));

		Vector3 targetOffset = forward * offset.z + Vector3.up * offset.y + Vector3.Cross(forward, Vector3.up).normalized * offset.x;

		currentOffset = Vector3.Lerp(currentOffset, targetOffset, 0.1f);
		transform.position = target.position + currentOffset;

		currentPosition = Vector3.Lerp(currentPosition, target.position + (inReverse ? Vector3.zero : filteredVelocity * 1.0f), 0.1f);

		currentUp = Vector3.Lerp(currentUp, forward, 0.1f);

		transform.LookAt(currentPosition, currentUp);
    }
}
