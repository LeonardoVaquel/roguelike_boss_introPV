using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public GameObject currentItem	= null;
	public InteractionObject interactionObjectScript = null;
	public Inventory inventory;
	public AudioSource audio;

	void start(){
		this.inventory	= GetComponent<Inventory> ();
		this.interactionObjectScript = currentItem.GetComponent<InteractionObject> ();
		this.audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Interact") && currentItem) { // La tecla X sirve para interactuar.
			// Ver si el item ya esta almacenado.
			if(interactionObjectScript.inventory){
				audio.Play ();
				inventory.AddItem (currentItem);
			}
		}
		checkIfUseItem ();
	}

	public void itemAdded(){
		currentItem = null;
	}

	void checkIfUseItem(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){inventory.UseItem (0);}
		if(Input.GetKeyDown(KeyCode.Alpha2)){inventory.UseItem (1);}
		if(Input.GetKeyDown(KeyCode.Alpha3)){inventory.UseItem (2);}
		if(Input.GetKeyDown(KeyCode.Alpha4)){inventory.UseItem (3);}
		if(Input.GetKeyDown(KeyCode.Alpha5)){inventory.UseItem (4);}
		if(Input.GetKeyDown(KeyCode.Alpha6)){inventory.UseItem (5);}
		if(Input.GetKeyDown(KeyCode.Alpha7)){inventory.UseItem (6);}
		if(Input.GetKeyDown(KeyCode.Alpha8)){inventory.UseItem (7);}
		if(Input.GetKeyDown(KeyCode.Alpha9)){inventory.UseItem (8);}
		if(Input.GetKeyDown(KeyCode.Alpha0)){inventory.UseItem (9);}
	}

	void OnTriggerEnter2D(Collider2D item){
		// Se inicializa el objeto actual cuando el player coliciona con el item.
		if (item.gameObject.tag == "Item") {
			//Debug.Log (item.name);
			currentItem = item.gameObject;
			interactionObjectScript	= currentItem.GetComponent<InteractionObject> ();
		}
	}

	void OnTriggerExit2D(Collider2D item){
		// El objeto actual pasa a hacer null cuando el player deja de colicionar con el item.
		if (item.CompareTag ("Item") && currentItem == item.gameObject) {
			currentItem = null;
		}
	}
		
}
