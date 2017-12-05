using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenKnightController : MonoBehaviour {

	public float visionRadius;
	public float attackRadius;
	public float speed;
	GameObject player;
	Rigidbody2D rb2d;
	Animator anim;
	Vector3 initialPosition, target;

	[Tooltip("Prefab de la fireball que dispara el caballero")]
	public GameObject fireBall;
	[Tooltip("Velocidad con la que salen las bolas")]
	public float attackSpeed;
	bool attacking;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rb2d	= GetComponent<Rigidbody2D> ();
		anim	= GetComponent<Animator> ();
		initialPosition	= transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		target = initialPosition;

		RaycastHit2D hit = Physics2D.Raycast (
			                   transform.position,
			                   player.transform.position - transform.position,
			                   visionRadius,
			                   1 << LayerMask.NameToLayer ("Default")
		                   );

		// Para ver debug del raycast.
		Vector3 forward = transform.TransformDirection (player.transform.position - transform.position);
		Debug.DrawRay (transform.position, forward, Color.red);

		// El raycast encuentra al player
		if (hit.collider != null && hit.collider.tag == "Player") {
			target = player.transform.position;
		}

		// Distancia entre enemigo y player.
		float distance = Vector3.Distance(target, transform.position);
		Vector3 dir = (target - transform.position).normalized;

		// Cuando el player entra en el radio de ataque.
		if (target != initialPosition && distance < attackRadius) {
			anim.SetFloat ("movX", dir.x);
			anim.SetFloat ("movY", dir.y);
			anim.Play ("Golden_knight_BlendTree", -1, 0);
			if (!attacking) { StartCoroutine (Attack (attackSpeed)); }
		} else {
			// Si el player no esta en el radio de ataque y esta en el radio de deteccion lo persigue.
			rb2d.MovePosition (transform.position + dir * speed * Time.deltaTime);
			anim.speed = 1;
			anim.SetFloat ("movX", dir.x);
			anim.SetFloat ("movY", dir.y);
			anim.SetBool ("walking", true);
		}

		// Corrige bug cuando vuelve a la posicion inicial.
		if(target == initialPosition && distance < 0.02f){
			transform.position = initialPosition;
			anim.SetBool ("walking", false);
		}

		Debug.DrawLine (transform.position, target, Color.green);
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, visionRadius);
		Gizmos.DrawWireSphere (transform.position, attackRadius);
	}

	IEnumerator Attack(float seconds){
		attacking = true;
		if (target != initialPosition && fireBall != null) {
			Instantiate (fireBall, transform.position, transform.rotation);
			yield return new WaitForSeconds (seconds); // Espera <seconds> antes de volver a ejecutarse de nuevo.
		}
		attacking = false;
	}
}
