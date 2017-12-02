using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHole : MonoBehaviour {

    public float lifeTime = 30.0f;
    private float livingTime = 0.0f;

	// Update is called once per frame
	void Update () {
        if (livingTime >= lifeTime)
            Destroy(this.gameObject);

        livingTime += Time.deltaTime;
	}
}
