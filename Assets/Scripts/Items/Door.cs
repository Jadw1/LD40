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
    private Vector3 pos;

    public float timeToClose = 10.0f;
    private float timer = 0.0f;
    private bool isOpened = false;
    private bool isOpening = false;
    private bool isClosing = false;

    public void Open() {
        Debug.Log("aaaaaa");

        if (isOpened)
            return;

        isOpening = true;
    }

    private void Start() {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update () {
		if(isOpening) {
            diff += offset * speed * Time.deltaTime;
            if (diff > offset) {
                diff = offset;
                isOpening = false;
                isOpened = true;
            }

            if(direction == DoorOpeningDirection.LEFT) {
				transform.position = pos + transform.right * diff;
            }
            else if(direction == DoorOpeningDirection.RIGHT) {
                transform.position = pos - transform.right * diff;
			}
        }
        else if(isOpened) {
            timer += Time.deltaTime;
            if(timer >= timeToClose) {
                isOpened = false;
                isClosing = true;
                timer = 0.0f;
            }
        }
        else if(isClosing) {
            diff -= offset * speed * Time.deltaTime;
            if(diff < 0.0f) {
                diff = 0.0f;
                isClosing = false;
            }
            if (direction == DoorOpeningDirection.LEFT) {
                transform.position = pos + new Vector3(0.0f, 0.0f, diff);
            }
            else if (direction == DoorOpeningDirection.RIGHT) {
                transform.position = pos - new Vector3(0.0f, 0.0f, diff);
            }
        }
	}
}
