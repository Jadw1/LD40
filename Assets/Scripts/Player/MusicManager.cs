using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {
	public AudioClip epicMusic;
	public AudioClip normalMusic;

	private AudioSource audio;

	public static void StartEpicMusic() {
		if (manager != null) {
			manager.PlayEpicMusic();
		}
	}

	private static MusicManager manager;

	private void Start() {
		manager = this;

		audio = GetComponent<AudioSource>();

		audio.clip = normalMusic;
		audio.Play();
	}

	private void Update() {
		if (!audio.isPlaying) {
			audio.clip = normalMusic;
			audio.Play();
		}
	}

	public void PlayEpicMusic() {
		if (audio.isPlaying) audio.Stop();

		audio.clip = epicMusic;
		audio.Play();
	}
}
