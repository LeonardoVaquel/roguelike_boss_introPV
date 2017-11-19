using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

        public int lvl;
        public int exp;
        public int hp;
        public int maxHP;
        public int mp;
        public int str;
        public int res;
        // magic power
        public int mnd;
        //magic defense
        public int spr;
        public int dex;

	void Start(){
		lvl = 1;
		exp = 0;
		str = 10;
		hp = 100;
		maxHP = 100;
		mp = 30;
		res = 8;
		mnd = 1;
		spr = 1;
		dex = 5;
	}
}
