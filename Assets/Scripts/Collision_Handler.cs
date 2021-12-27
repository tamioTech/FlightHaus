using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Handler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print($"{this.name} collided with {collision.gameObject.name}");
        FindObjectOfType<BodyExploded>().gameObject.SetActive(false);
        FindObjectOfType<Level_Handler>().ReloadLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"{this.name} triggered an event with {other.gameObject.name}");
    }
}
