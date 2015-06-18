using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAtWeather : MonoBehaviour
{
    public TOD_Sky sky;
    public TOD_Weather.WeatherType type;

    public  float fadeTime = 1;
    private float lerpTime = 0;

    private AudioSource audioComponent;
    private float audioVolume;

    protected void OnEnable()
    {
        if (!sky)
        {
            Debug.LogError("Sky instance reference not set. Disabling script.");
            this.enabled = false;
        }

        audioComponent = this.GetComponent<AudioSource>();
        audioVolume    = audioComponent.volume;
    }

    protected void Update()
    {
        int sign = (sky.Components.Weather.Weather == type) ? +1 : -1;
        lerpTime = Mathf.Clamp01(lerpTime + sign * Time.deltaTime / fadeTime);

        audioComponent.volume = Mathf.Lerp(0, audioVolume, lerpTime);
    }
}
