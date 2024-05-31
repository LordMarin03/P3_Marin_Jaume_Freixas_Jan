using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByHit : MonoBehaviour
{
    public ParticleSystem destroyParticle;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(destroyParticle.gameObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
