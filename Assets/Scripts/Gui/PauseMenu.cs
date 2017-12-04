using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;

	private bool isPaused = false;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.G)) {
			if (isPaused) Unpause();
			else Pause();
		}
	}

	private void Pause() {
		if (!pauseMenu.activeInHierarchy) {
			pauseMenu.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0;
			isPaused = true;
		}
	}


	private void Unpause() {
		if (pauseMenu.activeInHierarchy) {
			pauseMenu.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1;
			isPaused = false;
		}
	}


	public void OnButtonResume() {
		if (isPaused) Unpause();
	}

	public void OnButtonRestart() {
		Application.LoadLevel(Application.loadedLevel);
		if (isPaused) Unpause();
	}

	public void OnButtonExit() {
		Application.Quit();
	}
}
