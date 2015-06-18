//----------------------------------------
//            PacVolution
// Copyright © 2015-2016 Miguel Fernandez
//----------------------------------------

using UnityEngine;
using TNet;
using System.Collections;

/// <summary>
/// Instantiate the specified prefab at the game object's position.
/// </summary>

public class Spawner : MonoBehaviour
{
	/// <summary>
	/// Prefab to instantiate.
	/// </summary>

	public GameObject prefab;

	/// <summary>
	/// Whether the instantiated object will remain in the game when the player that created it leaves.
	/// Set this to 'false' for the player's avatar.
	/// </summary>

	public bool persistent = false;

    public bool destroyOnCreated = false;

	IEnumerator Start ()
	{
		while (TNManager.isJoiningChannel) yield return null;
        SpawnPlayer(Game.Get().scene.GetRandomPoint());
	}

    public void SpawnPlayer(Vector3 position){
        TNManager.Create(prefab, position, Quaternion.identity, persistent);
        if(destroyOnCreated)
            Destroy(gameObject);
    }
}