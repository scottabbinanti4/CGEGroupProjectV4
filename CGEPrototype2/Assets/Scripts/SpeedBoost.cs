using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SpeedBoost : MonoBehaviour

{
    public static event Action<float> OnSpeedCollected;
    public float speedMultiplier = 1.5f;

    // pick up item 
    public void Collect()
    {
        OnSpeedCollected.Invoke(speedMultiplier);
        Destroy(gameObject);
    }
}
