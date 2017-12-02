using UnityEngine.UI;
using UnityEngine;

public class AmmoIndicator : MonoBehaviour {

    private Text text;

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        text.text = PlayerStats.clip + " " + PlayerStats.ammo;
    }
}
