using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static int score = 0;

    public Text scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = score.ToString("D4");
    }
}
