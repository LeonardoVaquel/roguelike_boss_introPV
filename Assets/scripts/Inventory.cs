using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject[] inventory = new GameObject[10];
	public Button[] InventoryButtons = new Button[10];

	public void AddItem(GameObject item){
		bool itemAdded	= false;
		// Agregar el item en el primer slot vacio.
		for(int i=0; i < inventory.Length; i++){
			if(inventory[i] == null){
				inventory [i] = item;
				// Actualizar GUI.
				InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
				Debug.Log (item.name + " se agrego a tu inventario.");
				itemAdded	= true;
				// Se elimina el item.
				item.SendMessage ("DoInteraction");
				break;
			}
		}
		// El inventario esta lleno.
		if(!itemAdded){
			Debug.Log("¡El inventario esta lleno!");
		}
	}

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






}
