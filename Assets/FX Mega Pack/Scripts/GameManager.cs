using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] 
    private GameObject GameOverCanvas;
    
    [Header("Game Settings")]
    [SerializeField]
    private int lifes = 3;

    public UnityEvent<int> OnLifesChange;

    private void Start()
    {
        GameOverCanvas.SetActive(false);
    }
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


    public void LoseLife(int  amount = 1)
    {
        lifes = (int)Mathf.Clamp(lifes - amount, 0, Mathf.Infinity);

        OnLifesChange?.Invoke(lifes);

        if (lifes <= 0)
            Lose();
    }

    public void Lose()
    {
        GameOverCanvas.SetActive(true);
        
        //Spawner.dejar de spawnear
        
        Debug.Log("Has perdido");
    }
}
