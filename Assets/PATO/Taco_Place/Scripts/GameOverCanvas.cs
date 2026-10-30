using TMPro;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _recordText;

    private void OnEnable()
    {
        _scoreText.text = ScoreManager.instance.GetScore().ToString();
        _recordText.text = ScoreManager.instance.GetRecord().ToString();
    }
}
