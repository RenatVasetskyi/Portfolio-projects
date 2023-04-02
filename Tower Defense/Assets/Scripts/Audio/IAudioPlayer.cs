namespace Audio
{
    public interface IAudioPlayer
    {
        public void PlayMusic(MusicType musicType);
        public void PlaySfx(SfxType sfxType);       
    }
}
