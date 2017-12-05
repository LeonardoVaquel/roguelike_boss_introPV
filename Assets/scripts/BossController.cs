using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public Animator animator;
	public BossStates states;
	public string state;

	// Use this for initialization
	void Start () {
		state = "IDLE";
		//Debug.Log ("WTF");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//	Debug.Log (state);
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(state == states.melee){
			gameObject.transform.GetChild (0).gameObject.SetActive (true);;
			//animator.SetBool ("attackingMelee", true);
			Debug.Log ("pegale");
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (state == states.melee) {
			GameObject.FindGameObjectWithTag ("DamageCollider").SetActive (false);
			animator.SetBool ("attackingMelee", false);
			Debug.Log ("saca la mano de ahi carajo");
		}
	}
		
}
