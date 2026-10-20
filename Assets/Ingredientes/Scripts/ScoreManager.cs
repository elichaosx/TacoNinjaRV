using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    private int score = 0;
    
    private void Awake()
    {
        if(instance != null &&  instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void AddScore(int cant = 100)
    {
        score += cant;

        if (score > PlayerPrefs.GetInt("HighScore", 0))
            UpdateRecord(score);
    }

    private void UpdateRecord(int record)
    {
        PlayerPrefs.SetInt("HighScore", record);
    }
}
