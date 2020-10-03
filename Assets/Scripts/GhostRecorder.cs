using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
	PlayerCar car;
	new Rigidbody rigidbody;

	public struct GhostSample
	{
		public Vector3 carPosition;
		public Quaternion carOrientation;
	};

	public List<GhostSample> ghostData;

	public GhostPlayback ghostCarPrefab;

	public float ghostSpawnDelay = 5.0f;

	private float nextGhostSpawn;

	// Start is called before the first frame update
	void Start()
    {
		car = GetComponent<PlayerCar>();
		rigidbody = GetComponent<Rigidbody>();

		ghostData = new List<GhostSample>();

		nextGhostSpawn = ghostSpawnDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		GhostSample sample = new GhostSample
		{
			carPosition = rigidbody.position,
			carOrientation = rigidbody.rotation
		};

		ghostData.Add(sample);

		nextGhostSpawn -= Time.fixedDeltaTime;

		if (nextGhostSpawn <= 0.0f)
		{
			Instantiate<GhostPlayback>(ghostCarPrefab, ghostData[0].carPosition, ghostData[0].carOrientation);

			nextGhostSpawn += ghostSpawnDelay;
		}
	}

	public GhostSample GetFrameSample(int frame)
	{
		frame = Mathf.Clamp(frame, 0, ghostData.Count - 1);

		return ghostData[frame];
	}
}
