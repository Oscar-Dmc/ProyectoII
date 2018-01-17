using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class extraPj : MonoBehaviour {
	
	void Update () {
		/* Activamos o desactivamos la luz del personaje, (Solo en PC) */
		if (Input.GetKeyDown (KeyCode.L)) {
			GameObject linterna;
			linterna = GameObject.FindGameObjectWithTag ("Linterna");
			linterna.GetComponent<Light> ().enabled = !linterna.GetComponent<Light> ().enabled;
		}
	}

	public void CaminaCorre(){
		gameObject.GetComponent<FirstPersonController> ().m_IsWalking = !gameObject.GetComponent<FirstPersonController> ().m_IsWalking;

		if (gameObject.GetComponent<FirstPersonController> ().m_IsWalking) {
			GameObject.FindGameObjectWithTag ("TCBoton").GetComponent<Text> ().text = "Correr";
		} else {
			GameObject.FindGameObjectWithTag ("TCBoton").GetComponent<Text> ().text = "Caminar";
		}
	}

}
