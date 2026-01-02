using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarakterIcSesManager : MonoBehaviour
{
    public static KarakterIcSesManager Instance;
    public TextMeshProUGUI text;

    void Awake()
    {
        Instance = this;
        text.alpha = 0;
    }

    public void ShowText(string msg, float time = 4f)
    {
        StopAllCoroutines();
        StartCoroutine(Show(msg, time));
    }

    IEnumerator Show(string msg, float time)
    {
        text.text = msg;
        text.alpha = 1;
        yield return new WaitForSeconds(time);
        text.alpha = 0;
    }
}
