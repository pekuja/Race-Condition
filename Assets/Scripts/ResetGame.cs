using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}


	public void OnReset(InputAction.CallbackContext context)
	{
		SceneManager.LoadScene(0);
	}
}
