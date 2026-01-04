using UnityEngine;
using System.Collections.Generic;

namespace DefaultNamespace.AudioManager
{
    [CreateAssetMenu(menuName = "Audio/Audio Database")]
    public class AudioDatabase : ScriptableObject
    {
        public List<AudioEntry> sfx;
        public List<AudioEntry> bgm;

        Dictionary<string, AudioClip> sfxMap;
        Dictionary<string, AudioClip> bgmMap;

        public void Init()
        {
            Luna.Unity.Playable.InstallFullGame();
            
            sfxMap = new();
            bgmMap = new();

            foreach (var e in sfx)
                if (!sfxMap.ContainsKey(e.id))
                    sfxMap.Add(e.id, e.clip);

            foreach (var e in bgm)
                if (!bgmMap.ContainsKey(e.id))
                    bgmMap.Add(e.id, e.clip);
        }

        public AudioClip GetSFX(string id)
            => sfxMap.TryGetValue(id, out var clip) ? clip : null;

        public AudioClip GetBGM(string id)
            => bgmMap.TryGetValue(id, out var clip) ? clip : null;
    }
}