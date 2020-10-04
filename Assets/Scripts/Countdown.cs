using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
	public float secondsOfCountdown = 3.0f;

	public string goText = "GO!";

	public float goTextDuration = 2.0f;

	private float timeLeft;

	private TextMeshProUGUI text;

	private PlayerCar player;
	private GhostRecorder ghostRec;

    // Start is called before the first frame update
    void Start()
    {
		timeLeft = secondsOfCountdown;

		text = GetComponent<TextMeshProUGUI>();
		player = FindObjectOfType<PlayerCar>();
		ghostRec = FindObjectOfType<GhostRecorder>();

		player.enabled = false;
		ghostRec.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		timeLeft -= Time.fixedDeltaTime;

		if (timeLeft > 0.0f)
		{
			text.text = "" + Mathf.CeilToInt(timeLeft);
		}
		else if (timeLeft > -goTextDuration)
		{
			if (timeLeft > -Time.fixedDeltaTime)
			{
				RaceTimer timer = FindObjectOfType<RaceTimer>();
				timer.started = true;
				player.enabled = true;
				ghostRec.enabled = true;
			}

			text.text = goText;
		}
		else
		{
			text.enabled = false;
		}
    }
}
