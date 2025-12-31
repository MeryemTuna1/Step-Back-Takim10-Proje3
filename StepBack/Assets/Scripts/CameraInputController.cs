using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            CameraManager.Instance.SwitchToFirstPerson();

        if (Input.GetKeyDown(KeyCode.T))
            CameraManager.Instance.SwitchToTopDown();

        if (Input.GetKeyDown(KeyCode.C))
            CameraManager.Instance.SwitchToThirdPerson();
    }
}
