using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCalculator : MonoBehaviour {

    PlayerStats stats;
    //Equipment equipment;

    // Update is called once per frame
    void FixedUpdate() {
        stats = GameObject.FindObjectOfType<PlayerStats>();
        //equipment = GameObject.FindObjectOfType<Equipment>();
    }

    public int MeleeAttackDamage() {
        int baseDamage = stats.str + stats.lvl;
        int criticalFactor = CritiCalDamage(stats.dex);
        Debug.Log("critical: " + criticalFactor);
        // if an offensive weapon is equipped then...
       /* if (equipment.weapon) {
            var weaponStats = equipment.weapon.GetComponent<EquipableOffensiveItem>();
            baseDamage = stats.str + weaponStats.ATK * ((stats.lvl / 2) + 1);
        }
        */
        return baseDamage * criticalFactor;
    }

    public bool IsCriticalHit(int dex) {
        int random = Random.Range(1, 100);
        int criticalRate = ((stats.dex + 1) / 256) * 100;
        return criticalRate >= random;
    }

    public int CritiCalDamage(int dex) {
        int criticalFactor = 1;
        if (IsCriticalHit(dex)) { criticalFactor = 2; }
        return criticalFactor;
    }
}
