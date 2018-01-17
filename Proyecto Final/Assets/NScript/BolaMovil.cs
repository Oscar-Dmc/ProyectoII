using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMovil : MonoBehaviour {
	private Rigidbody rigid;
	public bool isFlat = true;
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fuerza = Input.acceleration * 20;

		if (isFlat) {
			fuerza = Quaternion.Euler (90, 0, 0) * fuerza;
		}

		rigid.AddForce (fuerza);
	}
}
