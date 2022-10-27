using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSfysh : MonoBehaviour
{
    int gold;
    public TextMeshProUGUI goldtext;

    // Start is called before the first frame update
    void Start()
    {
        gold = PlayerPrefs.GetInt("credits");
        goldtext.text = PlayerPrefs.GetInt("credits").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void creditManager()
    {

    }
}
