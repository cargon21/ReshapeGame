using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    InputMaster controls;
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI, LevelStartUI, CheckpointUI;
    public Text TextUI;

    void Awake()
    {
        controls = new InputMaster();
        controls.Player.Pause.performed += ctx => PausePressed();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void PausePressed()
    {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }      
    }

    // For when user wants to go to main menu
    public void MainMenuPressed()
    {
        FindObjectOfType<PlayerMovement>().OnEnable(); // Enable Player Movement
        PauseMenuUI.SetActive(false); // Disable the pause menu
        Time.timeScale = 1f; // Unfreeeze time
        GameIsPaused = false;
        FindObjectOfType<GameManager>().MainMenu();   
    }

    public void Resume()
    {
        FindObjectOfType<PlayerMovement>().OnEnable(); // Enable Player Movement
        PauseMenuUI.SetActive(false); // Disable the pause menu
        TextUI.gameObject.SetActive(true); // Enable the attempts
        Time.timeScale = 1f; // Unfreeeze time
        GameIsPaused = false;
    }

    void Pause()
    {
        FindObjectOfType<PlayerMovement>().OnDisable(); // Disable player movement
        TextUI.gameObject.SetActive(false); // Disable the attempts text
        CheckpointUI.SetActive(false); // For when user pauses right at start of checkpoint
        LevelStartUI.SetActive(false); // For when user pauses right at start
        PauseMenuUI.SetActive(true); // Activate the pause menu
        Time.timeScale = 0f; // Freeze time
        GameIsPaused = true;
    }
}