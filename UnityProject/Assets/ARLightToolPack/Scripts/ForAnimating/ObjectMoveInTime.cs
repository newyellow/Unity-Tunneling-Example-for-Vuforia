using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveInTime : MonoBehaviour {

	public MoveSet[] moveData;

	IEnumerator DoMove ( int dataIndex ) {
		MoveSet data = moveData [dataIndex];

		int frames = (int)(data.transitionTime / Time.smoothDeltaTime);
		float step = 1.0f / (float)frames;
		float t = -1 * step;

		for (int i = 0; i <= frames; i++) {
			t += step;

			transform.position = Vector3.Lerp (data.fromPos, data.toPos, data.transitionCurve.Evaluate (t));
			yield return new WaitForEndOfFrame ();
		}
	}
}

[System.Serializable]
public class MoveSet {
	public Vector3 fromPos;
	public Vector3 toPos;
	public float transitionTime;
	public AnimationCurve transitionCurve;
}