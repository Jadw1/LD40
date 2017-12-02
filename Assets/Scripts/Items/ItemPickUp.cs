using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {
	public enum Type {
		VODKA
	};

	public Type itemType;

	private void OnTriggerEnter(Collider other) {
		if (other != null && other.tag == "Player") {
			PlayerStats.addAlcohol(1.0f);
			Destroy(this.gameObject);
		}
	}
}
