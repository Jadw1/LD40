using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public float offset;

    public GameObject crosshair;

    private GameObject top;
    private GameObject bottom;
    private GameObject left;
    private GameObject right;

    private void Start() {
        top = crosshair.transform.Find("Top").gameObject;
        bottom = crosshair.transform.Find("Bottom").gameObject;
        left = crosshair.transform.Find("Left").gameObject;
        right = crosshair.transform.Find("Right").gameObject;
    }


}
