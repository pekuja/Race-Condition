using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	public AudioSource introSource;
	public AudioSource loopSource;

    // Start is called before the first frame update
    void Start()
    {
		introSource.PlayScheduled(0.1);

		double introDuration = (double)introSource.clip.samples / introSource.clip.frequency;

		loopSource.PlayScheduled(0.1 + AudioSettings.dspTime + introDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
