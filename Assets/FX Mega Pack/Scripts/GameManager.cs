using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] 
    private GameObject GameOverCanvas;
    
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
        GameOverCanvas.SetActive(false);
    }


    public void LoseLife(int  amount = 1)
    {
        lifes = (int)Mathf.Clamp(lifes - amount, 0, Mathf.Infinity);
        
        if(lifes <= 0)
            Lose();
    }

    public void Lose()
    {
        GameOverCanvas.SetActive(true);
        
        //Spawner.dejar de spawnear
        
        Debug.Log("Has perdido");
    }
}
