using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public float speed = 5f;
	public int health = 10;
	public Animator animator;
	public Rigidbody2D rigidBody;
	public Collider2D collider;
	private Vector2 movimiento;

	void Start () {
		this.animator.GetComponent<Animator> ();
		this.rigidBody.GetComponent<Rigidbody2D> ();
		this.collider.GetComponent<Collider2D> ();
	}

	void FixedUpdate (){
		this.checkMovement ();
		this.checkAnimation ();
		this.checkHealth ();
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
		if (this.collider.gameObject.tag == "Limit"){
			rigidBody.velocity = new Vector2(0,0);
			this.stopWalkingAnimation ();
		}
	}

	void stopWalkingAnimation(){
		this.animator.SetBool ("walking", false);
	}

	void checkHealth(){
		if (health > 0) {
			//health = health - 1;
			//Debug.Log ("Tu vida actual es de " + health);
		} else {
			//Debug.Log ("MORISTE");
		}
	}



}
