using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : MonoBehaviour {

    public float damage = 40.0f;
    public float range = 50.0f;
    public float fireRate = 10.0f;
    public float spread = 1.0f;

    private float timeToFire = 0.0f;
    
    public GameObject bulletHole;
    public LayerMask ignore;

	public AudioClip soundShoot;
	public AudioClip soundReload;

	private AudioSource audio;

    private bool fullAmmo = false;
    private int fullAmmoCount = 0;

	private void Start() {
		audio = GetComponent<AudioSource>();

		audio.clip = soundShoot;
	}

	private void FixedUpdate() {


        Ray ray = Camera.main.ScreenPointToRay(GetSpread());
        RaycastHit hit;
        if(Input.GetButton("Fire1") && Time.time >= timeToFire && PlayerStats.clip > 0) {
            if (fullAmmo)
                fullAmmoCount++;
            fullAmmo = true;

            timeToFire = Time.time + 1 / fireRate;

			// Sound
			audio.PlayOneShot(soundShoot);

			// Hit logic
            if(Physics.Raycast(ray, out hit, range, ~ignore)) {
                if (hit.collider.tag == "Enemy") {
                    EnemyStats enemy = hit.collider.GetComponent<EnemyStats>();
                    if (enemy != null) {
                        enemy.dealDamage(PlayerStats.damage);
                    }
                    else {
                        Debug.LogError("Cant find enemy!!!");
                    }
                }
                else {
                    Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
            }

            PlayerStats.RemoveOneBullet();
        }
        else if(!Input.GetButton("Fire1") && PlayerStats.clip > 0) {
            fullAmmo = false;
            fullAmmoCount = 0;
        }
    }

    private void Update() {
        if(Input.GetButtonDown("Reload") && PlayerStats.IsReloadingPossible()) {
            Reload();
        }
    }

    private void Reload() {
        audio.PlayOneShot(soundReload);
        PlayerStats.Reload();
    }

    private Vector3 GetSpread() {
        Vector3 point = new Vector3(Screen.width / 2, Screen.height / 2, 0.0f);
        Vector3 spreadVec = Random.insideUnitSphere * fullAmmoCount * spread;
        spreadVec.z = 0;

        return point + spreadVec;
    }
}
