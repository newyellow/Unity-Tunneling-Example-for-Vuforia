using UnityEngine;
using System.Collections;

public class ProjectorCopyCameraData : MonoBehaviour {

	public Camera targetCamera;

	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds (2.0f);

		Projector _projector = gameObject.GetComponent<Projector> ();

		_projector.aspectRatio = targetCamera.aspect;
		_projector.fieldOfView = targetCamera.fieldOfView;
	}
}
