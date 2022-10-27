using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class fpsFYsh : MonoBehaviour
{
    public TextMeshProUGUI goldText;
     int gold;

    void Start()
    {
        gold = PlayerPrefs.GetInt("gold");
        goldText.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void GoHome()
    {
        PlayerPrefs.SetInt("gold", gold);
        SceneManager.LoadScene("menuscreen");
    }
}

