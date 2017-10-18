using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public GameObject currentObject	= null;
	public InteractionObject interactionObjectScript = null;
	public Inventory inventory;
	public AudioSource audio;

	void start(){
		this.inventory	= GetComponent<Inventory> ();
		this.interactionObjectScript = currentObject.GetComponent<InteractionObject> ();
		this.audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Interact") && currentObject) { // La tecla X sirve para interactuar.
			// Ver si el item ya esta almacenado.
			if(interactionObjectScript.inventory){
				audio.Play ();
				inventory.AddItem (currentObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D item){
		// Se inicializa el objeto actual cuando el player coliciona con el item.
		if (item.CompareTag ("Item")) {
			//Debug.Log (item.name);
			currentObject = item.gameObject;
			interactionObjectScript	= currentObject.GetComponent<InteractionObject> ();
		}
	}

	void OnTriggerExit2D(Collider2D item){
		// El objeto actual pasa a hacer null cuando el player deja de colicionar con el item.
		if (item.CompareTag ("Item") && currentObject == item.gameObject) {
			currentObject = null;
		}
	}
		
}
