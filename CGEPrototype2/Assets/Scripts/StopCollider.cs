using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCollider : MonoBehaviour
{

    public StopWatch stopwatch;
    public RaceManager raceManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stopwatch.StopStopwatch();
            ScoreManager.gameOver = true;
            ScoreManager.won = true;
            raceManager.FinishRace();
        }

    }
}
