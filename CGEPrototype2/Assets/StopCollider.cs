using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCollider : MonoBehaviour
{

    public StopWatch stopwatch;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //stopwatch = collision.gameObject.GetComponent<StopWatch>();

        if (stopwatch == null)
        {
            Debug.LogError("stopwatch script not found");
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("test test");
            stopwatch.StopStopwatch();
        }

    }
}
