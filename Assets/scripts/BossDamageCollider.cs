using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageCollider : MonoBehaviour {

	// Use this for initialization
	public float collisionTimer;
	public float collissionThreshold = 1f;
	public BossStates states;
	public float meleeRate = 1f;
	public float nextAttack = 0f;
	public int damage = 10;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnTriggerStay2D(Collider2D col){
		//Debug.Log (col.gameObject);
		if (col.tag == "Player") {
			if (gameObject.GetComponentInParent<BossController> ().state != states.concentrating) {	
				if (Time.time > nextAttack) {
					gameObject.GetComponentInParent<BossController> ().state = states.melee;
					gameObject.GetComponentInParent<Animator> ().SetBool ("attackingMelee", true);
					Attack (col);
					nextAttack = Time.time + meleeRate;
					Debug.Log ("TOMAAAA c/u sec");
				}
				//Debug.Log (Time.time);
			}
		}
	}

	void Attack(Collider2D col) {
		if(col.tag == "Player"){
			col.GetComponent<PlayerActionsController>().receiveAttack(damage);
			col.GetComponent<PlayerActionsController> ().EndCooldown ();
			Debug.Log(col.GetComponent<PlayerStats>().hp);
		}
	}
}
