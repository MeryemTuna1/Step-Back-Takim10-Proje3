using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoworkerGroupTrigger : MonoBehaviour
{
    public stressKuculmePlayer stressController;
    public Transform[] coworkers;

    public AudioClip innerVoiceClip, innerVoiceClip1;
    public Animator animE1,animK1;

    public float walkSpeed = 1.5f;
    public float disappearTime = 5f;
    public Transform walkTarget; // NPC'nin yürüyeceði nokta

    bool used = false;

    void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;

        used = true;

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        // Kalkma animasyonu
        animE1.SetTrigger("isPlayerGeldi");
        

        // Küçülme
        stressController.transform.localScale -= Vector3.one * 0.05f;

        // NPC masaya bakmasýn
        foreach (Transform npc in coworkers)
        {
            npc.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Yürü + yok ol
        StartCoroutine(NPCWalkAndDisappear());
    }

    IEnumerator NPCWalkAndDisappear()
    {
        
        // Kalkma animasyonunun bitmesini bekle
        yield return new WaitForSeconds(1.5f); // anim süresine göre ayarla
        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip1,5f);
        animE1.SetBool("Walk", true);
        animK1.SetTrigger("isPlayerGeldi");
        float timer = 0f;

        while (timer < disappearTime)
        {
            if (walkTarget != null)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    walkTarget.position,
                    walkSpeed * Time.deltaTime
                );
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Yok ol
        gameObject.SetActive(false);
        // veya Destroy(gameObject);
    }


    /*
    public stressKuculmePlayer stressController;
    public Transform[] coworkers;

    bool used = false;

    public AudioClip innerVoiceClip;
    public Animator anim;
    void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;

        used = true;

        // Fýsýltýyý kes
        // AudioManager.Instance.Play("WhisperStop");

        // Ýç ses
        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

        anim.SetTrigger("isPlayerGeldi");

        // Küçülme artar
        stressController.transform.localScale -= Vector3.one * 0.05f;

        // NPC'ler masalarýna döner
        foreach (Transform npc in coworkers)
        {
            npc.rotation = Quaternion.Euler(0, 180, 0);
        }
    }*/
}
