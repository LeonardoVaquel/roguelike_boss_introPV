using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStates : MonoBehaviour {

	public ArrayList states;
	public string idle;
	public string walking;
	public string concentrating;
	public string powerwave;
	public string melee;
	public string boomerang;
	public string monsterspawning;
	public string dead;


	// Use this for initialization
	void Start () {
		idle = "IDLE";
		walking = "WALKING";
		concentrating = "CONCENTRATING";
		powerwave = "POWERWAVE";
		melee = "MELEE";
		boomerang = "BOOMERANG";
		monsterspawning = "MONSTERSPAWNING";
		dead = "DEAD";
		states = new ArrayList ();
		states.Add (idle);
		states.Add (walking);
		states.Add (concentrating);
		states.Add (powerwave);
		states.Add (melee);
		states.Add (boomerang);
		states.Add (monsterspawning);
		states.Add (dead);
		/*
		states = new ArrayList ();
		states.Add ("IDLE");
		states.Add ("WALKING");
		states.Add ("CONCENTRATING");
		states.Add ("POWERWAVE");
		states.Add ("MELEE");
		states.Add ("BOOMERANG");
		states.Add ("MONSTERSPAWNING");
		states.Add ("DEAD");
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
