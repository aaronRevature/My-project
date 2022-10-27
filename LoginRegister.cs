using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginRegister : MonoBehaviour
{
    public GameObject Username;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI displayText;

    public void OnLoginButton()
    {
        LoginWithPlayFabRequest loginRequest = new LoginWithPlayFabRequest
        {
            Username = usernameInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.LoginWithPlayFab
    (loginRequest, result =>
   {
       Debug.Log("logged in as " + result.PlayFabId);


   },
    error => Debug.Log(error.ErrorMessage));
        SceneManager.LoadScene("Home");
    }
        public void OnRegisterButton()
    {
      
        RegisterPlayFabUserRequest registerRequest =
            new RegisterPlayFabUserRequest
            {
                Username = usernameInput.text,
                DisplayName = usernameInput.text,
                Password = passwordInput.text,
                RequireBothUsernameAndEmail = false

            };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest,
            result =>
            {
                Debug.Log(result.PlayFabId);
            }
            ,
            error =>
            {
                Debug.Log(error.ErrorMessage);
            });
     
  

     }
}
