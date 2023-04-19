using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth;
    public int gecerliHealth;

    UIController uiController;

    public float yenilmezlikSuresi;
    float yenilmezlikSayaci;

    SpriteRenderer sr;

    PlayerController playerController;


    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        uiController = Object.FindObjectOfType<UIController>();
        
    }

    private void Start()
    {
        gecerliHealth = maxHealth;
    }

    private void Update()
    {
        yenilmezlikSayaci-= Time.deltaTime;

        if(yenilmezlikSayaci <= 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 255f);
        }
    }

    public void HasarAl()
    {
        if(yenilmezlikSayaci <= 0)
        {
            gecerliHealth--;

            if (gecerliHealth <= 0)
            {
                gecerliHealth = 0;
                gameObject.SetActive(false);
            } else
            {
               
                 yenilmezlikSayaci = yenilmezlikSuresi;
                sr.color = new Color(sr.color.r,sr.color.g,sr.color.b, 0.5f);

                playerController.GeriTepmeFNC();
                 
              
            }
            
            uiController.SaglikDurumunuGuncelle();
        }
        
    } public void CaniArttirFNC()
    {
        gecerliHealth++;

        if (gecerliHealth >= maxHealth)
        {
            gecerliHealth = maxHealth;
        }

        uiController.SaglikDurumunuGuncelle();

    }
}
