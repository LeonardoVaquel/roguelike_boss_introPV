using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageCollider : MonoBehaviour {

	// Use this for initialization
	public BossStates states;
	public float meleeRate = 1f;
	public float nextAttack = 0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnTriggerStay2D(Collider2D col){
		if (Time.time > nextAttack) {
			gameObject.GetComponentInParent<BossController> ().state = states.melee;
			gameObject.GetComponentInParent<Animator> ().SetBool ("attackingMelee", true);
			nextAttack = Time.time + meleeRate;
			Debug.Log ("TOMAAAA c/u sec");
		}
		//Debug.Log (Time.time);
	}
}
