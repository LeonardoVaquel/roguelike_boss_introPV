﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public bool isStackable;
	public int countOfItem = 1;
	public string info;
	public GameObject player;

	public Item(bool stackable, string inf){
		isStackable = stackable;
		info = inf;
	}

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		DontDestroyOnLoad (gameObject);
	}
		
	public void increaseOnOne(){
		countOfItem += 1;
	}

	public void destroy(){
		gameObject.SetActive (false);
	}
}
