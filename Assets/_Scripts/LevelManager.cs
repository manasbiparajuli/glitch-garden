// Handle Game Manager
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] float autoLoadNextLevelAfterSeconds;

	private void Start()
	{
		if (autoLoadNextLevelAfterSeconds <= 0)
		{
			Debug.Log("Level auto load disabled, use positive value");
		}
		else
		{
			Invoke("LoadNextScene", autoLoadNextLevelAfterSeconds);
		}
	}

	// load level based on level names
	public void LoadLevel (string name)
	{
		SceneManager.LoadScene(name);
	}

	public void LoadNextScene()
	{
		// Load next scene based on current scene index
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	// Load Welcome screen
	public void LoadStartScene()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}