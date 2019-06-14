using UnityEngine;

public class GameController : MonoBehaviour
{
    private PauseController pause;
    private Score score;

    private bool paused = false;
    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseController>();
        score = GetComponent<Score>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !gameOver)
        {
            paused = !paused;
            pause.Pause();
        }

        if(Input.GetKeyDown(KeyCode.Q) && !gameOver)
        {
            GameOver();
        }

        if (!paused && !gameOver)
        {
            // do everythings here
            if (Input.GetKeyDown(KeyCode.E))
            {
                score.AddScore(0);
            }
        }
    }

    private void GameOver()
    {
        gameOver = true;
        score.SaveHighScore();
        pause.GameOver();
    }
}
