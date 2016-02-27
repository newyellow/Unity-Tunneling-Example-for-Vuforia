using UnityEngine;
using System.Collections;

public class SetProjectorTexture : MonoBehaviour {

	public Camera arCam;
	public Camera bgRenderCam;
	public RenderTexture _renTex;

	Material _targetMat;
	Material _selfMat;

	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds (1.5f);

		// calculate and copy arCam field of view to bgRenderCam
		// not sure why arCam's field of view is actually smaller thans it's value
		Debug.Log( arCam.fieldOfView );
		SetRealFieldOfView ();
		Debug.Log (bgRenderCam.fieldOfView);

		// get render texture
		Rect arCamSize = arCam.pixelRect;
		_renTex = new RenderTexture ( (int)arCamSize.width, (int)arCamSize.height, 24);
		bgRenderCam.targetTexture = _renTex;

		gameObject.GetComponent<Projector> ().aspectRatio = arCamSize.width / arCamSize.height;

		_selfMat = gameObject.GetComponent<Projector> ().material;
		_selfMat.SetTexture ("_ShadowTex", _renTex);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetRealFieldOfView () {

		// get AR CAM's width
		Vector3 arL = arCam.ScreenToWorldPoint (new Vector3 (0.0f, 0.0f, 1000));
		Vector3 arR = arCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0.0f, 1000));
		float arW = arR.x - arL.x;

		// get Render Cam's width
		Vector3 renL = bgRenderCam.ScreenToWorldPoint (new Vector3 (0.0f, 0.0f, 1000));
		Vector3 renR = bgRenderCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0.0f, 1000));
		float renW = renR.x - renL.x;

		float ratio = arW / renW;
		bgRenderCam.fieldOfView = bgRenderCam.fieldOfView * ratio;
		gameObject.GetComponent<Projector> ().fieldOfView = bgRenderCam.fieldOfView;

		Debug.Log ("arL : " + arL);
		Debug.Log ("renL : " + renL);
	}
}
