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

        Vector3 cSharpConversion = transform.localPosition;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) {
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
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else {
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;
    }



}