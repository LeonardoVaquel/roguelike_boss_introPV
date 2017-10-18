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
	void Update () {
		rigidBody.velocity = new Vector2 (-2, rigidBody.velocity.y);
	}

	void OnColliderEnter2D(Collider col){
		if (col.tag == "Limit") {
			rigidBody.AddForce (new Vector2 (-2, 0));
		}

	}
}
