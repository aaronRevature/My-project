using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;


public class PlayfabController : MonoBehaviour
{
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public SceneChanger sceneChanger;
    public TextMeshProUGUI goldValueText;




    public void RegisterButton()
    {
        if (passwordInput.text.Length <= 6)
        {
            messageText.text = "Password is to short";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,

        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {

       
        messageText.text = "Successful Login";
        sceneChanger.Scene2();

    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and Logged IN";
        
    }
    //Successful Login Section with beginning Gold Balance and Leaderboards

    void OnError(PlayFabError error)
    {
        messageText.text = "error";
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }
}