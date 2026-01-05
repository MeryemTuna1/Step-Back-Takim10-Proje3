using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stressKuculmePlayer : MonoBehaviour
{
    public float shrinkSpeed = 0.02f;
    public float minScale = 0.85f;

    bool officeActive = false;
    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        if (!officeActive) return;

        if (transform.localScale.x > minScale)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        }
    }

    public void StartOfficeStress()
    {
        officeActive = true;
       /* KarakterIcSesManager.Instance.ShowText(
            "Bakmamaya çalýþ… gözlerini üstümde hissediyorum."
        );*/
    }
}
