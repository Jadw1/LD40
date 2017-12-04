using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    public float damage = 60.0f;
    public float range = 3.0f;
    public float rate = 10.0f;

    private float timeToAttack = 0.0f;

    public LayerMask ignore;

    public GameObject enemyBlood;
    public Riffle riffle;

	private MeleeAnim anim;

	private void Start() {
		anim = GetComponent<MeleeAnim>();
	}

	private void FixedUpdate() {
        if(Input.GetButtonDown("Fire2") && anim.CanSwing()) {
			anim.StartAnim();
            timeToAttack = Time.time + 1 / rate;
        }
    }

	public bool CanShoot() {
		return anim.CanSwing();
	}

    //To wywołaj jak będzie srodkowa klatka
    public void MeleeAttack() {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, ~ignore)) {
            if (hit.collider.tag == "Enemy") {
                EnemyStats enemy = hit.collider.GetComponent<EnemyStats>();
                if (enemy != null) {
                    enemy.dealDamage(PlayerStats.damage);

                    Transform blood = Instantiate(enemyBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)).transform;
                    blood.parent = hit.collider.transform;
                }
                else {
                    Debug.LogError("Cant find enemy!!!");
                }
            }
            else if (hit.collider.tag == "Destroyable") {
                EnemyStats destroyable = hit.collider.GetComponent<EnemyStats>();
                if (destroyable != null) {
                    destroyable.dealDamage(PlayerStats.damage);
                }
                else {
                    Debug.LogError("Cant find destroyable!!!");
                }
            }
        }
    }
}
