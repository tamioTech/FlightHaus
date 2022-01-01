using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] ParticleSystem leftPSys;
    [SerializeField] ParticleSystem rightPSys;
    [SerializeField] AudioClip gunnerSound;
    [SerializeField] float gunnerSoundVolume = 75.0f;
    [SerializeField] float delayTime = 0.8f;
    [SerializeField] float modulo = 1.0f;


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
        if (FindObjectOfType<Spitfire_Movement>().isDead ) { return; }

        if(!Input.GetKey("space"))
        {
            leftPSys.Stop();
            rightPSys.Stop();
        }

        if(Input.GetKey("space"))
        {
            print("spacePressed");
            leftPSys.Play();
            rightPSys.Play();
            PlayGunnerSound();

        }
    }

    private void PlayGunnerSound()
    {
            AudioSource.PlayClipAtPoint(gunnerSound, Camera.main.transform.position, gunnerSoundVolume);
    }
}
