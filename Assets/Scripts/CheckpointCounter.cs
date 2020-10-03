using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointCounter : MonoBehaviour
{
	TextMeshProUGUI text;

	int count = 0;

	// Start is called before the first frame update
	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();

		text.text = "🏁" + count;
	}

	public void CheckpointReached()
	{
		++count;

		text.text = "🏁" + count;
	}
}
