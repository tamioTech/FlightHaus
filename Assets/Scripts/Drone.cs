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
        float enemyHealthMax = FindObjectOfType<Enemy1>().GetEnemyHealthMax();
        float enemyHealthCurrent = FindObjectOfType<Enemy1>().GetEnemyHealthCurrent();
        float percentHealth = enemyHealthCurrent / enemyHealthMax;
        GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.green, percentHealth);
    }

}
