using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

    private Transform spawnPoint;
    public GameObject drunkRoad;

    private void Awake() {
        spawnPoint = transform.Find("Spawn Point");
    }

    private void Start() {
        Spawn();
    }

    private void OnTriggerEnter(Collider other) {
        Spawn();
    }

    private void Spawn() {
        Transform clone = Instantiate(drunkRoad, spawnPoint.position, spawnPoint.rotation).transform;
        clone.parent = transform;
    }
}
