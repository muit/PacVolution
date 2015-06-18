using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
    public Vector3 fromPosition;
    public Vector3 toPosition;
    [Space(10)]
    public GameObject cubePrefab;

	void Start () {
	    Vector3 position = fromPosition;

        SetupWalls();

        while (position.x < toPosition.x) {
            while (position.y < toPosition.y)
            {
                GameObject cube = GameObject.Instantiate(cubePrefab, position, Quaternion.identity) as GameObject;
                cube.transform.parent = transform;
                position.y++;
            }
            position.y = fromPosition.y;
            position.x++;
        }
	}

    void SetupWalls(){
        BoxCollider2D[] sceneWalls = GetComponents<BoxCollider2D>();
        sceneWalls[0].offset = new Vector2(fromPosition.x - 0.5f + (toPosition.x - fromPosition.x) / 2, fromPosition.y - 1);
        sceneWalls[1].offset = new Vector2(fromPosition.x - 0.5f + (toPosition.x - fromPosition.x) / 2, toPosition.y);
        sceneWalls[2].offset = new Vector2(fromPosition.x - 1, fromPosition.y - 0.5f + (toPosition.y - fromPosition.y) / 2);
        sceneWalls[3].offset = new Vector2(toPosition.x, fromPosition.y - 0.5f + (toPosition.y - fromPosition.y) / 2);

        sceneWalls[0].size = new Vector2(toPosition.x - fromPosition.x, 1);
        sceneWalls[1].size = new Vector2(toPosition.x - fromPosition.x, 1);
        sceneWalls[2].size = new Vector2(1, toPosition.y - fromPosition.y);
        sceneWalls[3].size = new Vector2(1, toPosition.y - fromPosition.y);
    }
	
	void Update () {
	
	}


    public Vector3 GetCenterPoint(){
        return fromPosition + (toPosition - fromPosition)/2;
    }

    public Vector3 GetRandomPoint() {
        return new Vector3(
            Mathf.Floor(Random.Range(fromPosition.x, toPosition.x)), 
            Mathf.Floor(Random.Range(fromPosition.y, toPosition.y)), 
            fromPosition.z);
    }
}
