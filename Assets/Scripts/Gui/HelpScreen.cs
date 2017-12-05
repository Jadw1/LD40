using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour {

    public GameObject helpScreen;

    private bool isActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	private void Update () {
		if(Input.GetButton("Help")) {
            Activate();
        }
        else {
            Deactivate();
        }
	}

    private void Activate() {
        isActive = true;
        helpScreen.SetActive(true);
    }

    private void Deactivate() {
        isActive = false;
        helpScreen.SetActive(false);
    }
}
