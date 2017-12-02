using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour {
	private Image image;

	private void Start() {
		image = GetComponent<Image>();
	}

	private void Update() {
		image.fillAmount = PlayerStats.getHealthPercent();
	}
}
