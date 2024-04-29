using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{

    public StopWatch stopwatch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("test test");
            stopwatch.StartStopwatch();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            
        }

    }
}
