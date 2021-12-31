using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Display : MonoBehaviour
{

    Text scoreText;
    [SerializeField] int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateDisplay();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int pts)
    {
        
        score += pts;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        scoreText.text = score.ToString();
    }
}
