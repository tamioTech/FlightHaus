using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Handler : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject planeBody;

    private void Start()
    {
        explosionFX.SetActive(false);
        planeBody.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print($"{this.name} collided with {collision.gameObject.name}");
        explosionFX.SetActive(true);
        planeBody.SetActive(false); 
        FindObjectOfType<Level_Handler>().ReloadLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"{this.name} triggered an event with {other.gameObject.name}");
    }
}
