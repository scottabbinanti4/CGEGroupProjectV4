using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    public GameObject popupUI;
    public StopWatch stopWatch;
    public GameObject player;
    private PlayerMovement playerMovementController;

    private void Start()
    {
        // Deactivate the popup UI initially
        popupUI.SetActive(false);
        playerMovementController = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //Debug.Log("Update method called"); // Debug log to verify if Update method is being called
                                           // Check for escape button input
        if (Input.GetButtonDown("Cancel"))
        {
            //Debug.Log("Escape key pressed"); // Debug log to verify if escape key is pressed
                                             // Activate the popup UI when escape button is pressed
            popupUI.SetActive(true);
            stopWatch.StopStopwatch();
            playerMovementController.LockPlayerMovement();
        }
    }


    // Method called when "Continue" button is clicked
    public void OnContinueButtonClicked()
    {
        // Deactivate the popup UI
        popupUI.SetActive(false);
        if (stopWatch.GetCurrentTime() > 0)
        {
            stopWatch.StartStopwatch();
        }
        playerMovementController.UnlockPlayerMovement();
    }

    // Method called when "Quit" button is clicked
    public void OnQuitButtonClicked()
    {
        playerMovementController.UnlockPlayerMovement();
        // Load the main menu scene
        SceneManager.LoadScene("Menu");

    }
}
