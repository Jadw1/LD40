using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Scripts;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {
	public Pixelation weaponCamera;

	public AudioClip drinkingSound;
	public AudioSource generalSounds;
	public AudioSource footsteps;

	public GameObject deathScreen;

	private CharacterController character;
	private HeadBobbing headBob;

	private float tick = 0.0f;

	private void Start() {
		character = GetComponent<CharacterController>();
		headBob = GetComponentInChildren<HeadBobbing>();
	}

	private void Update() {
		// Alcohol effects
		float alcohol = PlayerStats.alcohol;
		
		weaponCamera.BlockCount = 512.0f - (alcohol / PlayerStats.GetAlcoholLimit()) * 384.0f;

		tick += Time.deltaTime;

		if (tick > 0.25f) {
			tick -= 0.25f;

			if (PlayerStats.healTime > 0.0f) PlayerStats.Heal(2.5f);
			PlayerStats.RemoveHealTime(0.25f);
		}

		// At one point I want to check the type of the ground and if the player is grounded.
		if (character.velocity.magnitude > 1.0f && !footsteps.isPlaying) footsteps.Play();
		else if (character.velocity.magnitude < 1.0f && footsteps.isPlaying) footsteps.Stop();

		// I update the randomness here.
		FakeControls.Update();
		FakeControls.SetRandomness(alcohol / PlayerStats.GetAlcoholLimit() * 0.5f);
	}

	public void lose() {
		deathScreen.SetActive(true);
	}

	public void win() {

	}

	public void playDrinkingSound() {
		generalSounds.PlayOneShot(drinkingSound);
	}
}
