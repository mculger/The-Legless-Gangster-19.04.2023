using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneymanager : MonoBehaviour
{
    [SerializeField]
    bool parami,armormu;

    bool toplandimi;

    UIController uiController;

    PlayerHealthController playerHealthController;


    LevelManager levelManager;

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UIController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !toplandimi) // deðidiði nesnenin tagi player ise..
        {
            if(parami)
            {
                levelManager.toplananparasayisi++;

                toplandimi = true;

                Destroy(gameObject);

                uiController.paraSayisiniGuncelle();
            }
            
            if(armormu)
            {
                if(playerHealthController.gecerliHealth != playerHealthController.maxHealth)
                {
                    
                    toplandimi = true;

                    Destroy(gameObject);
                    playerHealthController.CaniArttirFNC();
                }
            }

        }
    }
}
