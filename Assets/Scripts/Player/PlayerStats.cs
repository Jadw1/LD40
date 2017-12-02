using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats {
	// Default constant values
	private const float defaultHealth = 100.0f;
	private const float defaultArmor = 0.0f;

	// Max values
	private const float maxHealth = 100.0f;
	private const float maxArmor = 100.0f;

	private const int maxStoredVodka = 2;

	// Current stats
	private static float currentHealth = defaultHealth;
	private static float currentArmor = defaultArmor;

	private static int storedVodka = 0;

	// Value functions (we don't need setters for everything)
	public static void dealDamage(float damage) {
		float dmg = damage * (1 - (currentArmor / maxArmor));

		currentArmor -= damage;

		if (currentArmor < 0.0f) currentArmor = 0.0f;

		currentHealth -= dmg;

		if (currentHealth < 0.0f) currentHealth = 0.0f;
	}

	public static void heal(float amount) {
		currentHealth += amount;
		if (currentHealth > maxHealth) currentHealth = maxHealth;
	}

	public static void addArmor(float amount) {
		currentArmor += amount;

		if (currentArmor > maxArmor) currentArmor = maxArmor;
	}

	public static void decreaseArmor(float amount) {
		currentArmor -= amount;

		if (currentArmor < 0.0f) currentArmor = 0.0f;
	}

	public static bool addVodka() {
		if (storedVodka < maxStoredVodka) {
			storedVodka++;
			return true;
		}

		return false;
	}

	public static bool removeVodka() {
		if (storedVodka > 0) {
			storedVodka--;
			return true;
		}

		return false;
	}

	public static float getHealthPercent() { return (currentHealth / maxHealth) * 100.0f; }
}
