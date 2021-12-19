using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] ParticleSystem leftPSys;
    [SerializeField] ParticleSystem rightPSys;

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
        print("space bar pressed");
        if(!Input.GetKey("space"))
        {
            print("space not pressed");
            leftPSys.Stop();
            rightPSys.Stop();
        }

        if(Input.GetKey("space"))
        {
            print("start particles");
            leftPSys.Play();
            rightPSys.Play();
        }
    }
}
