using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class FyshToken : MonoBehaviour
{
    public TextMeshProUGUI CreditText;
    public int Credit;
    
    void Start()
    {
        Credit = PlayerPrefs.GetInt("gold", 200);
        CreditText.text = Credit.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Credit = PlayerPrefs.GetInt("gold", 200);
    }
}
