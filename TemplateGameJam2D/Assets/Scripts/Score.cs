using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textHighScore;

    private int score = 0;

    private void Start()
    {
        textHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void AddScore(int n)
    {
        n = (int) Random.Range(0, 1000);

        score += n;

        textScore.text = score.ToString();
    }

    public void SaveHighScore()
    {
        if(PlayerPrefs.GetInt("HighScore") < score)
            PlayerPrefs.SetInt("HighScore", score);
    }
}
