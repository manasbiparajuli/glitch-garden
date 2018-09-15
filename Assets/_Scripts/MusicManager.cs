using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	[SerializeField] AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		int level = SceneManager.GetActiveScene().buildIndex;
		AudioClip thisLevelMusic = levelMusicChangeArray[level];

		if (thisLevelMusic)
		{
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void SetVolume (float volume)
	{
		audioSource.volume = volume;
	}
}