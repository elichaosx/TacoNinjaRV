using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.PlayerLoop;

public class Contadordeingredientes : MonoBehaviour
{
    public static Contadordeingredientes instance { get; private set; }
    [SerializeField] private TextMeshProUGUI textopuntuacion;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Agregarpuntuacion()
    {
        score++;
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (textopuntuacion != null)
        {
            textopuntuacion.text = score.ToString();

        }

    }
}
