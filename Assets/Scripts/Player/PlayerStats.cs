using UnityEngine;

public static class PlayerStats {
	// Max values
	private const float maxHealth = 100.0f;
	private const float maxArmor = 100.0f;

	// Default constant values
	private const float defaultHealth = maxHealth;
	private const float defaultArmor = 0.0f;
	private const float defaultAlcohol = 0.0f;
    private const float defaultDamage = 30.0f;
    private const int defaultMaxAmmo = 150;
    private const int defaultMaxClip = 20;

	// Current stats
	private static float currentHealth = defaultHealth;
	private static float currentArmor = defaultArmor;
	private static float currentAlcohol = defaultAlcohol;
    private static int currentAmmo = defaultMaxAmmo;
    private static int currentClip = defaultMaxClip;

    // Modifiers
    public static float damageModifier = 1.0f;

	// Player effects object for sound effects
	private static PlayerEffects player;

    // Getters
    public static float damage {
        get { return defaultDamage * damageModifier; }
    }
    public static int clip {
        get { return currentClip; }
    }
    public static int ammo {
        get { return currentAmmo; }
    }
	public static float alcohol {
        get { return currentAlcohol; }
    }

	// Value functions (we don't need setters for everything)
    public static void RemoveOneBullet() {  // xdddddddd
        currentClip = Mathf.Clamp(currentClip - 1, 0, defaultMaxClip);
    }

    public static bool IsReloadingPossible() {
        if (currentClip == defaultMaxClip || currentAmmo <= 0)
            return false;
        else
            return true;
    }

    public static bool IsAmmoFull() {
        if (currentAmmo == defaultMaxAmmo)
            return true;
        else
            return false;
    }

    public static void AddAmmo(int amount) {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, defaultMaxAmmo);
    }

    public static void Reload() {
        if(currentAmmo >= defaultMaxClip) {
            int difference = defaultMaxClip - currentClip;
            currentClip = defaultMaxClip;
            currentAmmo -= difference;
        }
        else {
            int difference = defaultMaxClip - currentClip;
            currentClip = currentAmmo;
            currentAmmo -= difference;
        }
    }

	public static void dealDamage(float damage, bool direct = false) {
		float dmg = damage;

		if (!direct) {
			dmg = damage * (1 - (currentArmor / maxArmor));

			currentArmor -= damage;

			if (currentArmor < 0.0f) currentArmor = 0.0f;
		}

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

	public static void addAlcohol(float amount) {
		currentAlcohol += amount;

		if (player != null) player.playDrinkingSound();
	}

	public static void removeAlcohol(float amount) {
		currentAlcohol -= amount;
		if (currentAlcohol < 0.0f) currentAlcohol = 0.0f;
	}


	public static void reset() {
		currentArmor = defaultArmor;
		currentHealth = defaultHealth;
		currentAlcohol = defaultAlcohol;
	}

	public static float getHealthPercent() { return (currentHealth / maxHealth); }

	public static void registerPlayerEffects(PlayerEffects effects) {
		player = effects;
	}
}
