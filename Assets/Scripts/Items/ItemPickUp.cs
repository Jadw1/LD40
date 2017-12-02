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
			if (PlayerStats.addVodka()) Destroy(this.gameObject);
		}
	}
}
