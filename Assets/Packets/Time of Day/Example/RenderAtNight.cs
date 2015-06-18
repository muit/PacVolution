using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RenderAtNight : MonoBehaviour
{
    public TOD_Sky sky;

    private Renderer rendererComponent;

    protected void OnEnable()
    {
        if (!sky)
        {
            Debug.LogError("Sky instance reference not set. Disabling script.");
            this.enabled = false;
        }

        rendererComponent = this.GetComponent<Renderer>();
    }

    protected void Update()
    {
        rendererComponent.enabled = sky.IsNight;
    }
}
