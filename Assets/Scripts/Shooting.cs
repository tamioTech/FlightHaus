using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] ParticleSystem leftPSys;
    [SerializeField] ParticleSystem rightPSys;
    [SerializeField] AudioClip gunnerSound;
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
            leftPSys.Play();
            rightPSys.Play();
            PlayGunnerSound();

        }
    }

    private void PlayGunnerSound()
    {
        float timer = (Time.time % modulo );
        print(timer);
        if (timer > delayTime)
        {
            AudioSource.PlayClipAtPoint(gunnerSound, Camera.main.transform.position, 0.5f);
        }
    }
}
