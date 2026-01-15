using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeMonsterSequence : MonoBehaviour
{
    public Transform deskPoint;
    public monsterAI[] coworkers;

    public stressKuculmePlayer stressPlayer;
    public AudioClip innerVoiceClip1;

    public void StartSequence()
    {
        if (stressPlayer != null)
            stressPlayer.StartOfficeStress();

        StartCoroutine(SequenceRoutine());
    }

    IEnumerator SequenceRoutine()
    {
        // CANAVARLAR SIRAYLA
        foreach (var npc in coworkers)
        {
            if (npc == null) continue;

            npc.gameObject.SetActive(true);

            yield return StartCoroutine(
                npc.GoToDeskAndDrop(deskPoint)
            );

            // Canavarlar arasýnda küçük boþluk (gerilim için)
            yield return new WaitForSeconds(0.5f);
        }

        // Hepsi bittikten sonra
        

        yield return new WaitForSeconds(1f);

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip1);
    }
}
