using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarController : MonoBehaviour
{
    PlayerHealthController playerhealthController;
    private void Awake()
    {
        playerhealthController = Object.FindObjectOfType<PlayerHealthController>(); // bu scripte sahip olan objeye ula��r.
    }
    private void OnTriggerEnter2D(Collider2D other) // de�meyi kontrol eder.
    {
        if (other.tag == "Player")
        {
            playerhealthController.HasarAl();
        }
    }
}
