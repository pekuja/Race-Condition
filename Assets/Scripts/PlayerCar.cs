using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCar : MonoBehaviour
{
	new Rigidbody rigidbody;

	float steer = 0.0f;
	float accelerate = 0.0f;
	float reverse = 0.0f;
	float brake = 0.0f;

	public float maxAcceleration = 100.0f;
	public float maxReverseAcceleration = 100.0f;
	public float maxSteer = 100.0f;
	public float maxBrake = 100.0f;

	public float maxSpeed = 100.0f;
	public float maxReverseSpeed = 50.0f;

	public float turningForce = 4.0f;
	public float sideSlipForce = 1.0f;
	public float forwardFrictionForce = 10.0f;

	public float sideSlipAngle = 30.0f;

	public float aerodynamicsForce = 10.0f;

	public Transform frontLeftWheel;
	public Transform frontRightWheel;
	public Transform backLeftWheel;
	public Transform backRightWheel;

	RaceTimer raceTimer;
	Countdown countdown;

	// Start is called before the first frame update
	void Start()
    {
		rigidbody = GetComponent<Rigidbody>();

		raceTimer = FindObjectOfType<RaceTimer>();
		countdown = FindObjectOfType<Countdown>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (raceTimer.timeLeft <= 0.0f || countdown.timeLeft > 0.0f)
		{
			return;
		}

		Transform[] wheels = { frontLeftWheel, frontRightWheel, backLeftWheel, backRightWheel };

		foreach (Transform wheel in wheels)
		{
			Vector3 velocity = rigidbody.GetPointVelocity(wheel.position);

			Vector3 forward = wheel.forward;
			Vector3 right = wheel.right;

			if (Vector3.Dot(forward, rigidbody.transform.forward) < 0.0f)
			{
				forward = -forward;
				right = -right;
			}

			bool isFrontWheel = Vector3.Dot(rigidbody.transform.forward, wheel.position - rigidbody.position) > 0.0f;

			if (isFrontWheel)
			{
				if (Mathf.Abs(wheel.localRotation.eulerAngles.y) > 90 &&
					Mathf.Abs(wheel.localRotation.eulerAngles.y) < 270)
				{
					wheel.localRotation = Quaternion.Euler(0.0f, 180.0f + steer * maxSteer, 0.0f);
				}
				else
				{
					wheel.localRotation = Quaternion.Euler(0.0f, steer * maxSteer, 0.0f);
				}
			}

			Grounded grounded = wheel.GetComponent<Grounded>();

			if (grounded.isGrounded)
			{
				forward = Vector3.Cross(right, grounded.groundNormal);

				//if (!isFrontWheel)
				{
					float accelerationMultiplier = Mathf.Clamp01(1.0f - Vector3.Dot(velocity, forward) / maxSpeed);
					rigidbody.AddForceAtPosition(accelerate * forward * maxAcceleration, wheel.position);
					float reverseMultiplier = Mathf.Clamp01(1.0f - Vector3.Dot(velocity, -forward) / maxReverseSpeed);
					rigidbody.AddForceAtPosition(-reverse * forward * maxReverseAcceleration, wheel.position);
				}

				float forwardFrictionWithBrake = forwardFrictionForce;
				float turningForceWithBrake = turningForce;

				//if (isFrontWheel)
				{
					forwardFrictionWithBrake = Mathf.Lerp(forwardFrictionForce, sideSlipForce, brake);

					//rigidbody.AddForceAtPosition(-brake * velocity, wheel.position);
				}
				//else
				{
					//turningForceWithBrake = Mathf.Lerp(turningForce, forwardFrictionForce, brake);
				}

				float slipAngle = Vector3.Angle(forward, velocity);
				float sideForce = sideForce = Mathf.Lerp(turningForceWithBrake, sideSlipForce, slipAngle / sideSlipAngle);

				float frictionMultiplier = Vector3.Dot(velocity, right);
				rigidbody.AddForceAtPosition(-frictionMultiplier * right * sideForce, wheel.position);

				frictionMultiplier = Vector3.Dot(velocity, forward);
				rigidbody.AddForceAtPosition(-frictionMultiplier * forward * forwardFrictionWithBrake, wheel.position);
			}
		}

		rigidbody.AddForce(-rigidbody.transform.up * rigidbody.velocity.magnitude * aerodynamicsForce);
    }

	public void OnSteer(InputAction.CallbackContext context)
	{
		steer = context.ReadValue<float>();
	}

	public void OnAccelerate(InputAction.CallbackContext context)
	{
		accelerate = context.ReadValue<float>();
	}

	public void OnBrake(InputAction.CallbackContext context)
	{
		brake = context.ReadValue<float>();
	}

	public void OnReverse(InputAction.CallbackContext context)
	{
		reverse = context.ReadValue<float>();
	}
}
