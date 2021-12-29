using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] ParticleSystem leftPSys;
    [SerializeField] ParticleSystem rightPSys;
    [SerializeField] AudioClip gunnerSound;

    private void Start()
    {
        leftPSys.Stop();
        rightPSys.Stop();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(!Input.GetKey("space"))
        {
            leftPSys.Stop();
            rightPSys.Stop();
        }

        if(Input.GetKey("space"))
        {
            leftPSys.Play();
            rightPSys.Play();
            AudioSource.PlayClipAtPoint(gunnerSound, transform.position);
            
        }
    }
}
