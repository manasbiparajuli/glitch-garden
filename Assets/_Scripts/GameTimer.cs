using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	private Slider slider;
	[SerializeField] float levelSeconds = 10;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private bool isEndOfLevel = false;
	private GameObject winLabel;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find("You Win");
		FindYouwin();
		winLabel.SetActive(false);
	}

	private void FindYouwin()
	{
		if (!winLabel)
		{
			Debug.LogWarning("Please create You Win Object");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool isTimeUp = (Time.timeSinceLevelLoad >= levelSeconds);

		if (isTimeUp && !isEndOfLevel)
		{
			HandleWinCondition();
		}
	}

	private void HandleWinCondition()
	{
		DestroyAllTaggedObjects();
		audioSource.Play();
		winLabel.SetActive(true);
		Invoke("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	private void DestroyAllTaggedObjects()
	{
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
			
		foreach (GameObject taggedObject in taggedObjectArray)
		{
			Destroy(taggedObject);
		}
	}

	void LoadNextLevel()
	{
		levelManager.LoadNextScene();
	}
}
