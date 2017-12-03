using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {
	public Transform player;

	public float detectionRange = 10.0f;
	public float damage = 5.0f;
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

				// I probably want to injure the player here
				RaycastHit hit;

				Debug.DrawRay(transform.position, transform.forward);

				if (Physics.Raycast(transform.position, transform.forward, out hit)) {
					Debug.Log(hit.collider.name);

					if (hit.collider.tag == "Player") {
						audio.PlayOneShot(shootSound);
						PlayerStats.dealDamage(damage);
					}
				}
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
