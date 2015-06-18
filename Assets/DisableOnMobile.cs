using UnityEngine;
using System.Collections;

public class DisableOnMobile : MonoBehaviour {
	void Start () {
        gameObject.SetActive(!Game.IsMobile());
	}
}
