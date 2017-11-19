using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuiController : MonoBehaviour {

	public Canvas statsCanvas;
	private bool enableCanvas;
	public PlayerStats statsScript;
	public GameObject player;

	// GUI objects
	public Text lvlValue;
	public Text expValue;
	public Text mpValue;
	public Text strValue;
	public Text resValue;
	public Text mndValue;
	public Text dexValue;

	void Start () {
		statsCanvas = GameObject.Find ("StatsCanvas").GetComponent<Canvas> ();
		statsScript = player.GetComponent<PlayerStats> ();
		enableCanvas = false;
		statsCanvas.gameObject.SetActive (false);
	}

	void FixedUpdate () {
		showCanvas ();
	}

	// opens canvas in game scene when pressing 'c'
	void showCanvas(){
		if (Input.GetKeyDown (KeyCode.C)) {
			if (enableCanvas) {
				statsCanvas.gameObject.SetActive (false);
				enableCanvas = false;
			} else {
				statsCanvas.gameObject.SetActive (true);
				showPlayerStats();
				enableCanvas = true;
			}
		} 
	}


	void showPlayerStats(){
			getPlayerStatsTexts ();
			refreshStats ();
	}

	// retrieves the text objects from the scene
	void getPlayerStatsTexts(){
		lvlValue 	= GameObject.Find ("LvlValue").GetComponent<Text> ();
		expValue 	= GameObject.Find ("ExpValue").GetComponent<Text> ();
		mpValue		= GameObject.Find ("EnergiaValue").GetComponent<Text> ();
		strValue	= GameObject.Find ("StrValue").GetComponent<Text> ();
		resValue	= GameObject.Find ("ResValue").GetComponent<Text> ();
		mndValue	= GameObject.Find ("MagicDamageValue").GetComponent<Text> ();
		dexValue	= GameObject.Find ("DexValue").GetComponent<Text> ();
	}

	// sets the values of the texts with the actual player stats values
	public void refreshStats(){
		lvlValue.text 	= statsScript.lvl.ToString ();
		expValue.text	= statsScript.exp.ToString ();
		mpValue.text 	= statsScript.mp.ToString ();
		strValue.text	= statsScript.str.ToString ();
		resValue.text	= statsScript.res.ToString ();
		mndValue.text	= statsScript.mnd.ToString ();
		dexValue.text	= statsScript.dex.ToString ();
	}
}
