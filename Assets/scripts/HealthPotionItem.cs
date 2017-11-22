using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionItem : Item {
	public PlayerStats playerStats;

	public HealthPotionItem(): base(true, "Esta posion te cura 5 puntos de vida."){
	}

	void Start(){
		playerStats = GameObject.FindObjectOfType<PlayerStats> ();
	}

	public void UseItem ()	{
		playerStats.hp = playerStats.hp + 5;
	}
}
