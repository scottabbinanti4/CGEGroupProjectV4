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

    public GameObject startPosition;

    public GameObject player;

    public TMP_Text textbox;

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
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reset();
            }
            if (Input.GetKeyDown (KeyCode.S))
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
        //reset speed
    }
}