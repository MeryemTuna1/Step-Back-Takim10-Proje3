using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCarry : MonoBehaviour
{
    public Transform carryPoint;
    public Animator playerAnimator;

    GameObject carriedPlate;
    GameObject plateInRange;
    dropZone currentDropZone;

    [Header("Inner Voice")]
    public AudioClip innerVoiceClip;

    [Header("Audio Clips")]
    public AudioClip tabakAlmaClip;
    public AudioClip tabakBirakmaClip, acelemVar;

    public AudioSource audioSource;   //  EKLENDÝ

    public bool isOk = false;

    void Update()
    {
       

        // TABAK ALMA
        if (Input.GetMouseButton(0))
        {
            if (carriedPlate == null && plateInRange != null)
            {
                PickPlate();
                KarakterIcSesManager.Instance.PlayInnerVoice(acelemVar);
                Debug.Log("acelem var");
                
            }
        }

        // TABAK BIRAKMA
        if (Input.GetMouseButton(1))
        {
            if (carriedPlate != null && currentDropZone != null)
            {
                DropPlate();
                KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip, 10f);
                
            }
        }
    }

    void PickPlate()
    {
        carriedPlate = plateInRange;

        Rigidbody rb = carriedPlate.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        carriedPlate.transform.SetParent(carryPoint);
        carriedPlate.transform.localPosition = Vector3.zero;
        carriedPlate.transform.localRotation = Quaternion.identity;

        plateInRange = null;

        //  ANÝMASYON
        playerAnimator.SetBool("isCarrying", true);

        //  TABAK ALMA SESÝ
        if (tabakAlmaClip != null)
            audioSource.PlayOneShot(tabakAlmaClip);
    }

    void DropPlate()
    {
        carriedPlate.transform.SetParent(null);
        carriedPlate.transform.position = currentDropZone.snapPoint.position;
        carriedPlate.transform.rotation = currentDropZone.snapPoint.rotation;

        Rigidbody rb = carriedPlate.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;

        //  ANÝMASYON
        playerAnimator.SetBool("isCarrying", false);

        //  TABAK BIRAKMA SESÝ
        if (tabakBirakmaClip != null)
            audioSource.PlayOneShot(tabakBirakmaClip);

        carriedPlate = null;
        currentDropZone = null;

        isOk = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out plateZone pickZone))
        {
            plateInRange = pickZone.plate;
        }

        if (other.TryGetComponent(out dropZone dropZone))
        {
            currentDropZone = dropZone;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out plateZone pickZone))
        {
            if (plateInRange == pickZone.plate)
                plateInRange = null;
        }

        if (other.TryGetComponent(out dropZone dropZone))
        {
            if (currentDropZone == dropZone)
                currentDropZone = null;
        }
    }
}
