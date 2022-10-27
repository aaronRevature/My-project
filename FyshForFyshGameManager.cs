using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FyshForFyshGameManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    int credits;
    public Camera uiCamera;
    public Camera mainCamera;
    public TextMeshProUGUI title;
    float timeElapsed;
    float durationOfTimer = 10f;
    public GameObject boat;
    private MenusManager menus;


    public void ProManager()
    {   if (uiCamera.enabled == true){
            menus.PullPlayerProfile();
           
        }
      
    }
 
    void Start()
    {
        goldText.text = PlayerPrefs.GetInt("gold", credits).ToString();
        uiCamera.enabled = false;
        mainCamera.enabled = true;
        title.enabled = true;
        timeElapsed = 0f;
        
        
    }
//Camera change 
    void OpeningScene()
    {
        
            if (title.enabled == true)
            {
                mainCamera.enabled = true;
                uiCamera.enabled = false;
            }
            if (timeElapsed >= durationOfTimer)
            {
                title.enabled = false;
                mainCamera.enabled = false;
                uiCamera.enabled = true;
            }
            else return;
 

    }
    void BoatError(float errorcheck) {
        if (boat != null)
        {
            errorcheck += Time.deltaTime;

        }
    }

    void Update()
    {
     
        
        timeElapsed += Time.deltaTime;
        OpeningScene();
        BoatError(timeElapsed);
    }
}
