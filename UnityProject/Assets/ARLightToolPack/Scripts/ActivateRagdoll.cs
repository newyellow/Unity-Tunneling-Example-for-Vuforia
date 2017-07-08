using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour {

	public bool deactivateRagdollOnStart = true;

	Rigidbody[] rigidbodies;

	// Use this for initialization
	void Start () {

		rigidbodies = gameObject.GetComponentsInChildren<Rigidbody> ();

		if (deactivateRagdollOnStart) {
			for (int i = 0; i < rigidbodies.Length; i++) {
				rigidbodies [i].isKinematic = true;
				rigidbodies [i].useGravity = false;
			}
		}
		
	}

	void ActivateDoll () {

		gameObject.GetComponent<Animator> ().enabled = false;

		for (int i = 0; i < rigidbodies.Length; i++) {
			rigidbodies [i].velocity = Vector3.zero;
			rigidbodies [i].isKinematic = false;
			rigidbodies [i].useGravity = true;
		}
	}
}
