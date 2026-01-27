using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeMonsterSequence : MonoBehaviour
{

    public Transform deskPoint;
    public monsterAI[] coworkers;

    public AudioClip innerVoiceClip1, innerVoiceClip;

    void Start()
    {
        //  OYUN BAÞINDA HEPSÝNÝ GÝZLE
        foreach (var npc in coworkers)
        {
            if (npc != null)
                npc.gameObject.SetActive(false);
        }
    }

    public void StartSequence()
    {
        StartCoroutine(SequenceRoutine());
    }

    IEnumerator SequenceRoutine()
    {
        // CANAVARLAR SIRAYLA
        foreach (var npc in coworkers)
        {
            if (npc == null) continue;

            //  SIRASI GELÝNCE GÖRÜNSÜN
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

        yield return new WaitForSeconds(2f);
        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);
    }
}
