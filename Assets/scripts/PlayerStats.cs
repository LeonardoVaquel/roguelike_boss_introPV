using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		/*Debug.Log ("sdfjsajdaslkdjaslk");
		Debug.Log (GameObject.Find ("StatsCanvas"));
		string objectPath = "GUI/StatsCanvas/StatsPanel/StatsValues/";
		lvlValue 	= GameObject.Find ("LvlValue").GetComponent<Text> ();
		expValue 	= GameObject.Find ("ExpValue").GetComponent<Text> ();
		mpValue		= GameObject.Find ("EnergiaValue").GetComponent<Text> ();
		strValue	= GameObject.Find ("StrValue").GetComponent<Text> ();
		resValue	= GameObject.Find ("ResValue").GetComponent<Text> ();
		mndValue	= GameObject.Find ("MagicDamageValue").GetComponent<Text> ();
		dexValue	= GameObject.Find ("DexValue").GetComponent<Text> ();
		statsCanvas = GameObject.Find ("StatsCanvas").GetComponent<Canvas> ();

*/

		lvl = 1;
		exp = 0;
		str = 10;
		hp = 100;
		maxHP = 100;
		mp = 30;
		res = 8;
		mnd = 1;
		dex = 5;
	}

	void FixedUpdate(){
	}

	public void refreshStats(){
/*		lvlValue.text 	= lvl.ToString ();
		expValue.text	= exp.ToString ();
		mpValue.text 	= mp.ToString ();
		strValue.text	= str.ToString ();
		resValue.text	= res.ToString ();
		mndValue.text	= mnd.ToString ();
		dexValue.text	= dex.ToString (); */
	}
}
