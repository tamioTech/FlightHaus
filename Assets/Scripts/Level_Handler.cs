using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Handler : MonoBehaviour
{
    public int waitTime = 2;

    public void ReloadLevel()
    {
        StartCoroutine(Crashed());
    }

    IEnumerator Crashed()
    {
        FindObjectOfType<Spitfire_Movement>().isDead = true;
        yield return new WaitForSeconds(waitTime);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
