using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Wave;

public class UIWave : MonoBehaviour
{
    public event Action OnStartWave;   

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _waveCountText;

    [SerializeField] private WaveSystem _waveSystem;

    private WaveDescription _waveDescription;

    private void Start()
    {
        _button.onClick.AddListener(OnButtonCLickHandler);

        _waveDescription = _waveSystem._waveDescription;
        _waveCountText.text = $"{0} / {_waveDescription.WaveDatas.Count}";
        _waveSystem.OnWaveNumberChange += UpdateWaveCountText;     
    }

    private void UpdateWaveCountText(int waveNumber)
    {     
        _waveCountText.text = $"{waveNumber} / {_waveDescription.WaveDatas.Count}";       
    }

    private void OnButtonCLickHandler()
    {
        _button.interactable = false;

        OnStartWave?.Invoke();       
    }  
}
