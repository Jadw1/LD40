using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicMusicZone : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        MusicManager.StartEpicMusic();
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
