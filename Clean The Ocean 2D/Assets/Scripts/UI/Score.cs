using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score = 0;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {      
        EventSystem.OnBottleTaken.AddListener(AddScore);
    }

    private void AddScore()
    {
        _score++;
        _scoreText.text = $"Score: <color=green>{_score}</color>";
    }
}
