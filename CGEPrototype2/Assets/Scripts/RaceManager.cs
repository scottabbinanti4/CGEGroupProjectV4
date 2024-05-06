using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public TMP_Text raceTimeText;
    public TMP_Text bestTimeText;
    public TMP_Text[] lastFiveTimesTexts; // UI elements for displaying the last 5 completed times
    public int endRaceTime;

    public StopWatch stopWatch;
    private float bestTime = 100f;
    private float timeOne = 100f;
    private float timeTwo = 100f;
    private float timeThree = 100f;
    private float timeFour = 100f;
    private float timeFive = 100f;
    private List<float> lastFiveTimes = new List<float>();

    private void Start()
    {
        // Load the best time from PlayerPrefs
        bestTime = GetBestTime();
        UpdateBestTimeUI();
        timeOne = GetTime1();
        timeTwo = GetTime2();
        timeThree = GetTime3();
        timeFour = GetTime4();
        timeFive = GetTime5();
        UpdateTimeListUI();

        // Find the StopWatch component in the scene
        stopWatch = FindObjectOfType<StopWatch>();
    }

    /*public void setEndRaceTime()
    {
        endRaceTime = stopwatch.GetCurrentTime();
    }*/

    // Call this method when the player finishes the race
    public void FinishRace()
    {
        // Get the player's race time from the StopWatch
        float raceTime = stopWatch.GetCurrentTime();

        // Update the UI with the player's race time
        raceTimeText.text = "Your Time: " + raceTime.ToString();

        // Check if the player set a new best time
        if (raceTime < bestTime)
        {
            SetBestTime(raceTime);
            UpdateBestTimeUI();
        }

        float temp;

        temp = GetTime4();
        SetTime5(temp);
        temp = GetTime3();
        SetTime4(temp);
        temp = GetTime2();
        SetTime3(temp);
        temp = GetTime1();
        SetTime2(temp);
        SetTime1(raceTime);
        UpdateTimeListUI();
    }

    public void SetBestTime(float time)
    {
        PlayerPrefs.SetFloat("BestTime", time);
    }

    public float GetBestTime()
    {
        return PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
    }

    public void SetTime1(float time)
    {
        PlayerPrefs.SetFloat("Time1", time);
    }

    public float GetTime1()
    {
        return PlayerPrefs.GetFloat("Time1", Mathf.Infinity);
    }

    public void SetTime2(float time)
    {
        PlayerPrefs.SetFloat("Time2", GetTime1());
    }

    public float GetTime2()
    {
        return PlayerPrefs.GetFloat("Time2", Mathf.Infinity);
    }

    public void SetTime3(float time)
    {
        PlayerPrefs.SetFloat("Time3", GetTime2());
    }

    public float GetTime3()
    {
        return PlayerPrefs.GetFloat("Time3", Mathf.Infinity);
    }

    public void SetTime4(float time)
    {
        PlayerPrefs.SetFloat("Time4", GetTime3());
    }

    public float GetTime4()
    {
        return PlayerPrefs.GetFloat("Time4", Mathf.Infinity);
    }

    public void SetTime5(float time)
    {
        PlayerPrefs.SetFloat("Time5", GetTime4());
    }

    public float GetTime5()
    {
        return PlayerPrefs.GetFloat("Time5", Mathf.Infinity);
    }

    private void UpdateTimeListUI()
    {
        float temp = GetTime1();
        lastFiveTimesTexts[0].text = "Time " + (1) + ": " + FormatTime(temp);
        temp = GetTime2();
        lastFiveTimesTexts[1].text = "Time " + (2) + ": " + FormatTime(temp);
        temp = GetTime3();
        lastFiveTimesTexts[2].text = "Time " + (3) + ": " + FormatTime(temp);
        temp = GetTime4();
        lastFiveTimesTexts[3].text = "Time " + (4) + ": " + FormatTime(temp);
        temp = GetTime5();
        lastFiveTimesTexts[4].text = "Time " + (5) + ": " + FormatTime(temp);
    }
    public void UpdateBestTimeUI()
    {
        bestTimeText.text = "Best Time: " + FormatTime(bestTime);
    }

    public void ResetBestTime()
    {
        
        PlayerPrefs.SetFloat("BestTime", Mathf.Infinity);
        bestTimeText.text = "Best Time Reset";

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public string FormatTime(float timeInSeconds, int minutesPrecision = 2, int secondsPrecision = 2, int millisecondsPrecision = 3)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds - Mathf.Floor(timeInSeconds)) * 1000);

        // Format each component with fixed precision
        string formattedMinutes = minutes.ToString("D" + minutesPrecision);
        string formattedSeconds = seconds.ToString("D" + secondsPrecision);
        string formattedMilliseconds = milliseconds.ToString("D" + millisecondsPrecision);

        // Construct the formatted time string
        return string.Format("{0}:{1}:{2}", formattedMinutes, formattedSeconds, formattedMilliseconds);
    }
}