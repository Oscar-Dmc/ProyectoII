using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Clase que usaremos para identificar cuando el personaje pasa por un determinado trigger */
public class Evento : MonoBehaviour {
	public bool evento = false; 

	void OnTriggerEnter(Collider pj){
		if (pj.gameObject.tag == "Personaje") {
			evento = true;
		}
	}
}

