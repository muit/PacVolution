using UnityEngine;
using System.Collections;

public class Follow2D : MonoBehaviour {
    public float dampMove = 5;
    public Transform target;

    private Vector3 targetPos; 

	void Start () {
	
	}
	
	void Update () {
        if (!Game.Get().controlledPlayer)
            targetPos = Game.Get().scene.GetCenterPoint();
        else {
            if(Game.Get().controlledPlayer && target != Game.Get().controlledPlayer)
                target = Game.Get().controlledPlayer.transform;
            targetPos = target.position;
        }
        
        targetPos.z = -20;
        transform.position = Vector3.Lerp(transform.position, targetPos, dampMove * Time.deltaTime);
	}
}
