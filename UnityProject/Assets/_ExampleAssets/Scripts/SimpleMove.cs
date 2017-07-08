using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
	
	public Vector2 positionFromTo = new Vector2( 0.0f, -10.0f );
	public float moveSpeed = -1.0f;

	// use for check AR scan
	bool status = false;
	bool lastStatus = false;

	
	// Update is called once per frame
	void Update () {
	
		status = gameObject.GetComponent<MeshRenderer> ().enabled;

		if (lastStatus != status) {
			lastStatus = status;

			// if track found, reset it
			if (status) {
				Vector3 pos = transform.position;
				pos.y = 0.0f;
				transform.position = pos;
			}
		}

		if (status) {
			if (transform.position.y > positionFromTo.y)
				transform.position += new Vector3 (0.0f, 1.0f, 0.0f) * moveSpeed * Time.deltaTime;
		}
	}

}
