using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/* Objetivo del scrip es unificar los eventos que suceden en la planta 0 y derivan de la sala lateral de la mismsa para que las llamadas
 * en el controlador de escena sea más fácil. */
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;


 
public class ControlSalaLat : MonoBehaviour {
	void Start () {
		Controlador.contEscena.fuego_hoguera += IntOcultas; /* Activamos las salas ocultas */
		Controlador.contEscena.mostrar_pasillosP1 += Pasillos; /* Activamos el pasillo a la planta 1 */ 
		Controlador.contEscena.interfaz += MejorarInterfaz;
	}

	void IntOcultas () {
		/* Se activan las luces y filtros de partículas asociadas a las antorchas,  velas y fuegos */ 
		foreach (GameObject fuego in GameObject.FindGameObjectsWithTag("Fire")) {
			fuego.GetComponent<ParticleSystem> ().Play ();
		}

		foreach (GameObject luz in GameObject.FindGameObjectsWithTag ("LuzFuego")) {
			luz.GetComponent<Light>().enabled = true;
		}
			
		foreach (GameObject poc in GameObject.FindGameObjectsWithTag ("DobleOculta")) {
			poc.SetActive (false); 
		}

		foreach (GameObject loz in GameObject.FindGameObjectsWithTag ("LuzPOculta")) {
			loz.GetComponent<Light> ().enabled = true;
		}

	}

	void Pasillos(){
		foreach (GameObject pasillo in GameObject.FindGameObjectsWithTag ("PasOcu")) {
			pasillo.SetActive (false); 
		}
	}

	void MejorarInterfaz(){
		GameObject.FindGameObjectWithTag ("MoverUI").GetComponentInChildren<Text> ().enabled = false;
		GameObject.FindGameObjectWithTag ("CamaraUI").GetComponentInChildren<Text> ().enabled = false;
	}
}
