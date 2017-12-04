using UnityEngine;

public static class FakeControls {
	private static Vector3 dir;
	private static Vector3 look;

	private static float dt;

	private const float interval = 1.0f;

	private static float randomness = 0.0f;

	public static void Update() {
		dt += Time.deltaTime;

		if (dt > interval) {
			dt = 0.0f;

			dir = Random.insideUnitSphere;
			look = Random.insideUnitSphere;
		}
	}

	public static void SetRandomness(float amount) {
		randomness = amount;
	}

	public static float GetHorizontal() { return Time.timeScale != 0 ? Input.GetAxis("Horizontal") + dir.x * randomness : 0.0f; }
	public static float GetVertical() { return Time.timeScale != 0 ? Input.GetAxis("Vertical") + dir.y * randomness : 0.0f; }
	public static float GetMouseX() { return Time.timeScale != 0 ? Input.GetAxis("Mouse X") + look.z * randomness : 0.0f; }
	public static float GetMouseY() { return Time.timeScale != 0 ? Input.GetAxis("Mouse Y") + look.y * randomness : 0.0f; }
}