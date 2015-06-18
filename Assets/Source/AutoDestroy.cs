using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
    public float destroyDelay = 2.0f; 

	void Start () {
        Destroy(gameObject, destroyDelay);
	}
}
