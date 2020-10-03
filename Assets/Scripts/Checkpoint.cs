using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public int checkpointNumber = 0;

	TrackProgress trackProgress;
	new Light light;

	private void Start()
	{
		trackProgress = FindObjectOfType<TrackProgress>();
		light = GetComponentInChildren<Light>();
	}

	private void Update()
	{
		light.enabled = (trackProgress.nextCheckpoint == checkpointNumber);
	}
}
