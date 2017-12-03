using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

	private float startingY = 0.0f;
	private float offset = 0.0f;

	public enum Type {
		ALCOHOL,
		ZAGRYZKA,
		HEAL,
		ARMOR,
		DAMAGE,
		DAMAGE_DIRECT,
		AMMO
	};

	public float strength = 1.0f;

	public float bobSpeed = 3.0f;
	public float bobRange = 0.25f;

	public Type itemType;

	private void OnTriggerEnter(Collider other) {
		if (other != null && other.tag == "Player") {
			switch (itemType) {
				case Type.ALCOHOL:
					PlayerStats.addAlcohol();
					PlayerStats.addHealTime(strength);
					Destroy(this.gameObject);
					return;
				case Type.ZAGRYZKA:
					PlayerStats.removeAlcohol();
					Destroy(this.gameObject);
					break;
				case Type.HEAL:
					PlayerStats.heal(strength);
					Destroy(this.gameObject);
					break;
				case Type.DAMAGE:
					PlayerStats.dealDamage(strength);
					Destroy(this.gameObject);
					break;
				case Type.DAMAGE_DIRECT:
					PlayerStats.dealDamage(strength, true);
					Destroy(this.gameObject);
					break;
				case Type.ARMOR:
					PlayerStats.addArmor(strength);
					Destroy(this.gameObject);
					break;
				case Type.AMMO:
					if (!PlayerStats.IsAmmoFull()) {
						PlayerStats.AddAmmo((int) strength);
						Destroy(this.gameObject);
					}
					break;

				default: break;
			}
		}
	}

	private void Start() {
		startingY = transform.position.y;
	}

	private void FixedUpdate() {
		offset += Time.fixedDeltaTime * bobSpeed;

		if (offset > Mathf.PI * 2) offset -= Mathf.PI * 2;

		transform.position = new Vector3(transform.position.x, startingY + Mathf.Sin(offset) * bobRange, transform.position.z);
	}
}
