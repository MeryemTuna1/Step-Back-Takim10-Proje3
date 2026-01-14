using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarakterIcSesManager : MonoBehaviour
{
    public static KarakterIcSesManager Instance;

    [Header("UI")]
   // public TextMeshProUGUI text;

    [Header("Audio")]
    public AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

       //text.alpha = 0;
    }

    /// <summary>
    /// Ýç ses yazýsý + ses dosyasýný birlikte oynatýr
    /// </summary>
    public void PlayInnerVoice( AudioClip clip, float time = 10f)
    {
        StopAllCoroutines();
        StartCoroutine(Play( clip, time));
    }

    IEnumerator Play( AudioClip clip, float time)
    {
        // Yazý
      //  text.text = msg;
      //  text.alpha = 1;

        // Ses
        if (clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }

        yield return new WaitForSeconds(time);

        // Kapat
       // text.alpha = 0;
        audioSource.Stop();
    }
}
