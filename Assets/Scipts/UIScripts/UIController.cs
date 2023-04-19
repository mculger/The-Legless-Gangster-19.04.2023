using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image armor1_img, armor2_img, armor3_img;

    [SerializeField]
    Sprite tamArmor, bosArmor;

    PlayerHealthController playerhealthController;

    LevelManager levelManager;

    [SerializeField]
    TMP_Text moneytxt;

    private void Awake()
    {
        playerhealthController = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }
    public void SaglikDurumunuGuncelle()
    {
        switch(playerhealthController.gecerliHealth) 
        {
            case 3:
                armor1_img.sprite = tamArmor;
                armor2_img.sprite = tamArmor;
                armor3_img.sprite = tamArmor;
                break;
            case 2:
                armor1_img.sprite = tamArmor;
                armor2_img.sprite = tamArmor;
                armor3_img.sprite = bosArmor;
                break;
            case 1:
                armor1_img.sprite = tamArmor;
                armor2_img.sprite = bosArmor;
                armor3_img.sprite = bosArmor;
                break;
            case 0:
                armor1_img.sprite = bosArmor;
                armor2_img.sprite = bosArmor;
                armor3_img.sprite = bosArmor;
                break;
        }
    }

    public void paraSayisiniGuncelle()
    {
        moneytxt.text = levelManager.toplananparasayisi.ToString();
    }
}
