using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pressToContinueText;
    public GameObject[] buttonsToEnable;

    private bool buttonsEnabled = false;

    void Awake()
    {
        // Reset the state when the script is loaded
        ResetState();
    }

    void Update()
    {
        // Check for user input to enable buttons (keyboard key)
        if (Input.GetKeyDown(KeyCode.Space) && !buttonsEnabled)
        {
            EnableButtons();
        }
    }

    void EnableButtons()
    {
        // Enable the buttons
        foreach (var button in buttonsToEnable)
        {
            button.SetActive(true);
        }

        // Disable the "Press anywhere to continue" text
        pressToContinueText.gameObject.SetActive(false);

        // Set the flag indicating that buttons are enabled
        buttonsEnabled = true;

        // Disable this script
        enabled = false;
    }

    public void StartGame()
    {
        // This method can be called by your buttons when clicked
        Debug.Log("Game started!");
    }

    void ResetState()
    {
        // Reset the state of the script
        buttonsEnabled = false;

        // Enable the "Press anywhere to continue" text
        pressToContinueText.gameObject.SetActive(true);

        // Disable the buttons
        foreach (var button in buttonsToEnable)
        {
            button.SetActive(false);
        }
    }
}
