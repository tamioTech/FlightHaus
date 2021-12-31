using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeColor()
    {
        float droneHealth = FindObjectOfType<Enemy>().droneMaxHealth;
        float healthLeft = FindObjectOfType<Enemy>().droneHealth;
        float percentHealth =   healthLeft / droneHealth;
        print($"{droneHealth} {healthLeft} {percentHealth}");
        GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.green, percentHealth);
    }

}
