using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteDragon_Bullet : MonoBehaviour {

	[Tooltip("Velocidad de moviemiento en unidades del mundo")]
	public float speed;
	GameObject player;
	Rigidbody2D rb2d;
	public string dir;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		if (dir == "right") {
			Vector2 mov = Vector2.right;
			rb2d.MovePosition (rb2d.position + mov * speed * Time.deltaTime);
		} else {
			Vector2 mov = Vector2.left;
			rb2d.MovePosition (rb2d.position + mov * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player") ) {
			col.gameObject.SendMessage ("recibeDamage", 5);
			Destroy (gameObject);
		}
		if (col.CompareTag ("Limit")) {
			Destroy (gameObject);
		}
	}
		

	// Si sale de la pantalla se destruya la fireball.
	void OnBecameInvisible(){
		Destroy (gameObject);
	}

	public void setDir(string dir2){
		dir = dir2;
	}
}
