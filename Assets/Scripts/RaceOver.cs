using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceOver : MonoBehaviour
{
	RaceTimer raceTimer;

	TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
		raceTimer = FindObjectOfType<RaceTimer>();

		text = GetComponent<TextMeshProUGUI>();
		text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (raceTimer.timeLeft <= 0.0f)
		{
			text.enabled = true;
		}
    }
}
