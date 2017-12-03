using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyController))]
public class EnemyAnim : MonoBehaviour {
	public Sprite[] walkingFrames;
	public Sprite[] deathFrames;

	public float frameLength = 0.1f;

	private SpriteRenderer renderer;
	private EnemyController controller;
	private EnemyStats stats;

	private int currentFrame;
	private int[] frameCount;

	private bool isDieing;

	private float dt;

	private void Start() {
		renderer = GetComponent<SpriteRenderer>();
		controller = GetComponent<EnemyController>();
		stats = GetComponent<EnemyStats>();

		frameCount = new int[2];

		frameCount[0] = walkingFrames.Length;
		frameCount[1] = deathFrames.Length;

		currentFrame = 0;
		dt = 0.0f;

		isDieing = false;
	}

	private void Update() {
		dt += Time.deltaTime;

		// I make sure to kill the player here
		if (stats.getHealthPercent() <= 0.0f && !isDieing) {
            controller.DiscardEffect();
			currentFrame = 0;
			isDieing = true;
		}

		if (dt > frameLength) {
			dt = 0.0f;

			if (isDieing) {
				currentFrame++;

				if (currentFrame >= frameCount[0]) {
					currentFrame = 0;

					Destroy(this.gameObject);
				}

				renderer.sprite = deathFrames[currentFrame];
			} else {
				if (controller.isWalking()) currentFrame++;
				else currentFrame = 1;

				if (currentFrame >= frameCount[0]) {
					currentFrame = 0;
				}

				renderer.sprite = walkingFrames[currentFrame];
			}
		}
	}
}
