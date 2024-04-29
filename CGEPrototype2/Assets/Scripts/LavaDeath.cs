using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LavaDeath : MonoBehaviour
{
    public TMP_Text output;
    public string textToDisplay;
    public StopWatch stopwatch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stopwatch.StopStopwatch();
            output.text = textToDisplay;
            ScoreManager.gameOver = true;
            collision.gameObject.SetActive(false);
            
        }
    }
}
