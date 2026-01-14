using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoworkerGroupTrigger : MonoBehaviour
{
    public stressKuculmePlayer stressController;
    public Transform[] coworkers;

    bool used = false;

    public AudioClip innerVoiceClip;

    void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;

        used = true;

        // Fýsýltýyý kes
        // AudioManager.Instance.Play("WhisperStop");

        // Ýç ses
        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        // Küçülme artar
        stressController.transform.localScale -= Vector3.one * 0.05f;

        // NPC'ler masalarýna döner
        foreach (Transform npc in coworkers)
        {
            npc.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
