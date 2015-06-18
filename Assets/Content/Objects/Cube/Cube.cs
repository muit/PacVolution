using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
    [System.NonSerialized]
    public EPlayer player;

    private Renderer renderer;
    void Start(){
        renderer = GetComponent<Renderer>();
    }

    public void Select(EPlayer player, Color color)
    {
        renderer.material.color = color;
        if (player)
        {
            StartCoroutine("SelectDelay");
            player.usedCubes.Add(this);
        }
        else
        {
            StopCoroutine("SelectDelay");
            if (this.player)
            {
                this.player.removableCubes.Remove(this);
                this.player.usedCubes.Remove(this);
            }
        }
        this.player = player;
    }

    IEnumerator SelectDelay() {
        yield return new WaitForSeconds(0.2f);
        player.removableCubes.Add(this);
    }
}
