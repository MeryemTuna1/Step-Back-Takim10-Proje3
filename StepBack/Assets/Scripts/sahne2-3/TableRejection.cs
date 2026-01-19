using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRejection : MonoBehaviour
{
    //yemekhane arkadaþlarý
    /*  public AudioClip innerVoiceClip;
      void OnTriggerEnter(Collider other)
      {
          if (!other.CompareTag("Player")) return;

          KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);


      }*/

    public npcMovement[] tableNPCs;
    public AudioClip innerVoiceClip, innerVoiceClip1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip);

            foreach (npcMovement npc in tableNPCs)
            {
                npc.StartSequence();
            }

            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip1);

            GetComponent<Collider>().enabled = false;
        }
    }
}
