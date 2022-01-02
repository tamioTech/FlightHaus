 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private int ptsHit = 1;
    [SerializeField] private int ptsKill = 10;

    [SerializeField] private float enemyHealthMax = 10.0f;
    [SerializeField] private float enemyHealthCurrent;
    [SerializeField] private float deathVFXDuration = 1.0f;
    [SerializeField] private float hitVolume = 1.0f;
    [SerializeField] private float deathVolume = 0.75f;

    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform parent;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;


    Vector3 mainCameraPos;
    Display display;
    Drone drone;
    GameObject parentGameobject;

    
    void Start()
    {
        enemyHealthCurrent = enemyHealthMax;                            //health
        mainCameraPos = Camera.main.transform.position;                 //main camera position
        display = FindObjectOfType<Display>();                          //score display
        parentGameobject = GameObject.FindWithTag("SpawnAtRuntime");    //parent gameobject
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();            //rigid body
        rb.useGravity = false;                                          //rigid body no gravity
        GetComponent<MeshRenderer>().material.color = Color.cyan;       //change color
        
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
