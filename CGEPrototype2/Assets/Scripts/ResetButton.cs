using UnityEngine;

public class ResetButton : MonoBehaviour
{
    // Reference to the RaceManager script
    public RaceManager raceManager;

    // Method to reset the best time
    public void ResetBestTime()
    {
        raceManager.ResetBestTime();
    }
}
