using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Scripts;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {
	public Pixelation mainCamera;
	public Pixelation weaponCamera;

	private float tick = 0.0f;

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
	}
}
