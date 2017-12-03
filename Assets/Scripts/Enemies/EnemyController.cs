using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {
	public Transform player;

	public float detectionRange = 10.0f;

	public float movementSpeed = 5.0f;

	private CharacterController character;
	private EnemyStats stats;

	public bool isMoving;

	private void Start() {
		character = GetComponent<CharacterController>();
		stats = GetComponent<EnemyStats>();
	}

	private void Update() {
		Vector3 direction = player.position - transform.position;

		if (direction.magnitude < detectionRange && stats.getHealthPercent() > 0.0f) direction = direction.normalized;
		else direction = Vector3.zero;

		character.Move(direction * Time.deltaTime * movementSpeed);

		isMoving = isWalking();
	}

	public bool isWalking() {
		return character.velocity.magnitude > 1.0f;
	}
}
