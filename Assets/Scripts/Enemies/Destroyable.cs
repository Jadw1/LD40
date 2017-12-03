using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class Destroyable : MonoBehaviour {
	private EnemyStats stats;

	private void Start() {
		stats = GetComponent<EnemyStats>();
	}

	private void Update() {
		if (stats.getHealthPercent() <= 0.0f) Destroy(this.gameObject);
	}
}
