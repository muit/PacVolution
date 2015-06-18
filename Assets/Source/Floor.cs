using UnityEngine;
using System.Collections.Generic;

public class Floor : MonoBehaviour {
    List<Collider2D> colliders = new List<Collider2D>();


    void OnTriggerEnter2D(Collider2D coll)
    {
        transform.parent.GetComponent<Entity>().isGrounded = true;
        colliders.Add(coll);
    }

    void OnTriggerExit2D(Collider2D coll) {
        colliders.Remove(coll);

        if (colliders.Count <= 0)
            transform.parent.GetComponent<Entity>().isGrounded = false;
    }
}
