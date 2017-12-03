using UnityEngine;

public class PlayerStats : MonoBehaviour {
	// Max values
	private const float maxHealth = 100.0f;
	private const float maxArmor = 100.0f;

	// Default constant values
	private const float defaultHealth = maxHealth;
	private const float defaultArmor = 0.0f;
    private const float defaultDamage = 30.0f;
	private const float defaultHealTime = 0.0f;
    private const int defaultMaxAmmo = 90;
    private const int defaultMaxClip = 30;
	private const int defaultAlcohol = 0;

	// Current stats
	private static float currentHealth = defaultHealth;
	private static float currentArmor = defaultArmor;
	private static float currentHealTime = defaultHealTime;
	private static int currentAmmo = defaultMaxAmmo;
    private static int currentClip = defaultMaxClip;
	private static int currentAlcohol = defaultAlcohol;

	// Modifiers
	public static float damageModifier = 1.0f;

	// Player effects object for sound effects
	private static PlayerEffects player;
	private static PlayerStats stats;

    // Getters
    public static float damage {
        get { return defaultDamage * damageModifier; }
    }
	public static float healTime {
		get { return currentHealTime; }
	}
	public static int clip {
        get { return currentClip; }
    }
    public static int ammo {
        get { return currentAmmo; }
    }
	public static int alcohol {
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

		Debug.Log("Damage done: " + dmg.ToString() + " HP: " + currentHealth.ToString());

		if (currentHealth < 0.0f) currentHealth = 0.0f;
	}

	public static void addHealTime(float time) {
		currentHealTime += time;
	}

	public static void removeHealTime(float time) {
		currentHealTime -= time;
		if (currentHealTime < 0.0f) currentHealTime = 0.0f;
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

	public static void addAlcohol() {
		currentAlcohol++;

		if (currentAlcohol > getAlcoholLimit()) currentAlcohol = getAlcoholLimit();

		if (player != null) player.playDrinkingSound();
	}

	public static int getAlcoholLimit() { return 5; }

	public static void removeAlcohol() {
		currentAlcohol = 0;
	}

	public static void reset() {
		currentArmor = defaultArmor;
		currentHealth = defaultHealth;
		currentAlcohol = defaultAlcohol;
	}

	public static float getHealthPercent() { return (currentHealth / maxHealth); }

	public static GameObject getPlayer() {
		return stats.gameObject;
	}

	private void Start() {
		player = GetComponent<PlayerEffects>();
		stats = this;

		reset();
	}
}
