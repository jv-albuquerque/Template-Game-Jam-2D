using UnityEngine;

public class ImportantDatas : MonoBehaviour
{
    private GameObject importantDatas = null;

    private int nextScene = 2;

    private void Awake()
    {
        if(importantDatas == null)
        {
            if (GameObject.FindGameObjectsWithTag("Datas").Length == 1)
                importantDatas = gameObject;
            else
                Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public int NextScene
    {
        set
        {
            nextScene = value;
        }
        get
        {
            return nextScene;
        }
    }

}
