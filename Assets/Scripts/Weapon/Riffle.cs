using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : MonoBehaviour {

    public float range = 50.0f;
    public float fireRate = 10.0f;

    private float timeToFire = 0.0f;

    private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetButton("Fire1") && Time.time > timeToFire) {
            timeToFire = Time.time + 1 / fireRate;

            if(Physics.Raycast(ray, out hit, range)) {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
