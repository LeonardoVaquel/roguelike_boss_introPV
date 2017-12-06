using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public Animator animator;
	public BossStates states;
	public GameObject player;
	public string state;
	public float time = 0f;
	public float nextAttack = 0f;
	public float boomerangRate = 10f;
	public float concentratingRate = 40f;
	public float meleeRate = 40f;
	public float powerWaveRate = 1f;
	public GameObject meleeCol;
	public int hp;
	public Transform firePoint1, firePoint2, firePoint3, firePoint4;
	public GameObject boomerang;
	public GameObject powerWave, powerWaveVertical;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		state = "MELEE";
		//hp = 300;
		//Debug.Log ("WTF");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//	Debug.Log (state);
		//state = (string) states.states[Random.Range(0, 5)];
		time += Time.deltaTime ;
		if (state == states.boomerang && (GameObject.FindGameObjectsWithTag("boomerang").Length < 4)) {
			
			animator.SetBool ("attackingWithBoomerang", true);
			Instantiate (boomerang, firePoint1.position, firePoint1.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.up * 210);
			Instantiate (boomerang, firePoint2.position, firePoint2.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.down * 210);
			Instantiate (boomerang, firePoint3.position, firePoint3.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.right * 210);
			Instantiate (boomerang, firePoint4.position, firePoint4.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.left * 210);
			if (time > boomerangRate) {
				state = (string) states.states[Random.Range(0, 5)];
				time = 0f;
				animator.SetBool ("attackingWithBoomerang", false);
			}
			CheckIfDead ("attackingWithBoomerang");
		}
		if (state == states.concentrating) {
			//Debug.Log (state);
			animator.SetBool ("concentrating", true);
			if (time > concentratingRate) {
				state = states.powerwave;
				animator.SetBool ("concentrating", false);
				time = 0f;
			}
			CheckIfDead ("concentrating");
		}
		//Debug.Log(state == states.powerwave && (GameObject.FindGameObjectsWithTag("boomerang").Length < 4));
		if (state == states.powerwave && (GameObject.FindGameObjectsWithTag("boomerang").Length < 4)) {
			//Debug.Log("xq");
			//Debug.Log(GameObject.FindGameObjectsWithTag("boomerang").Length);
			animator.SetBool ("attackingWave", true);
			Instantiate (powerWaveVertical, firePoint1.position, firePoint1.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.up * 510);
			GameObject downBullet = Instantiate (powerWaveVertical, firePoint2.position, firePoint2.rotation);
			downBullet.GetComponent<SpriteRenderer> ().flipY = true;
			downBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 510);
			GameObject rightBullet = Instantiate (powerWave, firePoint3.position, firePoint3.rotation);
			rightBullet.GetComponent<SpriteRenderer> ().flipX = true;
			rightBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 510);
			Instantiate (powerWave, firePoint4.position, firePoint4.rotation).GetComponent<Rigidbody2D>().AddForce(Vector3.left * 510);

			if (time > powerWaveRate) {
//				Debug.Log("xq");
				state = (string) states.states[Random.Range(0, 5)];
				time = 0f;
				animator.SetBool ("attackingWave", false);
				}
			CheckIfDead ("attackingWave");
		}
		if (state == states.idle) {
			//Debug.Log (state);
			if (time > concentratingRate) {
				state = (string) states.states[Random.Range(0, 5)];
				time = 0f;
			}

		}
		Debug.Log (hp < 1);
		if (state == states.melee) {
			if(Vector3.Distance(transform.position, player.transform.position) >= 1){
				//transform.LookAt (player.transform);
				//transform.position += transform.forward * 0.1f * Time.deltaTime;	
				transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
			}
			if (time > meleeRate) {
				state = (string) states.states[Random.Range(0, 5)];
				animator.SetBool ("attackingMelee", false);
				time = 0f;
			}
			CheckIfDead ("attackingMelee");
		}


		Debug.Log (hp);
		
	}

	void CheckIfDead(string anim){
		Debug.Log (hp < 1);
		if (hp < 1) {
			Debug.Log ("chequeo");
			animator.SetBool (anim, false);
			state = states.dead;
			animator.SetInteger ("hp", 0);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
//		Debug.Log (col);
		if(state == states.melee){
			Transform[] trs = gameObject.GetComponentsInChildren<Transform> (true);
			foreach (Transform t in trs) {
				if(t.name == "damage_collider"){
					t.gameObject.SetActive (true);
				}
			}
			
			//animator.SetBool ("attackingMelee", true);
		//	Debug.Log ("pegale");
		}
	}

	void OnTriggerExit2D(Collider2D col){
	//	Debug.Log ("saca la mano de ahi carajo");
		if (state == states.melee) {
			GameObject.FindGameObjectWithTag ("DamageCollider").SetActive (false);
			animator.SetBool ("attackingMelee", false);
	//		Debug.Log ("sacsdsa la mano de ahi carajo");
		}
	}
		
		
}
