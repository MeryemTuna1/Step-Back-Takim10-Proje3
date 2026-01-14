using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dolapInteraktif : MonoBehaviour
{

    [Header("Player Setup")]
    public GameObject player;               // Player GameObject
    public Animator playerAnimator;         // Animator
    public string changeClothesTrigger = "ChangeClothes";

    [Header("Original Meshes")]
    public GameObject originalMeshRoot;     // Üstteki Mesh_0
    public GameObject originalMixamoMesh;   // Altýndaki mixamorig:Hips

    [Header("Clothes Prefabs")]
    public GameObject workPrefab;           // Dolap iþ kýyafeti prefab

    [Header("Inner Voice")]
    public AudioClip innerVoiceClip;
    public float innerVoiceTime = 10f;

    private bool changed = false;           // Kýyafet deðiþti mi


    [Header("Avatars")]
    public Avatar pijamaAvatar;
    public Avatar workAvatar;

  

    void Start()
    {

        // Baþlangýçta orijinal meshler aktif, kýyafet kapalý
        if (originalMeshRoot != null)
            originalMeshRoot.SetActive(true);

        if (originalMixamoMesh != null)
            originalMixamoMesh.SetActive(true);

        if (workPrefab != null)
            workPrefab.SetActive(false);

        // Baþlangýç avatarý
        if (playerAnimator != null && pijamaAvatar != null)
            playerAnimator.avatar = pijamaAvatar;
    }

    void OnMouseDown()
    {


        if (changed) return;
        changed = true;

        // Orijinal meshleri kapat
        if (originalMeshRoot != null)
            originalMeshRoot.SetActive(false);

        if (originalMixamoMesh != null)
            originalMixamoMesh.SetActive(false);

        // Dolap kýyafetini aç
        if (workPrefab != null)
            workPrefab.SetActive(true);

        // Animatörü deðiþtir
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null)
            pm.SwitchToWorkAnimator();

        // Ýç sesi çal
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, innerVoiceTime);


        if (playerAnimator != null && workAvatar != null)
        {
            playerAnimator.avatar = workAvatar;
            playerAnimator.Rebind();   //  ÇOK ÖNEMLÝ
            playerAnimator.Update(0f);
        }
    }


 

   
}
