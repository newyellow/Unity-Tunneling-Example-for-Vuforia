using UnityEngine;
using System.Collections;

public class CopyCameraData : MonoBehaviour {

	public Camera targetCamera;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (2.0f);

		Camera _cam = gameObject.GetComponent<Camera> ();

		_cam.aspect = targetCamera.aspect;
		_cam.fieldOfView = targetCamera.fieldOfView;
	}
}
