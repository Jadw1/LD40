using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : MonoBehaviour {

    public float damage = 40.0f;
    public float range = 50.0f;
    public float fireRate = 10.0f;

    private float timeToFire = 0.0f;
    
    public GameObject bulletHole;
    public LayerMask ignore;

	public AudioClip soundShoot;
	public AudioClip soundReload;

	private AudioSource audio;

	private void Start() {
		audio = GetComponent<AudioSource>();

		audio.clip = soundShoot;
	}

	private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
        RaycastHit hit;
        if(Input.GetButton("Fire1") && Time.time > timeToFire) {
            timeToFire = Time.time + 1 / fireRate;

			// Sound
			audio.PlayOneShot(soundShoot);

			// Hit logic
            if(Physics.Raycast(ray, out hit, range, ~ignore)) {
                if (hit.collider.tag == "Enemy") {
                    EnemyStats enemy = hit.collider.GetComponent<EnemyStats>();
                    if (enemy != null) {
                        enemy.dealDamage(damage);
                    }
                    else {
                        Debug.LogError("Cant find enemy!!!");
                    }
                }
                else {
                    Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
            }
        }
    }
}
