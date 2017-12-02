using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
	// Max values
	private const float maxHealth = 100.0f;
	private const float maxArmor = 100.0f;

	// You can tweak those
	public float defaultArmor = 50.0f;

	// Current stats
	public float currentHealth = maxHealth;
	private float currentArmor = 0.0f;

	private void Start() {
		currentArmor = defaultArmor;
	}

	public void dealDamage(float damage, bool direct = false) {
		float dmg = damage;

		if (!direct) {
			dmg = damage * (1 - (currentArmor / maxArmor));

			currentArmor -= damage;

			if (currentArmor < 0.0f) currentArmor = 0.0f;
		}

		currentHealth -= dmg;

        if (currentHealth < 0.0f) {
            KillMe();
        }
	}

    private void KillMe() {
        Destroy(gameObject);
    }

	public float getHealthPercent() { return currentHealth / maxHealth; }
}
