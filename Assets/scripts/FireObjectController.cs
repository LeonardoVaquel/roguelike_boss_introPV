using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObjectController : MonoBehaviour {

	public float speed;
	public Rigidbody2D rigidBody;
	public bool alive;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//	rigidBody.velocity = new Vector2 (-speed, rigidBody.velocity.y);

	}

	void OnTriggerEnter2D(Collider2D col){
		
		if(col.tag != "boss" && col.tag != "DamageCollider" && col.tag != "boomerang"){
			Debug.Log(col.tag);
			Destroy(gameObject);	
		}

	}
}
