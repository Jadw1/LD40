﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : MonoBehaviour {

    public float range = 50.0f;
    public float fireRate = 10.0f;

    private float timeToFire = 0.0f;

    public GameObject bulletHole;

    private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
        RaycastHit hit;
        if(Input.GetButton("Fire1") && Time.time > timeToFire) {
            timeToFire = Time.time + 1 / fireRate;

            if(Physics.Raycast(ray, out hit, range)) {
                Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }
}
