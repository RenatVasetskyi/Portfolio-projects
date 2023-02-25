using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    public int Score => _score;
   
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
