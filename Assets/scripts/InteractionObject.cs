using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

	public bool inventory = true; // Indica si el objeto o item puede ser guardado en el inventario.
	public string itemType;

	void start(){
		
	}
	public void DoInteraction(){
		gameObject.SetActive (false);
	}
}
