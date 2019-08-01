using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Fade Properties")]
    [SerializeField] private Image fadeInOut = null;
    [SerializeField] private Animator fadeAnim = null;

    [Header("Menu Properties")]
    [SerializeField] private GameObject canvasMainMenu = null;
    [SerializeField] private GameObject canvasSettings = null;
    [SerializeField] private GameObject canvasCredits = null;


    //Checkers
    private bool mainMenu;

    void Start()
    {
        fadeInOut.gameObject.SetActive(true); //used to clean the screen in the editor
        fadeAnim.SetTrigger("FadeIn");
        MainMenu();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (mainMenu)
                CloseGame();
            else
                MainMenu();
        }
    }

    /// <summary>
    /// Function that starts the game
    /// Used by the Start button
    /// </summary>
    public void StartGame()
    {
        StartCoroutine(Fading()); //Start the fade out before change sceane
    }

    /// <summary>
    /// Fuction that close the game
    /// Go to desktop
    /// Used by the Exit Button
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }

    /// <summary>
    ///function thats set the canvas of the Settings the visible canvas 
    /// </summary>
    public void Settings()
    {
        mainMenu = false;

        canvasMainMenu.SetActive(false);
        canvasCredits.SetActive(false);
        canvasSettings.SetActive(true);
    }

    /// <summary>
    ///function thats set the canvas of the Credits the visible canvas 
    /// </summary>
    public void Credits()
    {
        mainMenu = false;

        canvasMainMenu.SetActive(false);
        canvasCredits.SetActive(true);
        canvasSettings.SetActive(false);
    }

    /// <summary>
    ///function thats set the canvas of the Main Menu the visible canvas 
    /// </summary>
    public void MainMenu()
    {
        mainMenu = true;

        canvasMainMenu.SetActive(true);
        canvasCredits.SetActive(false);
        canvasSettings.SetActive(false);
    }

    //Function that playes the fade out in paralel
    //The Animation needs to be in the update mode = Unscale time
    private IEnumerator Fading()
    {
        fadeAnim.SetTrigger("FadeOut");

        yield return new WaitUntil(() => fadeInOut.color.a == 1);
        SceneManager.LoadScene(1);
    }
}
