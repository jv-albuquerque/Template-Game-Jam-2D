using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    [Header("Player Experience")]
    [SerializeField] private bool useDelay = true;
    [SerializeField] private float delayToLoad = 2f;

    [Header("Load Bar Properties")]
    [SerializeField] private GameObject sliderObj;
    [SerializeField] private Slider slider;

    private ImportantDatas datas = null;

    private bool alreadyCalledLoadingScreen = false;

    private Cooldown delayCD;

    AsyncOperation async;

    private void Awake()
    {
        Time.timeScale = 1f;

        delayCD = new Cooldown(Random.Range(0.1f , delayToLoad));
        delayCD.Start();

        datas = GameObject.FindGameObjectWithTag("Datas").GetComponent<ImportantDatas>();

        if(!useDelay)
            StartCoroutine(LoadingScreen());
    }

    private void Update()
    {
        if(useDelay)
            if(!delayCD.IsFinished)
            {
                slider.value = delayCD.Percent/200;
            }
            else if(!alreadyCalledLoadingScreen)
            {
                alreadyCalledLoadingScreen = true;
                StartCoroutine(LoadingScreen());
            }
    }

    IEnumerator LoadingScreen()
    {
        sliderObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(datas.NextScene);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            if (!useDelay)
                slider.value = async.progress;
            else
                slider.value = async.progress/2 + 0.5f;

            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
