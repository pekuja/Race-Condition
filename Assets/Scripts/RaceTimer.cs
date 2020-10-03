using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceTimer : MonoBehaviour
{
	public float initialTime = 30.0f;
	public float checkpointBonus = 3.0f;

	public float timeLeft;

	TextMeshProUGUI text;

	public void CheckpointReached()
	{
		if (timeLeft > 0.0f)
		{
			timeLeft += checkpointBonus;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		timeLeft = initialTime;

		text = GetComponent<TextMeshProUGUI>();

		text.text = "⏱" + Mathf.CeilToInt(timeLeft);
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		timeLeft -= Time.fixedDeltaTime;

		if (timeLeft <= 0.0f)
		{
			text.enabled = false;
		}
		else
		{
			text.text = "⏱" + Mathf.CeilToInt(timeLeft);
		}
	}
}
