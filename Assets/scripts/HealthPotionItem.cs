using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionItem : AbstractItem {

	public HealthPotionItem(): base(true, "Esta posion te cura 5 puntos de vida."){
		
	}

	public void UseItem ()	{
		player.SendMessage ("heal", 5);
	}
}
