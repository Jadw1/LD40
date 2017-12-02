using UnityEngine;
using System.Collections;

public class HeadBobbing : MonoBehaviour {

    public float bobbingSpeed = 0.18f;
    public float bobbingHeight = 0.2f;

    private float midpoint;
    private float timer = 0.0f;

    private void Start() {
        midpoint = Camera.main.transform.localPosition.y;
    }

    void Update() {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

		float bob = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
		bob = Mathf.Clamp01(bob);

        Vector3 cSharpConversion = transform.localPosition;

        if (bob == 0) {
            timer = 0.0f;
        }
        else {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2) {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0) {
            float translateChange = waveslice * bobbingHeight;
            translateChange = bob * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else {
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;
    }



}