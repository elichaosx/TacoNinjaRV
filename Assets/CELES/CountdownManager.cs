using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    [Header("Referencias de UI")]
    public TextMeshProUGUI countdownText;
    public GameObject canvasCountdown;

    [Header("Referencias de Juego")]
    public GameObject spawner;

    void Start()
    {
        if (spawner != null)
        {
            spawner.SetActive(false);
        }
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        int count = 3;

        while (count > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = count.ToString();
            }

            yield return new WaitForSeconds(1f); 
            count--;
        }

        yield return new WaitForSeconds(0.8f);
        
        if (canvasCountdown != null)
        {
            canvasCountdown.SetActive(false);
        }
        
        if (spawner != null)
        {
            spawner.SetActive(true);
        }
    }
}
