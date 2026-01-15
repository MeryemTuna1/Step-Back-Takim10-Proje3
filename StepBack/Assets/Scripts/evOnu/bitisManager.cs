using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bitisManager : MonoBehaviour
{
    public static bitisManager Instance;
    public Image fadeImage;
    public float fadeDuration = 2f;

    public AudioClip innerVoiceClip;
    void Awake()
    {
        Instance = this;
    }

    public void FadeToBlack()
    {
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        yield return new WaitForSeconds(2f);

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, 10f);

        float t = 0f;
        Color c = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1f;
        fadeImage.color = c;


        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("mainMenu");
    }
}
