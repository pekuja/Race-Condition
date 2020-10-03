using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackProgress : MonoBehaviour
{
	public int nextCheckpoint = 0;

	int lastCheckpoint = 0;

    // Start is called before the first frame update
    void Start()
    {
		Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

		foreach (Checkpoint cp in checkpoints)
		{
			if (cp.checkpointNumber > lastCheckpoint)
			{
				lastCheckpoint = cp.checkpointNumber;
			}
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		Checkpoint cp = other.GetComponent<Checkpoint>();

		if (cp && cp.checkpointNumber == nextCheckpoint)
		{
			if (nextCheckpoint == lastCheckpoint)
			{
				nextCheckpoint = 0;
			}
			else
			{
				++nextCheckpoint;
			}
		}
	}
}
