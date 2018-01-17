using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* El objetivo de este script es unificar,  en la medida de lo posible, las funciones que manejan eventos en la plata 1 
 * para que la llamada desde el controlador general de la escena sea más intuitivo */ 
public class ControlPlata1 : MonoBehaviour {

	void Start () {
		/* Añadimos las funciones asociadas a los eventos en la planta 1 */ 
		Controlador.contEscena.sal_cofre += PCofre; /* Activamos el muro del cofre */
		Controlador.contEscena.abrir_pSaltos += Des_saltos; /* Desbloqueamos la pared de saltos */
		Controlador.contEscena.activar_elevador += ActElevador; /* Activamos el elevador para finalizar el juego */
		Controlador.contEscena.salir_trampa += IntTrampa; /* Abrimos la salida de la trampa */ 

	}

	/* Desactivamos la pared del cofre en el caso de que no lo este */ 
	void PCofre () {
		if (GameObject.FindGameObjectWithTag ("pcofre") != null) {
			GameObject.FindGameObjectWithTag ("pcofre").SetActive (false);
		}
	}

	void Des_saltos(){
		/* Encendemos la luces de la sala previa al puzle de salto */
		foreach (GameObject luz in GameObject.FindGameObjectsWithTag ("LuzFuegoP1")) {
			luz.GetComponent<Light>().enabled = true;
		}

		foreach (GameObject luzp in GameObject.FindGameObjectsWithTag ("LuzPelota")) {
			luzp.GetComponent<Light>().enabled = true;
		}

		/* También los filtros de partículas para darle más realismo */
		foreach (GameObject fuego in GameObject.FindGameObjectsWithTag ("FuegoP1")) {
			fuego.GetComponent<ParticleSystem> ().Play ();
		}

		/* Finalmente desbloqueamos la pared del puzle de saltos */
		if (GameObject.FindGameObjectWithTag ("POcultSaltos") != null) {
			GameObject.FindGameObjectWithTag ("POcultSaltos").SetActive (false);
		}
	}

	void ActElevador () {
		/* Reducimos la intesidad de la luz en la estatua del angel */
		GameObject.FindGameObjectWithTag ("LuzAngel").GetComponent<Light> ().intensity = 1; 

		if (GameObject.FindGameObjectWithTag ("POcultEleva") != null) {
			GameObject.FindGameObjectWithTag ("POcultEleva").SetActive (false);
		}
	}

	void IntTrampa () {
		/* Reproducimos el audio asociado al objeto cuando se activa la trampa */ 
		gameObject.GetComponent<AudioSource> ().Play ();
		if (GameObject.FindGameObjectWithTag ("POcultTramp") != null) {
			GameObject.FindGameObjectWithTag ("POcultTramp").SetActive (false);
			GameObject.FindGameObjectWithTag ("SueloTrampa").SetActive (false);
		}
	}

}
