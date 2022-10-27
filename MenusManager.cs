using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System;

public class MenusManager : MonoBehaviour
{ 
    
    public TextMeshProUGUI  gold;
    int goldValue;
    public GameObject panel;
    public GameObject displayPanel;    
    public TMP_InputField displayNameTextField;
    public TextMeshProUGUI displayName1, displayName2;

    private void Awake()
    {   GetVirtualCurrencies();
      
    }
    private void Start()
    {

        PullPlayerProfile();
      
        panel.SetActive(false);
        displayPanel.SetActive(false);
    }              
    private void Update()
    {
        
    }
    public void SetDisplayName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {   
            DisplayName = displayNameTextField.text
        }, result => {
            Debug.Log("The player's display name is now: " + result.DisplayName);
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void OpenDisplayPanel()
    {
        if(displayPanel != null)
        {
            displayPanel.SetActive(true);
        }
    }      
    public void SaveAndExitDisplay()
    {
        if(displayPanel != null)
        {
            displayName1.text = displayNameTextField.text;
            displayName2.text = displayName1.text;
            displayPanel.SetActive(false);
            SetDisplayName();

        }
    }


    public void OpenPanel()
    {
        if(panel != null)
        {
            panel.SetActive(true);
        }
    }
    public void ClosePanel()
    {
        if(panel != null)
        {
            panel.SetActive(false);
        }
    }

    public void PullPlayerProfile()
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {

            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true,
            
                

            }
        },
        result => result.PlayerProfile.DisplayName = displayName2.text,
        error => Debug.LogError(error.GenerateErrorReport()));



}
   

    public void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }
    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        PlayerPrefs.SetInt("gold", result.VirtualCurrency["FR"]);
        goldValue = result.VirtualCurrency["FR"];
        gold.text = goldValue.ToString();
        
    }                                                                
            
    void OnError(PlayFabError error)
    {
        Debug.Log("gold Error");
    }
 
public void ExitButton()
    {
        Application.Quit();
    }
   
    /*  public void GetAccountFromLogin()
 {
     var request = new GetPlayerProfileRequest
     {
         Email = email.text,
         DisplayName = customName.text
     };

 }  */

}
