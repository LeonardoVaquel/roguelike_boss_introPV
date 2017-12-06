using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

	public Image currentHealthBar;
	public Text hpVarValue;
	public BossController bossController;

	// Use this for initialization
	void Start() {
	}

	// Update is called once per frame
	void FixedUpdate() {
		receiveDamage();
	}

	void receiveDamage() {
		Debug.Log (bossController.hp + "dsadsads");
		if (bossController.hp >= 0) {
			float ratio = (float)bossController.hp / (float)bossController.maxhp;
			currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
			//hpVarValue.text = playerStats.hp.ToString();
			//            Debug.Log(ratio);
		}
	}
}