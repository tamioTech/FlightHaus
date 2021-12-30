using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int deathStarHealth = 20;
    [SerializeField] int droneHealth = 2;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathVFXDuration = 1.0f;
    [SerializeField] Transform parent;
    //[SerializeField] AudioClip droneExplosionSound;
    //[SerializeField] AudioClip deathStarExplosionSound;

    int hitPts = 1;
    int dronePts = 3;
    int deathStarPts = 50;
    Display hud;

    private void Start()
    {
        hud = FindObjectOfType<Display>();
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

    private void ProcessDeathStarHit()
    {
        deathStarHealth--;
        hud.AddToScore(hitPts);
        if (deathStarHealth <= 0)
        {
            //AudioSource.PlayClipAtPoint(deathStarExplosionSound, Camera.main.transform.position);
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            hud.AddToScore(deathStarPts);
        }
    }

    private void ProcessDroneHit()
    {
        droneHealth--;
        //hud.AddToScore(hitPts);
        //FindObjectOfType<Display>().AddToScore(dronePts);
        if (droneHealth <= 0)
        {

            //AudioSource.PlayClipAtPoint(droneExplosionSound, Camera.main.transform.position);
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(vfx, deathVFXDuration);
            Destroy(gameObject);
            hud.AddToScore(dronePts);
        }
    }
}
