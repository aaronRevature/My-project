using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class OpenPanelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Credits;
    [SerializeField] TextMeshProUGUI Bullets;
    [SerializeField] private int MaxCredits;
    [SerializeField] private int CreditAmount;
    [SerializeField] private int BulletAmount;
    [SerializeField] private int BulletsLive;
    [SerializeField] TMP_InputField Cinput;
    [SerializeField] TMP_InputField Binput;
    public BuyButton buyButton;
    public int Credit;
    public int Bullet;
    public FyshToken fyshToken;

    void Start()
    {
        Cinput.text = "0";
        Binput.text = "0";
        CreditAmount = 0;
        MaxCredits = PlayerPrefs.GetInt("gold", 200);


    }


    public void SwapCredits()
    {
        if (CreditAmount <= MaxCredits)
        {
            int CreditAmount = Int32.Parse(Cinput.text);
            Credit = MaxCredits - CreditAmount;
            Bullet = CreditAmount * 10;
            Credits.text = Credit.ToString();
            Bullets.text = Bullet.ToString();
            buyButton.ClosePanel();
            Cinput.text = "0";

        }
    }
    public void SwapBullets()
    {
        int BulletsLive = Int32.Parse(Bullets.text);
        int BulletAmount = Int32.Parse(Binput.text);
        Bullet = BulletsLive - BulletAmount;
        Credit = BulletAmount / 10;
        Credits.text = (Credit + PlayerPrefs.GetInt("gold", 0)).ToString();
        Bullets.text = Bullet.ToString();
        buyButton.ClosePanel();
        Binput.text = "0";

    }
}


