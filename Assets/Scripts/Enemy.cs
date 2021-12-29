using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int deathStarHealth = 100;
    [SerializeField] int droneHealth = 2;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathVFXDuration = 1.0f;
    [SerializeField] Transform parent;


    private void Start()
    {
    }

    private void OnParticleCollision(GameObject other)
    {

        switch (gameObject.tag)
        {
            case "Drone":
                print("hit drone");
                droneHealth--;
                if (droneHealth <= 0)
                {
                    GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
                    vfx.transform.parent = parent;
                    //deathVFX.SetActive(true);
                    Destroy(vfx, deathVFXDuration);
                    Destroy(gameObject);
                }
                break;

            case "DeathStar":
                print("hit deathStar");
                deathStarHealth--;
                if (deathStarHealth <= 0)
                {
                    Instantiate(deathVFX, transform.position, Quaternion.identity);
                    Destroy(gameObject); }
                break;

            default:
                print("nothing");
                break;
        }

    }
}
