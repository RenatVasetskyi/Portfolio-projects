using System.IO;
using TMPro;
using UnityEngine;

public class SaveRecordScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordScoreText;
    [SerializeField] private Score _score;

    private string _savePath = "Data/Score.json";
    private string _fileName = "HightScore.json";

    private int _recordScore;

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
        RecordScoreStruct recordScoreStruct = new RecordScoreStruct() 
        {
            RecordScore = _recordScore
        };      

        if (_score.GameScore > _recordScore)
        {
            recordScoreStruct.RecordScore = _score.GameScore;
        }

        try
        {       
            string json = JsonUtility.ToJson(recordScoreStruct, true);
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

            RecordScoreStruct recordScoreStruct = JsonUtility.FromJson<RecordScoreStruct>(json);
            _recordScore = recordScoreStruct.RecordScore;
            _recordScoreText.text = $"<color=orange>Record: {_recordScore}</color>";
        }
        catch (System.Exception)
        {
            Debug.Log("Load interrupted");
        }
    }
}
