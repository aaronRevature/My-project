using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldValueManager : MonoBehaviour
{
    int gold;
    TextMeshProUGUI goldValue;
    // Start is called before the first frame update
    void Start()
    {
        gold = PlayerPrefs.GetInt("gold", 100);
        goldValue.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
