using UnityEngine;
using System.Collections;

public class Entity : TNBehaviour {

    public bool isGrounded = true;

    protected Rigidbody2D body2D;

	protected virtual void Start () {
        body2D = GetComponent<Rigidbody2D>();
	}
	
	protected virtual void Update () {
	    
	}

    public virtual bool IsPlayer() { return false; }
}
