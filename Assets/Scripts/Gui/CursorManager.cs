using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    public PauseMenu pause;
	
	void Update () {
		if(!pause.isPaused) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
}
