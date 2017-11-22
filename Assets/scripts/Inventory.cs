using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public IList inventory = new ArrayList(10);
	public int capacity = 0;
	public Button[] InventoryButtons = new Button[10];
	public Text console;
	public PlayerInteraction playerInteractionScript = GameObject.FindObjectOfType<PlayerInteraction> ();

	public void AddItem(Item item){
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



	/*
	public void AddItem(Item item){
		bool itemAdded	= false;
		// Agregar el item en el primer slot vacio.
		for(int i=0; i < capacity; i++){
			if(inventory[i] == null){
				inventory.Add (item);
				capacity += 1;
				// Actualizar GUI.
				InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
				console.text = item.name + " Obtained";
				//Debug.Log (item.name + " se agrego a tu inventario.");
				itemAdded	= true;
				// Se elimina el item.
				item.SendMessage ("DoInteraction");
				break;
			}
		}
		// El inventario esta lleno.
		if(!itemAdded){
			console.text = "¡Inventory is full !!";
		}
	}
	/*
	public bool FindItem(GameObject item){
		for (int i = 0; i < inventory.Length; i++) {
		
			if (inventory [i] == item) {return true;}
		}
		return false;
	}

	public GameObject FindItemByType(string itemType){
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] != null) {
				if (inventory [i]. GetComponent<InteractionObject> ().itemType == itemType) {
					return inventory [i];
				}
			}
		}
		return null;
	}

	public void RemoveItem(GameObject item){
		for(int i=0; i<inventory.Length; i++){
			if (inventory [i] == item) {
				inventory [i] = null;
				Debug.Log (item.name + " fue eliminado del inventario.");
				// Actualizar GUI.
				InventoryButtons[i].image.overrideSprite = null;
				break;
			}
		}
	}

	
*/

	public void UseItem(int position){
		Item it;
		if (inventory [position] != null) {
			it = (Item) inventory [position];
			it.SendMessage ("UseItem");
			console.text = "Se uso "+ it.name + ".";
			//RemoveItem (it);
		}
	}
}
