using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dolapInteract : MonoBehaviour
{
    bool canInteract = false;
    bool done = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            canInteract = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            canInteract = false;
    }

    void Update()
    {
        if (!canInteract || done) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            done = true;
            KarakterIcSesManager.Instance.ShowText("Hazýrým. Aþaðý inmeliyim.");
        }
    }
}
