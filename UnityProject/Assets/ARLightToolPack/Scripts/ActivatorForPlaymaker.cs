using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorForPlaymaker : MonoBehaviour {

	public void DeactivateObject ( GameObject obj ) {
		obj.SetActive (false);
	}

	public void ActivateObject ( GameObject obj ) {
		obj.SetActive (true);
	}
}
