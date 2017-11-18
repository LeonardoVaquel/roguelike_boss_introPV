using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionItem : AbstractItem {
	public PlayerStats player = GameObject.FindObjectOfType<PlayerStats> ();

	public HealthPotionItem(): base(true, "Esta posion te cura 5 puntos de vida."){
		
	}

	public void UseItem ()	{
		player.hp = player.hp + 5;
	}
}
