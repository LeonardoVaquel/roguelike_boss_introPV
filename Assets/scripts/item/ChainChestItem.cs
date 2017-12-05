using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainChestItem : Item {
	public PlayerStats playerStats;

	public ChainChestItem(): base(true, "Esta pechera te aumenta 7 puntos de defensa"){
	}

	void Start(){
		playerStats = GameObject.FindObjectOfType<PlayerStats> ();
	}

	public void UseItem ()	{
		playerStats.res = playerStats.res + 7;
	}
}