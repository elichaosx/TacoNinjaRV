using System;
using UnityEngine;
using UnityEngine.UI;

public class VidasCanvas : MonoBehaviour
{
    [SerializeField] private Image[] vidasImages;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        GameManager.instance.OnLifesChange.AddListener((lifes) => UpdateLives(lifes));
    }

    private void UpdateLives(int lifes)
    {
        for(int i = 0; i < lifes-1; i++)
        {
            vidasImages[i].enabled = true;
        }
    }

    public void OnEnable()
    {
        vidasImages = GetComponentsInChildren<Image>();
    }
}
