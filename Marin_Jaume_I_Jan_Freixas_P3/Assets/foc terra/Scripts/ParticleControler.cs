using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ParticleControler : MonoBehaviour
{
    ParticleSystem _particleSystem;
    
    private bool _tooglePlay;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldChangePlay())
        {
            ChangePlay();
            ChangeAngle();

        }
        ChangeStrength();

    }

    private void ChangeAngle()
    {
        var shapeModule = _particleSystem.shape;
        shapeModule.angle = Random.Range(0, 90);
    }

    private void ChangePlay()
    {
        _tooglePlay = !_tooglePlay;

        if (_tooglePlay)
            Play();
        else
        {
            Stop();
        }
    }

    private bool ShouldChangePlay()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private void Stop()
    {
        _particleSystem.Stop();
    }

    private void ChangeStrength()
    {
        var emission = _particleSystem.emission;
        emission.rateOverTime = (Mathf.Sin(Time.time)*0.5f+0.5f)*100;
        var burst = emission.GetBurst(0);
        burst.count = 99;
        emission.SetBurst(0, burst);
    }

    private void Play()
    {
        _particleSystem.Play();
    }
}
