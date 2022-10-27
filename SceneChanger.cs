using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {

    public GameObject OptionsPanel;
    public Button OptionsButton;

    private void Start()
    {
        if (OptionsButton != null)
        {
            OptionsPanel.SetActive(false);
        }
    }
    public void OptionsButtonClick()
    {
        OptionsPanel.SetActive(true);
    }
    public void SaveOptionsButton()
    {
        OptionsPanel.SetActive(false);
    }
    public void Scene1()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("menuScreen");
       
    }
    public void roosterCoopLoad()
    {
        SceneManager.LoadScene("ROOSTERCOOP");
    }
    public void arShotLoad()
    {
        SceneManager.LoadScene("ARShot");
    }
    public void dynoBlastLoad()
    {
        SceneManager.LoadScene("Play");
    }
    public void baccaratLoad()
    {
        SceneManager.LoadScene("BACCARATMOBILE");
    }
    public void fyshForFish() 
    {
      SceneManager.LoadScene("FyshForFish");
    }
    public void fyshNewGame()
    {
        SceneManager.LoadScene("fyshscene");
    }
}   

                                           