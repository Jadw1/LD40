using UnityEngine;

public class Bilboarding : MonoBehaviour {

    private Vector3 direction;
	
	void Update () {
        direction = Camera.main.transform.forward;
        direction.y = 0.0f;
        
        transform.rotation = Quaternion.LookRotation(direction);        
	}
}
