using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool isPause = false;

    //Menus
    [SerializeField] private GameObject canvasPause = null;
    [SerializeField] private GameObject canvasSettings = null;
    [SerializeField] private GameObject canvasGameOver = null;
    [SerializeField] private GameObject canvasGameUI = null;

    //Checkers
    private bool pause;
    private bool gameOver;

    //past settings variables
    private float timeScale;

    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;

        canvasPause.SetActive(false);
        canvasSettings.SetActive(false);
        canvasGameOver.SetActive(false);
        canvasGameUI.SetActive(true);
    }

    /// <summary>
    /// Pause or unpause the game
    /// </summary>
    public void Pause()
    {
        if (gameOver)
            return;

        //unpause
        if(isPause)
        {
            // if it is in the pause main menu
            if (pause)
            {
                isPause = false;
                Time.timeScale = timeScale;
                canvasPause.SetActive(false);
                canvasSettings.SetActive(false);
                canvasGameUI.SetActive(true);
            }
            // if it is in the settings menu
            else
            {
                MainPause();
            }
        }
        //pause
        else
        {
            pause = true;
            isPause = true;
            Time.timeScale = 0;
            canvasPause.SetActive(true);
            canvasGameUI.SetActive(false);
        }
    }

    /// <summary>
    /// Go to GameOver Screen
    /// </summary>
    public void GameOver()
    {
        gameOver = true;
        canvasGameOver.SetActive(true);
        canvasGameUI.SetActive(false);
    }

    /// <summary>
    /// Go to settings menu
    /// </summary>
    public void Settings()
    {
        pause = false;
        canvasPause.SetActive(false);
        canvasSettings.SetActive(true);
    }

    /// <summary>
    /// Go back to pause main menu
    /// </summary>
    public void MainPause()
    {
        pause = true;
        canvasPause.SetActive(true);
        canvasSettings.SetActive(false);
    }

    /// <summary>
    /// Go back to main menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Reset the game
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
