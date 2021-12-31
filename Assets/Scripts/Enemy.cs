using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int deathStarHealth = 20;
    [SerializeField] int droneHealth = 2;
    [SerializeField] float deathVFXDuration = 1.0f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] AudioClip droneExplosionSound;
    [SerializeField] AudioClip deathStarExplosionSound;
    [SerializeField] AudioClip droneHitSound;
    [SerializeField] AudioClip deathStarHitSound;

    int hitPts = 1;
    int dronePts = 3;
    int deathStarPts = 50;

    Display hud;
    Camera mainCamera;

    private void Start()
    {
       hud = FindObjectOfType<Display>();
       mainCamera = Camera.main;
    }

    private void OnParticleCollision(GameObject other)
    {   
        switch (gameObject.tag)
        {
            case "Drone":
                ProcessDroneHit();
                break;

            case "DeathStar":
                ProcessDeathStarHit();
                break;

            default:
                print("nothing happens");
                break;
        }
    }

    private void ProcessDroneHit()
    {
        droneHealth--;
        hud.AddToScore(hitPts);
        AudioSource.PlayClipAtPoint(droneHitSound, Camera.main.transform.position);
        if (droneHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(droneExplosionSound, Camera.main.transform.position);
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(vfx, deathVFXDuration);
            Destroy(gameObject);
            hud.AddToScore(dronePts);
        }
    }

    private void ProcessDeathStarHit()
    {
        deathStarHealth--;
        hud.AddToScore(hitPts);
        AudioSource.PlayClipAtPoint(deathStarHitSound, Camera.main.transform.position);
        if (deathStarHealth <= 0)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathStarExplosionSound, Camera.main.transform.position);
            Destroy(gameObject);
            hud.AddToScore(deathStarPts);
        }
    }

    
}
