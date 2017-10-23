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
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("saranga");
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
        }
        else {
            enemySpriteRenderer.flipX = false;
        }
    }
}
