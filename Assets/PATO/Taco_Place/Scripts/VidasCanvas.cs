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
        vidasImages[lifes].gameObject.SetActive(true);
    }
}
