using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour {

	public Canvas statsCanvas;
	private bool enableCanvas;
	public PlayerStats statsScript;

	// Use this for initialization
	void Start () {
		statsCanvas = GameObject.Find ("StatsCanvas").GetComponent<Canvas> ();
		statsScript = GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ();
		enableCanvas = false;
		statsCanvas.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetKeyDown (KeyCode.C)) {
			if (enableCanvas) {
				statsCanvas.gameObject.SetActive (false);
				enableCanvas = false;
			} else {
				
				statsCanvas.gameObject.SetActive (true);
				statsScript.refreshStats ();
				enableCanvas = true;
			}
		} 

	}
}
