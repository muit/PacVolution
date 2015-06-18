using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAtNight : MonoBehaviour
{
    public TOD_Sky sky;

    public float fadeTime = 1;
    private float lerpTime = 0;

    private ParticleSystem particleComponent;
    private float particleEmission;

    protected void OnEnable()
    {
        if (!sky)
        {
            Debug.LogError("Sky instance reference not set. Disabling script.");
            this.enabled = false;
        }

        particleComponent = this.GetComponent<ParticleSystem>();
        particleEmission  = particleComponent.emissionRate;
    }

    protected void Update()
    {
        int sign = (sky.IsNight) ? +1 : -1;
        lerpTime = Mathf.Clamp01(lerpTime + sign * Time.deltaTime / fadeTime);

        particleComponent.emissionRate = Mathf.Lerp(0, particleEmission, lerpTime);
    }
}
