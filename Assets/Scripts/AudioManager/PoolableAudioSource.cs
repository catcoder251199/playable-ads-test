using DefaultNamespace.Pooling;
using UnityEngine;
namespace DefaultNamespace.AudioManager
{
    public class PoolableAudioSource : PoolableMonoBehaviour
    {
        public AudioSource Source { get; private set; }

        void Awake()
        {
            Source = GetComponent<AudioSource>();
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
            Source.Stop();
        }

        public override void OnDespawn()
        {
            Source.Stop();
            base.OnDespawn();
        }
    }
}