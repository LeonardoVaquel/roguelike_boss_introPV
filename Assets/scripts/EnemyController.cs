using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Rigidbody2D rigidBody;
    public PolygonCollider2D collider;
    public GameObject player;
    public GameObject enemy;
    public Animator playerAnimator;
    public SpriteRenderer enemySpriteRenderer;
    // deberia ir en otro controller (de stats de mostro por ej...)
    public int hp = 30;
    public int exp = 10;

    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<PolygonCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemySpriteRenderer = enemy.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        followPlayer();
        lookTowardPlayer();
        dissapearWhenDead();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        rigidBody.velocity = new Vector2(0, 0);
    }

    // enemy follows player when he walks
    void followPlayer() {
        Vector2 player2Position = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 offset = new Vector2(0.75f, 0);
        if (playerAnimator.GetBool("walking") || playerAnimator.GetBool("isAttacking")) {
            // current, target (offset para que no se pisen los prites), velocity
            transform.position = Vector2.MoveTowards(transform.position, (player2Position + offset), 0.024f);
        }
    }
    // enemy always looks at the direction of the player
    void lookTowardPlayer() {
        if (enemy.transform.position.x < player.transform.position.x) {
            enemySpriteRenderer.flipX = true;
         //   Debug.Log("xq no me doy vuelta???");
        }
        else {
            //Debug.Log("que pasa???");
            enemySpriteRenderer.flipX = false;
        }
    }

    void dissapearWhenDead() {
        //TODO: que se desvanezca (efecto)
        if (hp <= 0) {
            this.gameObject.SetActive(false); ;
        }
    }
}
