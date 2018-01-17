using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Usaremos este script para controlar la interacción desde el móvil */
public class InteracionCofre : MonoBehaviour {
	private bool cercano = false;

	void OnTriggerStay(Collider pj){
		if (pj.gameObject.tag == "Personaje") {
			cercano = true;
		}
		/* A diferenica de en los otros Trigger, queremos que el usuario interactue con el entorno */ 
		if (cercano && Input.GetKey (KeyCode.F)) {
			GameObject.FindGameObjectWithTag ("TapaCofre").GetComponent<AbrirTapaCofre> ().enabled = true; 
		}
	}

	void OnTriggerExit(Collider pj){
		if (pj.gameObject.tag == "Persona") {
			cercano = false;
		}
	}

	public void ICofre(){
		if (cercano) {
			GameObject.FindGameObjectWithTag ("TapaCofre").GetComponent<AbrirTapaCofre> ().enabled = true; 
		}
	}
}
