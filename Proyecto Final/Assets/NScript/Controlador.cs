using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.UI;

public delegate void metodoD();

public class Controlador : MonoBehaviour {
	public static Controlador contEscena;
	/* Eventos que esperamos recoger durante la escena, cada uno de ellos está explicado en su respectivo script */ 
	public event metodoD mostrar_pasillosP1;
	public event metodoD fuego_hoguera;
	public event metodoD abrir_pSaltos;
	public event metodoD activar_elevador;
	public event metodoD salir_trampa;
	public event metodoD sal_cofre;
	public event metodoD interfaz;

	/* Usaremos un Array de booleanos para evitar que se comprueven 2 veces eventos en los que previamente hemos eliminado un objeto y por lo tanto den errores */ 
	private bool[] activables = { true, true, true, true, true, true, true, true};
	/* Indica el punto del diálogo del personaje en el que estamos */
	private int dialogo = 0; 


	/* Despertamos al controlador en caso de que aun no lo este */
	void Awake(){
		if (contEscena == null) {
			contEscena = this;
			DontDestroyOnLoad (this);
		}
	
	}
		
	void Update () {
		/* Capturamos los objetos que lanzan eventos para comprobar en cual han sido activados */ 
		GameObject combustible = GameObject.FindGameObjectWithTag ("BSalaLat");
		GameObject activador_pasillos = GameObject.FindGameObjectWithTag ("actpasillos");
		GameObject cofre = GameObject.FindGameObjectWithTag ("TapaCofre");
		GameObject s_cofre = GameObject.FindGameObjectWithTag ("salaCofre");
		GameObject p_elevador = GameObject.FindGameObjectWithTag ("ActElevador");
		GameObject a_trampa = GameObject.FindGameObjectWithTag ("SueloTrampa");
		GameObject cerrar_ui = GameObject.FindGameObjectWithTag ("CerrarUI");


		/* La primera condición es para evitar que se llame en cada iteración a la misma función que ya se uso */
		/* Comprobaciones si el evento ha ocurrido o no, y reproducimos los sonidos ambientales */ 

		if (activables[0] && activador_pasillos.GetComponent<Evento> ().evento) {
			mostrar_pasillosP1 ();
			gameObject.GetComponent<AudioSource> ().Play ();
			activables [0] = false;
			dialogo = 3;
		}

		if (activables[1] && cofre.GetComponent<AbrirTapaCofre> ().abierto) {
			abrir_pSaltos ();
			gameObject.GetComponent<AudioSource> ().Play ();
			activables [1] = false;
			dialogo = 5;
		}
		if (activables[2] && p_elevador.GetComponent<Evento> ().evento) {
			activar_elevador ();
			gameObject.GetComponent<AudioSource> ().Play ();
			activables [2] = false;
			dialogo = 6;
		}
		if (activables[3] && s_cofre.GetComponent<Evento> ().evento) {
			sal_cofre ();
			gameObject.GetComponent<AudioSource> ().Play ();
			activables [3] = false;
			dialogo = 4;

		}
		if (activables[4] && a_trampa.GetComponent<Evento> ().evento) {
			salir_trampa ();
			gameObject.GetComponent<AudioSource> ().Play ();
			activables [4] = false; 
			dialogo = 7;
		}
		if (activables [5] && GameObject.FindGameObjectWithTag ("Pista1").GetComponent<Evento> ().evento) {
			dialogo = 1; 
			activables [5] = false;
		}

		if (activables[6] && combustible.GetComponent<BotonSalaLat> ().activo) {
			fuego_hoguera ();
			gameObject.GetComponent<AudioSource> ().Play ();
			activables [6] = false;
			dialogo = 2;
		}
		if (activables [7] && cerrar_ui.GetComponent<Evento> ().evento) {
			interfaz ();
			activables [7] = false;
		}

		Dialogos ();
	}

	/* Diálogos del personaje */ 
	void Dialogos(){
		string cadena; 
		if (GameObject.FindGameObjectWithTag ("Texto") != null) {
			switch (dialogo) {
			case 1:
				cadena = "Parece que hay que llenar el hueco con algo.";
				GameObject.FindGameObjectWithTag ("Texto").GetComponent<Text> ().text = cadena;
				break;
			case 2:
				cadena = "¿Qué ha sido ese ruido?";
				GameObject.FindGameObjectWithTag ("Texto").GetComponent<Text> ().text = cadena;
				break;
			case 3:
				cadena = "¿De nuevo ese ruido? Suena como si algo se moviera...";
				GameObject.FindGameObjectWithTag ("Texto").GetComponent<Text> ().text = cadena;
				break;
			case 4:
				cadena = "¡Algo se ha vuelto mover! Quizás deba investigar algo más y ver si logro salir de este sitio.";
				GameObject.FindGameObjectWithTag ("Texto").GetComponent<Text> ().text = cadena;
				break;
			case 5:
				cadena = "Se ha activado algo de nuevo... Este dichoso castillo esta lleno de pasadizos secretos. ";
				GameObject.FindGameObjectWithTag ("Texto").GetComponent<Text> ().text = cadena;
				break;
			case 6:
				cadena = "Es que este maldito sitio no va a parar de cambiar... Probaré por el otro pasillo, quizás tenga mejor suerte";
				GameObject.FindGameObjectWithTag ("Texto").GetComponent<Text> ().text = cadena;
				break;
			case 7:
				cadena = "¡¿PERO QUE DEMONIOOOOOOOOOOOOOOS?!.......... Será mejor que me de prisa.";
				GameObject.FindGameObjectWithTag ("Texto").GetComponent<Text> ().text = cadena;
				break;
			default:
				break;
			}
		}
	}
}
