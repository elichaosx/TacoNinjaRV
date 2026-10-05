using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("Game Settings")]
    [SerializeField]
    private int lifes = 3;

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

    public void AddScore()
    {
    }

    public void LoseLife()
    {
        lifes--;
        
        if(lifes <= 0)
            Lose();
    }

    private void Lose()
    {
        Debug.Log("Has perdido");
    }
}
