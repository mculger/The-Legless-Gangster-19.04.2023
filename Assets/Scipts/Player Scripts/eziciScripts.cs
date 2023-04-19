using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eziciScripts : MonoBehaviour
{
    PlayerController playercontroller;


    private void Awake()
    {
        playercontroller = Object.FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("silme"))
        {
            other.transform.parent.gameObject.SetActive(false);

            playercontroller.ZiplaZipla();
        }
    }
}
