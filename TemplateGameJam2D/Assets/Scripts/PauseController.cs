using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool isPause = false;

    //Menus
    [SerializeField] private GameObject canvasPause = null;
    [SerializeField] private GameObject canvasSettings = null;
    [SerializeField] private GameObject canvasGameOver = null;

    //Checkers
    private bool pause;
    private bool settings;
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
    }

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
        }
    }

    public void GameOver()
    {
        gameOver = true;
        canvasGameOver.SetActive(true);
    }

    public void Settings()
    {
        pause = false;
        settings = true;
        canvasPause.SetActive(false);
        canvasSettings.SetActive(true);
    }

    public void MainPause()
    {
        pause = true;
        settings = false;
        canvasPause.SetActive(true);
        canvasSettings.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
