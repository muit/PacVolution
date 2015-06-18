using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {
    private EPlayer player;
	void Start () {
        player = GetComponentInParent<EPlayer>();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        player.OnTriggerEnter2D(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.OnTriggerExit2D(col);
    }
}
