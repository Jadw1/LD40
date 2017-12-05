using UnityEngine;

public class PlayerStats : MonoBehaviour {
	// Max values
	private const float maxHealth = 200.0f;
	private const float maxArmor = 150.0f;

	// Default constant values
	private const int defaultMaxAlcohol = 10;
	private const float defaultHealth = maxHealth;
	private const float defaultArmor = maxArmor;
    private const float defaultDamage = 30.0f;
	private const float defaultHealTime = 0.0f;
    private const int defaultMaxAmmo = 150;
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

    public ScreenBlooding blooding;

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
		player.PlayAmmoSound();
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

	public static void DealDamage(float damage, bool direct = false) {
		float dmg = damage;

		if (!direct) {
			dmg = damage * (1 - (currentArmor / maxArmor));

			currentArmor -= damage;

			if (currentArmor < 0.0f) currentArmor = 0.0f;
		}

		currentHealth -= dmg;

        stats.blooding.BloodScreen(dmg);

		if (currentHealth <= 0.0f) {
			currentHealth = 0.0f;
			player.Lose();
		}
	}

	public static void AddHealTime(float time) {
		currentHealTime += time;
	}

	public static void RemoveHealTime(float time) {
		currentHealTime -= time;
		if (currentHealTime < 0.0f) currentHealTime = 0.0f;
	}

	public static void Heal(float amount) {
		currentHealth += amount;
		if (currentHealth > maxHealth) currentHealth = maxHealth;
	}

	public static void AddArmor(float amount) {
		currentArmor += amount;

		if (currentArmor > maxArmor) currentArmor = maxArmor;
	}

	public static void DecreaseArmor(float amount) {
		currentArmor -= amount;

		if (currentArmor < 0.0f) currentArmor = 0.0f;
	}

	public static void AddAlcohol() {
		currentAlcohol++;

		if (currentAlcohol > GetAlcoholLimit()) currentAlcohol = GetAlcoholLimit();

		if (player != null) player.PlayDrinkingSound();
	}

	public static int GetAlcoholLimit() { return defaultMaxAlcohol; }

	public static void RemoveAlcohol(int amt) {
		currentAlcohol -= amt;
		if (currentAlcohol < 0) currentAlcohol = 0;
		player.PlayEatingSound();
	}

	public static void ResetToDefault() {
		currentArmor = defaultArmor;
		currentHealth = defaultHealth;
		currentAlcohol = defaultAlcohol;
		currentAmmo = defaultMaxAmmo;
		currentClip = defaultMaxClip;
		currentHealTime = defaultHealTime;
	}

	public static void Lose() {
		player.Lose();
	}

	public static void Win() {
		player.Win();
	}

	public static void PlayDestroySound() {
		player.PlayDestroySound();
	}

	public static float GetHealthPercent() { return (currentHealth / maxHealth); }

	public static GameObject GetPlayer() {
		return stats.gameObject;
	}

	private void Start() {
		player = GetComponent<PlayerEffects>();
		stats = this;

		ResetToDefault();
	}
}
