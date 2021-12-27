using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void Start()
    {
        print("enemy script started");
    }
    private void OnParticleCollision(GameObject other)
    {
        print("enemy hit!");
    }
}
