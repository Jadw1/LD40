﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {
	public float detectionRange = 10.0f;
	public float damage = 5.0f;
	public float movementSpeed = 5.0f;

	public AudioClip shootSound;

	private AudioSource audio;
	private CharacterController character;
	private EnemyStats stats;

	private float dt = 0.0f;

	public float attackDelay = 1.0f;

    public SpriteRenderer muzzleFlash;
    private bool isMuzzleOn = false;
    private float muzzleDelay = 0.5f;
    private float muzzleTimer = 0.0f;

	private void Start() {
		character = GetComponent<CharacterController>();
		stats = GetComponent<EnemyStats>();
		audio = GetComponent<AudioSource>();

        DiscardEffect();

    }

	private void Update() {

		Transform player = PlayerStats.GetPlayer().transform;

		Vector3 direction = player.position - transform.position;

		if (direction.magnitude < detectionRange && stats.getHealthPercent() > 0.0f) {
			direction = direction.normalized;

			dt += Time.deltaTime;

			if (dt > attackDelay) {
				dt = 0.0f;

				// I probably want to injure the player here
				RaycastHit hit;

				Debug.DrawRay(transform.position, transform.forward);

				if (Physics.Raycast(transform.position, direction, out hit)) {

					if (hit.collider.tag == "Player") {
						audio.PlayOneShot(shootSound);
						PlayerStats.DealDamage(damage);
					}
				}

                Effect();
			}
            else if(muzzleTimer >= muzzleDelay) {           
                DiscardEffect();
            }
		}
		else {
			direction = Vector3.zero;
			dt = 0.0f;
		}

		direction.y = 0;

		character.SimpleMove(direction * movementSpeed);

        if(isMuzzleOn) {
            muzzleTimer += Time.deltaTime;
        }
	}

    private void Effect() {
        muzzleFlash.transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-15.0f, 40.0f)));
        muzzleFlash.transform.localScale = new Vector3(Random.Range(1.75f, 2.25f), Random.Range(1.75f, 2.25f), 1.0f);

        float r = Random.Range(0.8f, 1.0f);
        muzzleFlash.color = new Color(r, r, r, r);

        muzzleTimer = 0.0f;
        isMuzzleOn = true;
    }

    public void DiscardEffect() {
        muzzleFlash.color = new Color(0, 0, 0, 0);
        isMuzzleOn = false;
    }

    public bool isWalking() {
		return character.velocity.magnitude > 1.0f;
	}
}
