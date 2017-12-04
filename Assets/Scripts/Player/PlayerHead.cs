using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour {
	public float maxHeadOffset = 0.1f;
	public float maxHeadBobSpeed = 0.2f;

	private Vector3 originalPos;

	private float bobTimer = 0.0f;

	private void Start() {
		originalPos = transform.localPosition;
	}

	private void Update() {
		if (Time.timeScale == 0) return;

		float bobAmount = Mathf.Abs(FakeControls.GetVertical()) + Mathf.Abs(FakeControls.GetHorizontal());
		bobAmount = Mathf.Clamp01(bobAmount);

		bobTimer += maxHeadBobSpeed * bobAmount;
		if (bobTimer > 2 * Mathf.PI) bobTimer -= 2 * Mathf.PI;

		if (bobAmount == 0) {
			if (bobTimer < -0.05f) bobTimer += maxHeadBobSpeed * Time.deltaTime;
			else if (bobTimer > 0.05f) bobTimer -= maxHeadBobSpeed * Time.deltaTime;
			else bobTimer = 0.0f;
		}

		Vector3 newPos = originalPos + Vector3.up * Mathf.Sin(bobTimer) * maxHeadOffset; ;

		transform.localPosition = newPos;
	}
}
