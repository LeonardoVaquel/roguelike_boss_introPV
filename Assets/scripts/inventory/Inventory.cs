using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public ArrayList inventory = new ArrayList(10);
	public int capacity = 0;
	public Button[] InventoryButtons = new Button[10];
	public Text console;
	public PlayerInteraction playerInteractionScript;

	void Start(){
		playerInteractionScript = GameObject.FindObjectOfType<PlayerInteraction> ();
		DontDestroyOnLoad (gameObject);
	}

	public void AddItem(GameObject item){
		if (capacity < 10) {
			inventory.Add (item);
			int itemPosition = inventory.IndexOf (item);
			console.text = itemPosition.ToString ();
			InventoryButtons[itemPosition].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
			capacity += 1;
			item.SendMessage ("DoInteraction");
			console.text = item.name + " Obtained";
			playerInteractionScript.itemAdded ();
		}
	}

	public void RemoveItem(GameObject item){
		for(int i=0; i<inventory.Capacity; i++){
			if (inventory [i] == item) {
				inventory [i] = null;
				InventoryButtons[i].image.overrideSprite = null;
				break;
			}
		}
	}


	public void UseItem(int position){
		GameObject it;
		if (inventory [position] != null) {
			it = (GameObject) inventory [position];
			it.SendMessage ("UseItem");
			console.text = it.name + " has been used";
			RemoveItem (it);
			it.SendMessage ("destroy");
		}
	}
}
