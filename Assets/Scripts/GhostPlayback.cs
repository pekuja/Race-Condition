using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayback : MonoBehaviour
{
	int playbackFrame = 0;

	GhostRecorder recorder;
	new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
		recorder = FindObjectOfType<GhostRecorder>();
		rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		GhostRecorder.GhostSample sample = recorder.GetFrameSample(playbackFrame);

		rigidbody.position = sample.carPosition;
		rigidbody.rotation = sample.carOrientation;

		++playbackFrame;
    }
}
