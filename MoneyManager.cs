using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyManager : MonoBehaviour
{
 
        public Text Gold;
        private UILabel _lb;
        public SlotCredits slotCredits;
        public BalanceManager balanceManager;
        private static MoneyManager _instance;
        void Start()
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold", 200));
            _lb = GetComponent<UILabel>();
            _instance = this;
        Gold.text = PlayerPrefs.GetInt("gold", slotCredits.credits) + "";
        slotCredits.credits = PlayerPrefs.GetInt("gold");
        balanceManager.gold = PlayerPrefs.GetInt("gold");
        
    }

        // Update is called once per frame
        void Update()
        {

    
        }
    }

