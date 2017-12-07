using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public float speed = 5f;
	public int health = 10;
	public float cooldown = 0.0f;
	public AudioSource audio;
	public Animator animator;
	public Rigidbody2D rigidBody;
	public Collider2D collider;
	private Vector2 movimiento;
	bool puedoAtacar = true;
	public PlayerStats stats;
	public float time = 0f;

	void Start () {
		this.animator.GetComponent<Animator> ();
		this.rigidBody.GetComponent<Rigidbody2D> ();
		this.collider.GetComponent<Collider2D> ();
		this.audio.GetComponent<AudioSource> ();
	}

	void FixedUpdate (){
		this.checkMovement ();
		this.checkAnimation ();
		this.checkIsAttacking ();
		this.checkHealth ();
		this.CheckCooldown ();
		Debug.Log (stats.hp);
	}

	void checkMovement(){
		movimiento	= new Vector2 (	Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical") );
		rigidBody.MovePosition (rigidBody.position + movimiento * speed * Time.deltaTime);
	}
		
	// Bindeo de parametros de animación con variables.
	void checkAnimation(){
		if (movimiento != Vector2.zero) {
			this.animator.SetFloat ("movX", movimiento.x);
			this.animator.SetFloat ("movY", movimiento.y);
			this.animator.SetBool ("walking", true);
		} else {
			this.stopWalkingAnimation ();
		}
	}

	// Colición con objetos que sean límites.
	void OnCollisionStay2D(Collision2D collision){
		time += Time.deltaTime ;
		if (this.collider.gameObject.tag == "Limit"){
			rigidBody.velocity = new Vector2(0,0);
			this.stopWalkingAnimation ();
		}
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		bool isAttacking = stateInfo.IsName ("Player_attack");
		if (collision.gameObject.tag == "boss" && isAttacking) {
			if (time > 1) {
			collision.gameObject.GetComponentInParent<BossController> ().hp -= stats.str;;
		//	Debug.Log ("hp boss: " + collision.gameObject.GetComponentInParent<BossController>().hp);
			time = 0f;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D collision){
	//	Debug.Log ("boom" + collision.gameObject.tag);
		if (collision.gameObject.tag == "boomerang") {
	//		Debug.Log ("hp" + stats.hp);
			stats.hp -= 10;
		}
	}

	void checkIsAttacking(){
		
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		bool isAttacking = stateInfo.IsName ("Player_attack");

		if (!isAttacking && Input.GetButtonDown ("Attack") && puedoAtacar) {
			animator.SetTrigger ("attacking");
			this.audio.Play ();
			puedoAtacar = false;
		}

	}

	void CheckCooldown(){
		if (cooldown > 0 && !puedoAtacar) {
			cooldown -= 1 * Time.deltaTime;
		} else {
			puedoAtacar = true;
			cooldown = 1f;
		}
	}

	void stopWalkingAnimation(){
		this.animator.SetBool ("walking", false);
	}

	void checkHealth(){
		if (health > 0) {
			//Debug.Log ("Tu vida actual es de " + health);
		} else {
			Debug.Log ("MORISTE");
		}
	}

	public void healthPlayer(int n){
		if (health + n < 10) {
			health += n;
		} else {
			health = 10;
		}
	}

	public void recibeDamage(int damage){
		if (health - damage > 0) {
			health -= damage;
		} else {
			health = 0;
		}
	}

	public int getDamage(){
		return stats.str;
	}
		

}
