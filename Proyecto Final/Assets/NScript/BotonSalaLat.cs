using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSalaLat : MonoBehaviour {

	private Vector3 pos; 
	public float HovForce = 12f;
	public bool activo = false;


	void OnTriggerStay(Collider otro){
		if (otro.gameObject.tag == "SalaLatActivador") {
			activo = true; 
			otro.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * HovForce, ForceMode.Acceleration);
		} 
	}
	void OnTriggerExit(Collider otro){
		if (otro.gameObject.tag == "SalaLatActivador") {
			/* La | En las constrains funcionan como y | */
			otro.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		}
	}
}
