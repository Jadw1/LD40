using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Melee))]
public class MeleeAnim : MonoBehaviour {
	public Sprite[] frames;

	public float animSpeed = 0.2f;

	public int middleFrame = 2;

	private Melee melee;
	private SpriteRenderer renderer;
	private int frame;
	private float dt;

	private bool isSwinging = false;

	private Vector3 pos;
	private Vector3 offset;

	public void StartAnim() {
		isSwinging = true;
	}

	private void Start() {
		renderer = GetComponent<SpriteRenderer>();
		melee = GetComponent<Melee>();

		pos = transform.localPosition;

		offset = new Vector3();
	}

	private void Update() {
		if (isSwinging) {

			dt += Time.deltaTime;

			if (dt > animSpeed) {
				dt = 0.0f;

				offset = Vector3.Lerp(offset, new Vector3(0.08f, 0.08f, 0.0f), 0.75f);

				frame++;

				if (frame >= frames.Length) {
					frame = 0;
					melee.canShoot = true;
					isSwinging = false;
				}
			}

			if (frame == middleFrame) {
				melee.MeleeAttack();
			}
		} else {
			offset = Vector3.Lerp(offset, new Vector3(0.0f, 0.0f, 0.0f), 0.75f) * Time.deltaTime;

			dt = 0.0f;
			frame = 0;
		}

		renderer.sprite = frames[frame];

		transform.localPosition = pos + offset;
	}
}
