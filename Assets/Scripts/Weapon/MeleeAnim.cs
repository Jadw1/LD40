using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Melee))]
public class MeleeAnim : MonoBehaviour {
	public Sprite[] frames;

	public float animSpeed = 0.2f;
	public float swingSpeed = 2.0f;

	public int middleFrame = 2;

	private Melee melee;
	private SpriteRenderer renderer;
	private int frame;
	private float dt;

	private bool isSwinging = false;
	private bool reachedMiddle = true;

	private Vector3 pos;
	private Vector3 offset;

	public bool CanSwing() {
		return !isSwinging;
	}

	public void StartAnim() {
		isSwinging = true;
		reachedMiddle = false;
		frame = 0;
	}

	private void Start() {
		renderer = GetComponent<SpriteRenderer>();
		melee = GetComponent<Melee>();

		pos = transform.localPosition;

		isSwinging = false;
		reachedMiddle = true;

		offset = new Vector3();
	}

	private void Update() {
		dt += Time.deltaTime;

		if (dt > animSpeed) {
			dt = 0.0f;

			if (isSwinging) {
				frame++;

				if (frame >= frames.Length) {
					frame = 0;
				}

				if (frame == middleFrame) {
					melee.MeleeAttack();
					reachedMiddle = true;
				}
			} else {
				frame = 0;
			}

			renderer.sprite = frames[frame];
		}
	}

	private Vector3 GetChange(Vector3 a, Vector3 b) {
		return b - a;
	}

	private void FixedUpdate() {
		Vector3 defaultOffset = new Vector3(-0.2f, -0.225f, 0.0f);
		Vector3 maxOffset = new Vector3(0.15f, 0.05f, 0.0f);

		Vector3 diff = maxOffset - defaultOffset;

		if (!reachedMiddle) offset = offset + diff * swingSpeed;
		else offset = offset - diff * swingSpeed;
		transform.localPosition = pos + offset;

		offset.x = Mathf.Clamp(offset.x, defaultOffset.x, maxOffset.x);
		offset.y = Mathf.Clamp(offset.y, defaultOffset.y, maxOffset.y);
		offset.z = Mathf.Clamp(offset.z, defaultOffset.z, maxOffset.z);

		if (isSwinging && reachedMiddle && offset == defaultOffset) isSwinging = false;
	}
}
