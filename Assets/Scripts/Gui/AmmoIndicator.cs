using UnityEngine.UI;
using UnityEngine;

public class AmmoIndicator : MonoBehaviour {

	private Image mag;

	public Image mag1;
	public Image mag2;
	public Image mag3;
	public Image mag4;
	public Image mag5;

	// Use this for initialization
	void Start() {
		mag = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
		int ammo = PlayerStats.ammo;

		int clip = PlayerStats.clip;

		int m1 = Mathf.Clamp(ammo, 0, 30);
		int m2 = Mathf.Clamp(ammo - 30, 0, 30);
		int m3 = Mathf.Clamp(ammo - 60, 0, 30);
		int m4 = Mathf.Clamp(ammo - 90, 0, 30);
		int m5 = Mathf.Clamp(ammo - 120, 0, 30);

		mag.fillAmount = clip / 30.0f;

		mag1.fillAmount = m1 / 30.0f;
		mag2.fillAmount = m2 / 30.0f;
		mag3.fillAmount = m3 / 30.0f;
		mag4.fillAmount = m4 / 30.0f;
		mag5.fillAmount = m5 / 30.0f;
	}
}
