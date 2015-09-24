using UnityEngine;
using System.Collections;

using DG.Tweening;
public class spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DORotate(new Vector3(0, 0, 361), 10, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1);
	}
	
}
