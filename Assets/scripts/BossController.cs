using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public Animator animator;
	public BossStates states;
	public string state;

	public Transform firePoint1, firePoint2, firePoint3, firePoint4;
	public GameObject boomerang;

	// Use this for initialization
	void Start () {
		state = "BOOMERANG";
		//Debug.Log ("WTF");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (state == states.boomerang && (GameObject.FindGameObjectsWithTag("boomerang").Length < 4)) {
			animator.SetBool ("attackingWithBoomerang", true);
			Instantiate (boomerang, firePoint1.position, firePoint1.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.up * 210);
			Instantiate (boomerang, firePoint2.position, firePoint2.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.down * 210);
			Instantiate (boomerang, firePoint3.position, firePoint3.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.right * 210);
			Instantiate (boomerang, firePoint4.position, firePoint4.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.left * 210);
		}

	//	Debug.Log (state);
		
	}

	void OnTriggerEnter2D(Collider2D col){
//		Debug.Log (col);
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
