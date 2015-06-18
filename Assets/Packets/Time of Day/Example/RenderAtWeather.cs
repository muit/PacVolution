using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RenderAtWeather : MonoBehaviour
{
    public TOD_Sky sky;
    public TOD_Weather.WeatherType type;

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
        rendererComponent.enabled = sky.Components.Weather.Weather == type;
    }
}
