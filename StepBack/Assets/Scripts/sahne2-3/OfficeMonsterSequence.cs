using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeMonsterSequence : MonoBehaviour
{
    public Transform deskPoint;
    public monsterAI[] coworkers;

    public stressKuculmePlayer stressPlayer;

    public GameObject documentPrefab;
    public Transform documentSpawnPoint;

    public void StartSequence()
    {
        // Oyuncu küçülmeye baþlar
        stressPlayer.StartOfficeStress();

        // NPC’leri masaya gönder
        foreach (var npc in coworkers)
        {
            npc.GoToDesk(deskPoint);
        }

        StartCoroutine(WaitAndDropDocuments());
    }

    IEnumerator WaitAndDropDocuments()
    {
        // TÜM NPC’LER VARANA KADAR BEKLE
        while (!AllArrived())
        {
            yield return null;
        }

        // Evrak konur
        SpawnDocument();

        KarakterIcSesManager.Instance.ShowText(
            "Bunlar benim deðil..."
        );

        yield return new WaitForSeconds(1.2f);

        // Canavarlar yok olur
        HideMonsters();

        Invoke(nameof(SecondThought), 1f);
    }

    bool AllArrived()
    {
        foreach (var npc in coworkers)
        {
            if (!npc.Arrived)
                return false;
        }
        return true;
    }

    void SpawnDocument()
    {
        GameObject doc = Instantiate(
            documentPrefab,
            documentSpawnPoint.position,
            documentSpawnPoint.rotation
        );

        Rigidbody rb = doc.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // sabit dursun
        }

       
    }
    void HideMonsters()
    {
        foreach (var npc in coworkers)
        {
            npc.gameObject.SetActive(false);
        }
    }

    void SecondThought()
    {
        KarakterIcSesManager.Instance.ShowText(
            "Ne kadar yaparsam yapayým… eksik kalýyor."
        );
    }
}
