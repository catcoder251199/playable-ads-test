namespace DefaultNamespace.AudioManager
{
    public interface IAudioService
    {
        void PlaySFX(string id);
        void PlayBGM(string id, bool loop = true);
        void StopBGM();
        void SetSFXVolume(float volume);
        void SetBGMVolume(float volume);
    }

}