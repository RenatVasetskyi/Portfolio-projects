using System;

namespace Assets.Scripts.Waves
{
    public interface IWaveSystem
    {
        public event Action<int> OnWaveNumberChanged;
        void RunStartWaveCoroutine();
        void StopWavesCoroutine();
    }
}