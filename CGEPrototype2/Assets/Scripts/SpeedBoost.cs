using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SpeedBoost : MonoBehaviour

{

    public float speedMultiplier = 1.5f;
    public float speedBoostTime = 5f;

    // pick up item 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if (playerMovement == null) 
            {
                Debug.LogError("Playermovement not found on player");
                    return;
            }

            playerMovement.StartSpeedBoost(speedMultiplier, speedBoostTime);
        }

        Destroy(gameObject);
    }

}
