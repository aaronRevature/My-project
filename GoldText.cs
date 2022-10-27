using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    public Text Gold;
    private UILabel _lb;
    void Start()
    {
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold", 200));
        _lb = GetComponent<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Gold.text = PlayerPrefs.GetInt("gold", 200) + "";
    }
}
       
        
    

