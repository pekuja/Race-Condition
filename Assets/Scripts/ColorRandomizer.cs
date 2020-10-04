using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
	public bool skinTone = false;

    // Start is called before the first frame update
    void Start()
	{
		Color randomColor;
		if (skinTone)
		{
			randomColor = Color.HSVToRGB(Random.Range(0.0f, 0.14f), Random.Range(0.2f, 0.8f), Random.Range(0.25f, 1.0f));
		}
		else
		{
			randomColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		}

		foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>())
		{
			renderer.material.color = randomColor;
		}
		

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
