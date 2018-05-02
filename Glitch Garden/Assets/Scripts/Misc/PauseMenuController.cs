using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    
    private static GameObject pauseCanvas = null;

	private void Start()
	{
        pauseCanvas = GameObject.Find("Pause Canvas");
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Cannot find 'Pause Canvas'");
        }
	}

	public void SetAllGameObjectsState(bool toActive)
    {
		Time.timeScale = (toActive) ? 1 : 0;

		pauseCanvas.SetActive(!toActive);

    }
}
