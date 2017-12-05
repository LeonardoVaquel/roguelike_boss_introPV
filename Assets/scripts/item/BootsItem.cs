using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsItem : Item {
	public PlayerStats playerStats;

	public BootsItem(): base(true, "Estas botas te aumenta 3 puntos de defensa"){
	}

	void Start(){
		playerStats = GameObject.FindObjectOfType<PlayerStats> ();
	}

	public void UseItem ()	{
		playerStats.res = playerStats.res + 3;
	}
}
