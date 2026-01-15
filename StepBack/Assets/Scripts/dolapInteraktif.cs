using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class dolapInteraktif : MonoBehaviour
{
    [Header("Inner Voice")]
    public AudioClip innerVoiceClip;
    public float innerVoiceTime = 10f;

    [Header("Audio Clips")]
    public AudioClip dolapOpenClip;
    public AudioClip dolapCloseClip;

    private bool used = false;

    void OnMouseDown()
    {
        if (used) return;
        used = true;

        CameraManager.Instance.SwitchToThirdPerson();
        StartCoroutine(DolapSequence());
    }

    IEnumerator DolapSequence()
    {
        // Dolap açýlma sesi
        if (dolapOpenClip != null)
            SFXAudioManager.Instance.PlaySFX(dolapOpenClip, 1f);

        // 2 saniye bekle
        yield return new WaitForSeconds(2f);

        //  Ýç ses
        if (innerVoiceClip != null && KarakterIcSesManager.Instance != null)
            KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, innerVoiceTime);

        // 4 Dolap kapanma sesi
        if (dolapCloseClip != null)
            SFXAudioManager.Instance.PlaySFX(dolapCloseClip, 1f);
    }



    /*
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
            Transform root = playerAnimator.transform;

            Vector3 worldPos = root.position;
            Quaternion worldRot = root.rotation;

            playerAnimator.avatar = workAvatar;
            playerAnimator.Rebind();
            playerAnimator.Update(0f);

            //  POZÝSYONU GERÝ KOY
            root.position = worldPos;
            root.rotation = worldRot;
        }
    }

    */




}
