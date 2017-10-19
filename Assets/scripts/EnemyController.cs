using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Rigidbody2D rigidBody;
	public PolygonCollider2D collider;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		collider = GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidBody.velocity = new Vector2 (-2, 0);
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Limit"){
			rigidBody.velocity = new Vector2(10,0);
		}

	}
}
