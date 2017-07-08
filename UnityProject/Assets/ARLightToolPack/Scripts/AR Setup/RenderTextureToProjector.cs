using UnityEngine;
using System.Collections;

public class RenderTextureToProjector : MonoBehaviour
{

	public RenderTexture _texture;
	public Projector _projector;

	// Use this for initialization
	void Start ()
	{
		Vector2 textureSize = Vector2.zero;
		float ratio = (float)Screen.height / (float)Screen.width;

		if (Screen.width > 2048) {
			textureSize.x = 2048;
			textureSize.y = 2048 * ratio;
		} else if (Screen.width > 1024) {
			textureSize.x = 1024;
			textureSize.y = 1024 * ratio;
		} else if (Screen.width > 512) {
			textureSize.x = 512;
			textureSize.y = 512 * ratio;
		}
		Debug.Log (textureSize);

		//Debug.Log ("Screen Size: " + Screen.width + "," + Screen.height);

		//_texture = new RenderTexture (Screen.width, Screen.height, 16);
		_texture = new RenderTexture ((int)textureSize.x, (int)textureSize.y, 0);
		_texture.filterMode = FilterMode.Point;

		gameObject.GetComponent<Camera> ().targetTexture = _texture;

		_projector.material.SetTexture ("_ShadowTex", _texture);
	}
}
