using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticleSystem; // Referencia al sistema de partículas de lluvia
    public float rateChangeAmount = 10f; // Cantidad por la cual cambiar el Rate over Time
    public float sizeChangeAmount = 0.1f; // Cantidad por la cual cambiar el tamaño de las partículas
    public float noiseStrengthChangeAmount = 0.1f; // Cantidad por la cual cambiar la fuerza del ruido
    public float noiseFrequencyChangeAmount = 0.1f; // Cantidad por la cual cambiar la frecuencia del ruido

    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.NoiseModule noiseModule;

    void Start()
    {
        if (rainParticleSystem == null)
        {
            Debug.LogError("Particle system not assigned.");
            return;
        }

        mainModule = rainParticleSystem.main;
        noiseModule = rainParticleSystem.noise;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeRateOverTime(rateChangeAmount);
            ChangeSize(sizeChangeAmount);
            ChangeNoiseStrength(noiseStrengthChangeAmount);
            ChangeNoiseFrequency(noiseFrequencyChangeAmount);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeRateOverTime(-rateChangeAmount);
            ChangeSize(-sizeChangeAmount);
            ChangeNoiseStrength(-noiseStrengthChangeAmount);
            ChangeNoiseFrequency(-noiseFrequencyChangeAmount);
        }
    }

    void ChangeRateOverTime(float changeAmount)
    {
        var emissionModule = rainParticleSystem.emission;
        var emissionRate = emissionModule.rateOverTime.constant;
        emissionRate += changeAmount;
        emissionRate = Mathf.Max(0, emissionRate); // Asegurarse de que el rate no sea negativo
        emissionModule.rateOverTime = emissionRate;
    }

    void ChangeSize(float changeAmount)
    {
        var size = mainModule.startSize.constant;
        size += changeAmount;
        size = Mathf.Max(0, size); // Asegurarse de que el tamaño no sea negativo
        mainModule.startSize = size;
    }

    void ChangeNoiseStrength(float changeAmount)
    {
        var noiseStrength = noiseModule.strength.constant;
        noiseStrength += changeAmount;
        noiseStrength = Mathf.Max(0, noiseStrength); // Asegurarse de que la fuerza del ruido no sea negativa
        noiseModule.strength = noiseStrength;
    }

    void ChangeNoiseFrequency(float changeAmount)
    {
        var noiseFrequency = noiseModule.frequency;
        noiseFrequency += changeAmount;
        noiseFrequency = Mathf.Max(0, noiseFrequency); // Asegurarse de que la frecuencia del ruido no sea negativa
        noiseModule.frequency = noiseFrequency;
    }
}
