using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayCarrySystem : MonoBehaviour
{
    public Transform trayHolder;
    public Transform carryPoint;

    public GameObject currentTray;

    public void TakeTray(GameObject tray)
    {
        currentTray = tray;

        tray.transform.SetParent(trayHolder);
        tray.transform.localPosition = Vector3.zero;
        tray.transform.localRotation = Quaternion.identity;

        KarakterIcSesManager.Instance.ShowText("Olsun… az da olsa yiyebilirim.");
    }

    public void PutFoodOnTray(GameObject food)
    {
        if (currentTray == null) return;

        food.transform.SetParent(currentTray.transform);
        food.transform.localPosition = Random.insideUnitSphere * 0.07f;
        food.transform.localRotation = Quaternion.identity;
    }
    public void PlaceTrayOnTable(Transform tablePoint)
    {
        if (currentTray == null) return;

        currentTray.transform.SetParent(null);
        currentTray.transform.position = tablePoint.position;
        currentTray.transform.rotation = tablePoint.rotation;

        currentTray = null;
    }
}
