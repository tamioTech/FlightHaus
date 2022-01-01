 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float enemyHealthMax = 10.0f;
    [SerializeField] private float enemyHealthCurrent;
    [SerializeField] private float deathVFXDuration = 1.0f;

    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform parent;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private float hitVolume = 1.0f;
    [SerializeField] private float deathVolume = 0.75f;

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
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        GetComponent<MeshRenderer>().material.color = Color.cyan;
        
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
        EnemyHit();

        if (enemyHealthCurrent <= 0)
        {
            EnemyDead();
        }
    }

    private void EnemyHit()
    {
        enemyHealthCurrent--;
        ChangeColor();
        display.AddToScore(ptsHit);
        AudioSource.PlayClipAtPoint(hitSound, mainCameraPos, hitVolume);
    }

    private void EnemyDead()
    {
        AudioSource.PlayClipAtPoint(deathSound, mainCameraPos, deathVolume);
        display.AddToScore(ptsKill);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(vfx, deathVFXDuration);
        Destroy(gameObject);
    }

    public float GetEnemyHealthMax()
    {
        return enemyHealthMax;
    }

    public float GetEnemyHealthCurrent()
    {
        return enemyHealthCurrent;
    }

    public void ChangeColor()
    {
        float percentHealth = enemyHealthCurrent / enemyHealthMax;
        GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.magenta, Color.cyan, percentHealth);
    }
}
