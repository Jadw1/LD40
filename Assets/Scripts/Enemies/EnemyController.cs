using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {
	public Transform player;

	public float detectionRange = 10.0f;

	public float movementSpeed = 5.0f;

	public AudioClip shootSound;

	private AudioSource audio;
	private CharacterController character;
	private EnemyStats stats;

	private float dt = 0.0f;

	public float attackDelay = 1.0f;

	private void Start() {
		character = GetComponent<CharacterController>();
		stats = GetComponent<EnemyStats>();
		audio = GetComponent<AudioSource>();
	}

	private void Update() {
		Vector3 direction = player.position - transform.position;

		if (direction.magnitude < detectionRange && stats.getHealthPercent() > 0.0f) {
			direction = direction.normalized;

			dt += Time.deltaTime;

			if (dt > attackDelay) {
				dt = 0.0f;
				audio.PlayOneShot(shootSound);

				// I probably want to injure the player here
			}
		}
		else {
			direction = Vector3.zero;
			dt = 0.0f;
		}

		character.Move(direction * Time.deltaTime * movementSpeed);
	}

	public bool isWalking() {
		return character.velocity.magnitude > 1.0f;
	}
}
