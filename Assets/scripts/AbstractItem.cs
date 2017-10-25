using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractItem : MonoBehaviour {
	public bool isStackable;
	public int countOfItem = 1;
	public string info;
	public GameObject player;

	public AbstractItem(bool stackable, string inf){
		isStackable = stackable;
		info = inf;
	}

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
		
	public void increaseOnOne(){
		countOfItem += 1;
	}
}
