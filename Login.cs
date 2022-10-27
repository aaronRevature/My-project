using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject confpassword;
    public GameObject Button;
    private string UserName;
    [SerializeField] private string PassWord;
    private string ConfPassword;
    private string Form;
    private bool UN;
    private bool PW;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Register()
    {
        bool UN = false;
        bool PW = false;
        if(UserName !="")
        if (System.IO.File.Exists(@"C: \Users\aaron\OneDrive\Desktop\New Unity Project(20)\Library\BuildPlayerData"+UserName+".txt")){
                UN = true;
        }
        else
        {
                Debug.LogWarning("Username Taken");
        }
        else
        {
            Debug.LogWarning("Username field Empty");
        }
        if(PassWord != "")
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused){
                password.GetComponent <InputField>().Select();
                
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                Button.GetComponent<InputField>().Select();

            }

            
            UserName = username.GetComponent<InputField>().text;
            PassWord = password.GetComponent<InputField>().text;
            ConfPassword = confpassword.GetComponent<InputField>().text;
        }
    }
    public void submit()
    {

        SceneManager.LoadScene("Home");
    }
        
}
