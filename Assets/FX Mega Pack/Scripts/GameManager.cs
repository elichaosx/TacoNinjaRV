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

    [SerializeField]
    private ObjectSpawner[] spawners;

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

    public void StartGame()
    {
        foreach (ObjectSpawner spawner in spawners)
            spawner.StartSpawn();
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

        foreach (ObjectSpawner spawner in spawners) 
            spawner.StopSpawn();
        
        Debug.Log("Has perdido");
    }
}
