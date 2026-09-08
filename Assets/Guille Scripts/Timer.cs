using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    float time = 0;

    void Update()
    {
        time += Time.deltaTime; //Aumenta el tiempo de manera independiente a los fps 

        int minutos = Mathf.FloorToInt(time / 60);
        int segundos = Mathf.FloorToInt(time % 60);

        TimerText.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
