using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorOpeningDirection {
    RIGHT,
    LEFT
};

public class Door : MonoBehaviour {

    public DoorOpeningDirection direction;

	public List<GameObject> keys;
    public SpriteRenderer[] diodes;
    public Color positiveColor;
    public Color negativeColor;

	public AudioClip doorLockedSound;

    public float speed = 5.0f;
    public float offset = 2.5f;
    private float diff = 0.0f;
    private Vector3 pos;

    public float timeToClose = 10.0f;
    private float timer = 0.0f;
    private bool isOpened = false;
    private bool isOpening = false;
    private bool isClosing = false;

	private AudioSource audio;

    public void AddKey(GameObject key) {
        keys.Add(key);
    }

    public void RemoveAllKeys() {
        keys = new List<GameObject>();
    }

    private bool IsKeysEmpty() {
        foreach(GameObject key in keys) {
            if (key != null)
                return false;
        }

        return true;
    }

    public void Open() {
        if (isOpened)
            return;

		if (!IsKeysEmpty()) {
			audio.PlayOneShot(doorLockedSound);
			return;
		}

        isOpening = true;

		audio.Play();
    }

    private void Start() {
        pos = transform.position;

		audio = GetComponent<AudioSource>();
    }

    private void CheckKeys() {
        for (int i = 0; i < diodes.Length; i++) {
			bool lit = true;

			if (i < keys.Count && keys[i] != null) lit = false;

			diodes[i].color = lit ? positiveColor : negativeColor;
		}
    }

    void Update () {
		CheckKeys();

		if (isOpening) {
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

				audio.Play();
			}
        }
        else if(isClosing) {
            diff -= offset * speed * Time.deltaTime;
            if(diff < 0.0f) {
                diff = 0.0f;
                isClosing = false;
            }
            if (direction == DoorOpeningDirection.LEFT) {
                transform.position = pos + transform.right * diff;
            }
            else if (direction == DoorOpeningDirection.RIGHT) {
                transform.position = pos - transform.right * diff;
            }
        }
	}
}
