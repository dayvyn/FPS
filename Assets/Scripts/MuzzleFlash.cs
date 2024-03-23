using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{

    Gun gunScript;
    ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        gunScript = FindObjectOfType<Gun>().GetComponent<Gun>();
        particles = GetComponent<ParticleSystem>();
        gunScript.onShoot += ParticleStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ParticleStart()
    {
        particles.Play();
    }
}
