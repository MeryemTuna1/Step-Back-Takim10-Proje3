using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dolapInteract : MonoBehaviour
{
    bool done = false;

    void OnMouseDown()
    {
        if (done) return;

        done = true;
        KarakterIcSesManager.Instance.ShowText("Hazýrým. Aþaðý inmeliyim.");
    }
}
