using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBlooding : MonoBehaviour {
    private Image image;

    public float fadingSpeed = 30.0f;
    public float damageFactor = 10.0f;

    public float alpha = 0.0f;

    private void Start() {
        image = GetComponent<Image>();
    }

    private void Update() {
        if (alpha > 0) {
            alpha -= fadingSpeed * Time.deltaTime;
            if (alpha < 0)
                alpha = 0;
            ChangeAlphaColor();
        }

    }

    public void BloodScreen(float damage) {
        alpha += damage * damageFactor;
        ChangeAlphaColor();
    }

    private void ChangeAlphaColor() {
        if (alpha > 1)
            alpha = 1;
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }
}
