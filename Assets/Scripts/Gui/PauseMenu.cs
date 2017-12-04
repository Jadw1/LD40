using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;
	public AudioSource music;

	public Slider gameVolume;
	public Slider musicVolume;

	private bool isPaused = false;
	private bool canUnpause = true;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isPaused) Unpause();
			else Pause();
		}
	}

	public void Pause() {
		if (!pauseMenu.activeInHierarchy) {
			pauseMenu.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0;
			isPaused = true;
		}
	}


	public void Unpause() {
		if (!canUnpause) return;

		if (pauseMenu.activeInHierarchy) {
			pauseMenu.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1;
			isPaused = false;
		}
	}

	public void setCanUnpause(bool canUnpause) {
		this.canUnpause = canUnpause;
	}

	public void OnButtonResume() {
		if (isPaused) Unpause();
	}

	public void OnButtonRestart() {
		Application.LoadLevel(Application.loadedLevel);
		if (isPaused) Unpause();
		Time.timeScale = 1;
		canUnpause = true;
	}

	public void OnButtonExit() {
		Application.Quit();
	}

	public void ChangeGameVolume() {
		AudioListener.volume = gameVolume.value;
	}

	public void ChangeMusicVolume() {
		music.volume = musicVolume.value;
	}
}
