using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.Audio
{
    public interface IAudioFactory
    {
        AudioSource CreateAudioSource(AudioSourceType sourceType);
    }
}