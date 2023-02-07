using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDescription", menuName = "CreateWave/Wave")]
public class WaveDescription : ScriptableObject
{
    [SerializeField] private List<WaveData> _waveDatas = new List<WaveData>();
    [SerializeField] private int _level;

    public List<WaveData> WaveDatas => _waveDatas;
    public int Level => _level;
}
