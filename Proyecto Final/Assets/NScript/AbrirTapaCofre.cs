using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirTapaCofre : MonoBehaviour {
	public bool abierto = false; 
	void Update () {
		if (GetComponent<Transform> ().rotation [0] > -0.5f) {
			transform.Rotate (new Vector3 (Time.deltaTime * -10, 0, 0));
			GameObject.FindGameObjectWithTag ("LuzCofre").GetComponent<Light> ().intensity += 0.0095f; 
		} 
		else {
			abierto = true;
		}
	}
}
