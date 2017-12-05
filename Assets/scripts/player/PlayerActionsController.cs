using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionsController : MonoBehaviour {

    private BattleCalculator battleCalculator;
    private PlayerStats stats;
    private Rigidbody2D rigidBody;
    private Inventory inventory;
	public SpriteRenderer renderer;
	public bool receivingDamage = false;
	public float invisibilityRate = 1f;
	public float nextInvisibility = 0f;
	public bool call = true;

    // Use this for initialization
    void Start() {
        stats = GameObject.FindObjectOfType<PlayerStats>();
        battleCalculator = GameObject.FindObjectOfType<BattleCalculator>();
        //inventory = GameObject.FindObjectOfType<Inventory>();
        //equipment = GameObject.FindObjectOfType<Equipment>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
		//Debug.Log (" a ver esa invisibilidasd,sad,;sadd");
	//	if(call) {
			StartCoroutine(EndCooldown ());
	//		call = false;
	//}


    
	}


    void OnCollisionStay2D(Collision2D collision) {
        if (MeleeAttackAtEnemy(collision)) {
            GameObject enemy = collision.gameObject;
            MeleeAttack(enemy);
        }
        /*    if (PickingUpItem(collision)) {
                var item = collision.gameObject;
                inventory.AddItem(item);
            }
            */
    }

    bool MeleeAttackAtEnemy(Collision2D collision) {
        return collision.gameObject.tag == "Enemy" && Input.GetKeyDown("z");
    }

    void MeleeAttack(GameObject enemy) {
        var enemyStats = enemy.GetComponent<BatController>();
        enemyStats.hp -= battleCalculator.MeleeAttackDamage();
        if (enemyStats.hp <= 0) {
            stats.exp += enemyStats.exp;
        }
        // character stats
       // Debug.Log("str: " + stats.str);
       // Debug.Log("res: " + stats.res);
       // Debug.Log("mnd: " + stats.mnd);
       // Debug.Log("spr: " + stats.spr);
        //Debug.Log("damage: " + battleCalculator.MeleeAttackDamage());
        //Debug.Log("enemy hp:" + enemyStats.hp);
       // Debug.Log("EXP: " + stats.exp);
    }

    /* lo dejo como recordatorio de que lo nuevo deberia ir aca
    public bool PickingUpItem(Collision2D collision) {
        return collision.gameObject.tag == "item" && Input.GetKeyDown("z");
    }
    */

    /* recordatorio
    private void setEquipment() {
        if (!equipment.weapon) {
            equipment.weapon = inventory.inventory[0];
            equipment.equipWeapon();
        }
        if (!equipment.armor) {
            equipment.armor = inventory.inventory[1];
            equipment.equipDefense();
            //  Debug.Log(equipment.weapon);
        }
        if (!equipment.accessory) {
            equipment.accessory = inventory.inventory[2];
            equipment.equipAccessory();
        }
    }
    */
    public void receiveAttack(int damage) {
		if (receivingDamage != true) {
			Debug.Log (" aca entro");
			stats.hp -= damage;
			receivingDamage = true;
			renderer.color = Color.red;
		}
    }
		

	public IEnumerator EndCooldown() { 
		
		if (receivingDamage == true) {
			yield return new WaitForSeconds (1);
			call = true;
			receivingDamage = false;
			renderer.color = Color.white;
		//	Debug.Log (" a ver esa invisibilidad");
		}
	}


	public void WaitFor(){
		// aproximadamente un segundo de espera
		for (int i = 0; i <= 2; i++) {
			if (Time.time > nextInvisibility) {
				nextInvisibility = Time.time + invisibilityRate;
				Debug.Log ("esperamos 5 sec");
			}
		}
	}


}