using UnityEngine;
using System.Collections;
using Vuforia;

public class VuforiaFocusMode : MonoBehaviour {

	public CameraDevice.FocusMode focusMode;
	bool focusResult = false;

	// Use this for initialization
	void Start () {
		focusResult = Vuforia.CameraDevice.Instance.SetFocusMode (focusMode);
	}

	void OnGUI () {
	}
}
