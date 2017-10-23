using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsController : MonoBehaviour {

    private BattleCalculator battleCalculator;
    private PlayerStats stats;
    private Rigidbody2D rigidBody;
    private Inventory inventory;

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
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (MeleeAttackAtEnemy(collision)) {
            Debug.Log("wacho me atacan ");
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
        var enemyStats = enemy.GetComponent<EnemyController>();
        enemyStats.hp -= battleCalculator.MeleeAttackDamage();
        if (enemyStats.hp <= 0) {
            stats.exp += enemyStats.exp;
        }
        // character stats
        Debug.Log("str: " + stats.str);
        Debug.Log("res: " + stats.res);
        Debug.Log("mnd: " + stats.mnd);
        Debug.Log("spr: " + stats.spr);
        //Debug.Log("damage: " + battleCalculator.MeleeAttackDamage());
        Debug.Log("enemy hp:" + enemyStats.hp);
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
    private void recalculateStats() {

    }
}