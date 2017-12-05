using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpiritAnimator : MonoBehaviour {

	[System.Serializable]
	public class SpiritAnimation {
		public string name;
		public float frameLength;
		public Sprite[] frames;

		public int length { get { return frames.Length; } }
	}

	public SpiritAnimation[] animations;

	private SpriteRenderer spriteRenderer;

	private SpiritAnimation currentAnimation;

	private SpiritListener listener;

	private float dt;

	private int currentFrame;

	public bool isAnimating;

	public void SetFrame(int frame) {
		currentFrame = Mathf.Clamp(frame, 0, currentAnimation.length);
		dt = 0.0f;
	}

	public void Pause() {
		isAnimating = false;
	}

	public void Resume() {
		isAnimating = true;
	}

	public void PlayAnimation(string name) {
		PlayAnimation(GetAnimationIndex(name));
	}

	public void PlayAnimation(int index) {
		isAnimating = true;

		if (listener != null && currentAnimation != null) listener.OnAnimationEnd(currentAnimation.name);

		currentAnimation = animations[index];

		dt = 0.0f;
		currentFrame = 0;

		if (listener != null) listener.OnAnimationStart(currentAnimation.name);
	}

	public int GetAnimationIndex(string name) {
		for (int i = 0; i < animations.Length; i++) {
			if (animations[i].name == name) return i;
		}

		return 0;
	}

	public int GetCurrentFrame() { return currentFrame; }
	public string GetCurrentAnimation() { return currentAnimation.name; }
	public bool IsAnimating() { return isAnimating; }

	private void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		listener = GetComponent<SpiritListener>();

		if (animations.Length == 0) {
			this.enabled = false;
			return;
		}

		PlayAnimation(0);
	}

	private void Update() {
		if (isAnimating) dt += Time.deltaTime;

		if (dt > currentAnimation.frameLength) {
			dt = 0.0f;

			currentFrame++;

			if (listener != null) listener.OnFrameChange(currentAnimation.name, currentFrame);

			if (currentFrame >= currentAnimation.length) {
				currentFrame = 0;

				if (listener != null) {
					listener.OnAnimationEnd(currentAnimation.name);
					listener.OnAnimationStart(currentAnimation.name);
				}
			}

			Sprite sprite = currentAnimation.frames[currentFrame];

			if (sprite != null) {
				spriteRenderer.sprite = sprite;
			}
		}
	}
}
