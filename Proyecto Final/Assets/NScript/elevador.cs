using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.CodeDom.Compiler;

/* Script para mover el ascensor del final del juego */ 
public class elevador : MonoBehaviour {
	/* Variables que usamos para el movimiento del ascensor */
	private float limInf = 47.508f; /* Límite máximo */
	private float limSup = 101.31f; /* Límite mínimo */ 
	private float dirPlat = -1f; /* Dirección de la plataforma */ 
	private float velPlat = 6.0f; /* Velocidad de la plataforma */
	private Vector3 nextPos; /* Siguiente posición de la plataforma */ 

	void Update () {
		/* Calculamos la posición en a la que tiene que avanzar el elevador */ 
		nextPos = GetComponent<Transform> ().position + Vector3.up * dirPlat * velPlat * Time.deltaTime;
		/* Si la posición supera el umbral máximo, establecemos la posición a ese umbral e invertimos el sentido del elevedaro */ 
		if ((dirPlat > 0) && (nextPos.y > limSup)) {
			nextPos.y = limSup;
			dirPlat *= -1;
		} else if ((dirPlat < 0) && (nextPos.y < limInf)) { /* Igual para el límite inferior */
			nextPos.y = limInf;
			dirPlat *= -1;
		}
		GetComponent<Transform> ().position = nextPos; /* Finalmente movemos el objeto */ 
	}
}
