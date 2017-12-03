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

	public static float GetHorizontal() { return Input.GetAxis("Horizontal") + dir.x * randomness; }
	public static float GetVertical() { return Input.GetAxis("Vertical") + dir.y * randomness; }
	public static float GetMouseX() { return Input.GetAxis("Mouse X") + look.z * randomness; }
	public static float GetMouseY() { return Input.GetAxis("Mouse Y") + look.y * randomness; }
}