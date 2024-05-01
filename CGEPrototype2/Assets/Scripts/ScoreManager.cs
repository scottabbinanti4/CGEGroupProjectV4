using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;

    public StopWatch stopwatch;

    public GameObject startPosition;

    public GameObject player;

    public TMP_Text textbox;
    public PlayerMovement PlayerMovement;
   

    // Start is called before the first frame update
    private void Start()
    {
        gameOver = false;
        won = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You win!\nPress R to Try Again to try for a faster Time!";
            }
            else
            {
                textbox.text = "You Lose!\nPress S to reset";
            }
            if (Input.GetKeyDown(KeyCode.R) && won)
            {
                Reset();
            }
            if (Input.GetKeyDown (KeyCode.S) && !won)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }
    }

    public void Reset()
    {
        //reset the players position
        player.transform.position = startPosition.transform.position;
        gameOver = false;
        textbox.text = "";
        //reset timer
        stopwatch.ResetTime();
        PlayerMovement.UnlockPlayerMovement();
        won = false;
        //reset speed
    }
}