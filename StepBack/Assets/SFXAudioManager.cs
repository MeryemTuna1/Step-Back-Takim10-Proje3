using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioManager : MonoBehaviour
{
    public static SFXAudioManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;

        GameObject tempGO = new GameObject("SFX_" + clip.name);
        AudioSource source = tempGO.AddComponent<AudioSource>();

        source.clip = clip;
        source.volume = volume;
        source.loop = false;
        source.spatialBlend = 0f; // 2D
        source.Play();

        Destroy(tempGO, clip.length);
    }

    /// <summary>
    /// Loop eden ses (alarm, makine, jeneratör)
    /// </summary>
    public AudioSource PlayLoopSFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return null;

        GameObject loopGO = new GameObject("LoopSFX_" + clip.name);
        AudioSource source = loopGO.AddComponent<AudioSource>();

        source.clip = clip;
        source.volume = volume;
        source.loop = true;
        source.spatialBlend = 0f;
        source.Play();

        DontDestroyOnLoad(loopGO);
        return source;
    }

    /// <summary>
    /// Loop sesi durdurur
    /// </summary>
    public void StopLoopSFX(AudioSource source)
    {
        if (source == null) return;

        source.Stop();
        Destroy(source.gameObject);
    }
}
