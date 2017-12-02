using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Scripts;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {
	public Pixelation mainCamera;
	public Pixelation weaponCamera;

	private CharacterController character;
	private AudioSource footsteps;

	private float tick = 0.0f;

	private void Start() {
		character = GetComponent<CharacterController>();
		footsteps = GetComponent<AudioSource>();
	}

	private void Update() {
		// Alcohol effects
		float alcohol = PlayerStats.getAlcohol() - 5.0f;

		if (alcohol < 0.0f) alcohol = 0.0f;
		if (alcohol > 20.0f) alcohol = 20.0f;

		mainCamera.BlockCount = 512.0f - (alcohol / 20.0f) * 384.0f;
		weaponCamera.BlockCount = 512.0f - (alcohol / 20.0f) * 384.0f;

		tick += Time.deltaTime;

		if (tick > 0.25f) {
			tick -= 0.25f;

			// Decrease alcohol
			PlayerStats.removeAlcohol(0.1f);
		}

		// At one point I want to check the type of the ground and if the player is grounded.
		if (character.velocity.magnitude > 1.0f && !footsteps.isPlaying) footsteps.Play();
		else if (character.velocity.magnitude < 1.0f && footsteps.isPlaying) footsteps.Stop();
	}
}
