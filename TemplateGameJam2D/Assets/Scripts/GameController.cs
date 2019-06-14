using UnityEngine;

public class GameController : MonoBehaviour
{
    private PauseController pause;

    private bool paused = false;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !gameOver)
        {
            paused = !paused;
            pause.Pause();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            gameOver = true;
            pause.GameOver();
        }

        if(!pause && !gameOver)
        {
            // do everythings here
        }
    }
}
