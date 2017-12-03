using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public float interactRange = 30.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Interact")) {
            Debug.Log("as");
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, interactRange)) {
                Debug.Log(hit.collider.name);
                if(hit.collider.tag == "Door") {
                    Door door = hit.collider.GetComponent<Door>();
                    if(door != null) {
                        door.Open();
                    }
                    else {
                        Debug.LogError("ERROR!");
                    }
                }
            }
        }		
	}
}
