using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    public Image currentHealthBar;
	public Text hpVarValue;
    private PlayerStats playerStats;

    // Use this for initialization
    void Start() {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void FixedUpdate() {
        receiveDamage();
    }

    void receiveDamage() {
        if (playerStats.hp >= 0) {
            float ratio = (float)playerStats.hp / (float)playerStats.maxHP;
            currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
			hpVarValue.text = playerStats.hp.ToString();
//            Debug.Log(ratio);
        }
    }
}