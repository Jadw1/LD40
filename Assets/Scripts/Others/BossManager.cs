using UnityEngine;

public class BossManager : MonoBehaviour {

    public Door bossDoor;
    public bool first = true;


    private void OnTriggerEnter(Collider other) {
        if(first) {
            first = false;
            bossDoor.AddKey(gameObject);
        }
    }
}
