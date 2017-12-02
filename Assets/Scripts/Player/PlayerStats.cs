public static class PlayerStats {
	// Max values
	private const float maxHealth = 100.0f;
	private const float maxArmor = 100.0f;

	// Default constant values
	private const float defaultHealth = maxHealth;
	private const float defaultArmor = 0.0f;
	private const float defaultAlcohol = 0.0f;

	// Current stats
	private static float currentHealth = defaultHealth;
	private static float currentArmor = defaultArmor;
	private static float currentAlcohol = defaultAlcohol;

	// Player effects object for sound effects
	private static PlayerEffects player;

	// Value functions (we don't need setters for everything)
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

	public static float getAlcohol() { return currentAlcohol; }

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
