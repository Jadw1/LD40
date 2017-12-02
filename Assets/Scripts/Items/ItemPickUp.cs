using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {
	public enum Type {
		ALCOHOL,
		HEAL,
		ARMOR,
		DAMAGE,
		DAMAGE_DIRECT
	};

	public float strength = 1.0f;

	public Type itemType;

	private void OnTriggerEnter(Collider other) {
		if (other != null && other.tag == "Player") {
			switch (itemType) {
				case Type.ALCOHOL:
					PlayerStats.addAlcohol(strength);
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

				default: break;
			}
		}
	}
}
