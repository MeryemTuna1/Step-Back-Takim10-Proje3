using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCarry : MonoBehaviour
{
    public Transform carryPoint;

    GameObject carriedPlate;        // elde tutulan tabak
    GameObject plateInRange;        // yakýndaki tabak
    dropZone currentDropZone;  // içinde bulunulan tezgâh alaný

    public AudioClip innerVoiceClip;

    void Update()
    {
        // TABAK ALMA
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (carriedPlate == null && plateInRange != null)
            {
                PickPlate();
                
            }
        }

        // TABAK BIRAKMA (SADECE TEZGÂHTA)
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (carriedPlate != null && currentDropZone != null)
            {
                DropPlate();
                KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip,10f);
            }
        }
    }

    void PickPlate()
    {
        carriedPlate = plateInRange;

        // Fizik varsa kapat (elde titremesin)
        Rigidbody rb = carriedPlate.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        carriedPlate.transform.SetParent(carryPoint);
        carriedPlate.transform.localPosition = Vector3.zero;
        carriedPlate.transform.localRotation = Quaternion.identity;

        plateInRange = null;
    }

    void DropPlate()
    {
        carriedPlate.transform.SetParent(null);
        carriedPlate.transform.position = currentDropZone.snapPoint.position;
        carriedPlate.transform.rotation = currentDropZone.snapPoint.rotation;

        Rigidbody rb = carriedPlate.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;

        carriedPlate = null;
        currentDropZone = null;
    }

    void OnTriggerEnter(Collider other)
    {
        // Tabak alma alanýna girince
        if (other.TryGetComponent(out plateZone pickZone))
        {
            plateInRange = pickZone.plate;

        }

        // Tezgâh alanýna girince
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
