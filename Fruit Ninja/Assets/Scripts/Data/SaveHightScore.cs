using System.IO;
using TMPro;
using UnityEngine;

public class SaveHightScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hightScoreText;
    [SerializeField] private Score _score;

    private string _savePath = "Data/Score.json";
    private string _fileName = "HightScore.json";

    private int _hightScore;

    private void Awake()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        _savePath = Path.Combine(Application.persistentDataPath, _fileName);
#else
        _savePath = Path.Combine(Application.dataPath, _fileName);
#endif
        Load();
        Events.OnBombExploded.AddListener(Save);
    }

    private void Save()
    {
        HightScoreStruct hightScoreStruct = new HightScoreStruct() 
        {
            HightScore = _hightScore
        };      

        if (_score.GameScore > _hightScore)
        {
            hightScoreStruct.HightScore = _score.GameScore;
        }

        try
        {       
            string json = JsonUtility.ToJson(hightScoreStruct, true);
            File.WriteAllText(_savePath, json);                    
        }
        catch (System.Exception)
        {
            Debug.Log("Save interrupted");
        }
    }

    private void Load()
    {
        if (!File.Exists(_savePath))
        {
            return;
        }

        try
        {
            string json = File.ReadAllText(_savePath);

            HightScoreStruct hightScoreStruct = JsonUtility.FromJson<HightScoreStruct>(json);
            _hightScore = hightScoreStruct.HightScore;
            _hightScoreText.text = $"<color=orange>Hight score: {_hightScore}</color>";
        }
        catch (System.Exception)
        {
            Debug.Log("Load interrupted");
        }
    }
}
