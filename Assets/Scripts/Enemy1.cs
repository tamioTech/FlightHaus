using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float enemyHealthMax = 10.0f;
    [SerializeField] private float enemyHealthCurrent;
    [SerializeField] private float deathVFXDuration = 1.0f;

    [SerializeField] public float deathVolume = 0.75f;

    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform parent;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;

    int ptsHit = 1;
    int ptsKill = 10;

    Vector3 mainCameraPos;
    Display display;
    Drone drone;

    
    void Start()
    {
        enemyHealthCurrent = enemyHealthMax;
        mainCameraPos = Camera.main.transform.position;
        display = FindObjectOfType<Display>();
        drone = FindObjectOfType<Drone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        enemyHealthCurrent--;
        drone.ChangeColor();
        display.AddToScore(ptsHit);

        if(enemyHealthCurrent <= 0)
        {
            display.AddToScore(ptsKill);
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathSound, mainCameraPos, deathVolume);
            Destroy(deathVFX, deathVFXDuration);
            Destroy(gameObject);
        }
    }

    public float GetEnemyHealthMax()
    {
        return enemyHealthMax;
    }

    public float GetEnemyHealthCurrent()
    {
        return enemyHealthCurrent;
    }
}
