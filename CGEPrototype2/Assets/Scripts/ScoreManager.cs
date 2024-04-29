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
                textbox.text = "You Lose!\nPress R to Try Again";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

}