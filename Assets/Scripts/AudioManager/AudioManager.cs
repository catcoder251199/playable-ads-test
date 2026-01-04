using System.Collections;
using DefaultNamespace.Pooling;
using UnityEngine;

namespace DefaultNamespace.AudioManager
{
    public class AudioManager 
    : GenericMonoSingleton<AudioManager>, IAudioService
{
    [Header("Config")]
    [SerializeField] AudioDatabase database;

    [Header("Audio Sources")]
    [SerializeField] AudioSource bgmSource;
    [SerializeField] PoolableAudioSource sfxSourcePrefab;

    [Header("Settings")]
    [SerializeField] int sfxPoolSize = 10;

    float bgmVolume = 1f;
    float sfxVolume = 1f;

    GenericGameObjectPool<PoolableAudioSource> sfxPool;

    protected override void Awake()
    {
        base.Awake();

        database.Init();

        // Pool SFX AudioSource
        sfxPool = new GenericGameObjectPool<PoolableAudioSource>(
            sfxSourcePrefab,
            sfxPoolSize,
            transform
        );

        ServiceLocator.Register<IAudioService>(this);
    }

    // -------------------
    // SFX
    // -------------------
    public void PlaySFX(string id)
    {
        var clip = database.GetSFX(id);
        if (clip == null) return;

        var pooled = sfxPool.Spawn();
        var source = pooled.Source;

        source.clip = clip;
        source.volume = sfxVolume;
        source.Play();

        StartCoroutine(ReleaseAfterPlay(pooled));
    }

    IEnumerator ReleaseAfterPlay(PoolableAudioSource pooled)
    {
        yield return new WaitWhile(() => pooled.Source.isPlaying);
        sfxPool.Despawn(pooled);
    }

    // -------------------
    // BGM
    // -------------------
    public void PlayBGM(string id, bool loop = true)
    {
        var clip = database.GetBGM(id);
        if (clip == null) return;

        if (bgmSource.clip == clip && bgmSource.isPlaying)
            return;

        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.volume = bgmVolume;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
        bgmSource.clip = null;
    }

    // -------------------
    // Volume
    // -------------------
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume;
    }
}
}