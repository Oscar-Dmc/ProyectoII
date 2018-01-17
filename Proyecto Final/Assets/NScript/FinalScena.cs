using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScena : MonoBehaviour {
	/*Trigger para activar los créditos del juego. */
	void OnTriggerEnter(Collider pj){
		if (pj.gameObject.tag == "Personaje") {
			SceneManager.LoadScene ("creditos"); /* Función con la que cambiaremos de escena */
		}
	}
}
