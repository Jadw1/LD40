using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorOpeningDirection {
    RIGHT,
    LEFT
};

public class Door : MonoBehaviour {

    public DoorOpeningDirection direction;

    public float speed = 5.0f;
    public float offset = 2.5f;
    private float diff = 0.0f;

    public float timeToClose = 10.0f;
    private float timer = 0.0f;
    private bool isOpened = false;
    private bool isOpening = false;

    public void Open() {
        if (isOpened)
            return;

        isOpening = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(isOpening) {
            diff += offset * speed * Time.deltaTime;

            if(direction == DoorOpeningDirection.LEFT) {

            }
        }


	}
}
