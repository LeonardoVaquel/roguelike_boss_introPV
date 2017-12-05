using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public string levelToLoad;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene (levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log (levelToLoad);	
		if (levelToLoad == "boss_floor") {
			GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position = new Vector3 (0f, -6f, 0f);
		} else {
			GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position = new Vector3 (0f, 0f, 0f);
		}
		SceneManager.LoadScene (levelToLoad);

	}
}
