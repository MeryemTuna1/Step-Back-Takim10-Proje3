using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayPickup : MonoBehaviour
{
    void OnMouseDown()
    {
        TrayCarrySystem player = FindObjectOfType<TrayCarrySystem>();
        player.TakeTray(gameObject);

        GetComponent<Collider>().enabled = false;
    }
}
