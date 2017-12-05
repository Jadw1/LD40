using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntyIdiotManager : MonoBehaviour {

    public Door bossDoor;
    public BossManager bossManager;

    private void OnTriggerEnter(Collider other) {
        bossDoor.RemoveAllKeys();
        bossManager.first = true;
    }
}
