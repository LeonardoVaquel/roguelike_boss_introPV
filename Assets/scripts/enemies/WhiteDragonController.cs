using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteDragonController : MonoBehaviour {

	public float cooldown;
	public GameObject bullet;
	public Animator animator;
	public GameObject player;
	bool puedoAtacar;
	public string orientation;
	public int hp;
	public int exp;

	void Start(){
		animator = GetComponent<Animator> ();
		cooldown = 2f;
		hp	= 25;
		exp = 50;
	}

	void FixedUpdate(){
		if(orientation == "right"){
			transform.SetPositionAndRotation (transform.position, new Quaternion (0,200,0,0));
		}

		if (puedoAtacar) {
			animator.SetTrigger ("attacking");
			puedoAtacar = false;
			if (orientation == "right") {
				Instantiate (bullet, transform.position, transform.rotation).SendMessage ("setDir", "right");
			} else {
				Instantiate (bullet, transform.position, transform.rotation);
			}
		}

		CheckCooldown ();
	}

	void CheckCooldown(){
		if (cooldown > 0 && !puedoAtacar) {
			cooldown -= 1 * Time.deltaTime;
		} else {
			puedoAtacar = true;
			cooldown = 2f;
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown("z")){
			col.gameObject.GetComponent<PlayerStats> ().exp += this.exp;
			Destroy (gameObject);
		}
	}

}

