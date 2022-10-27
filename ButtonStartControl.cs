using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UI.Dialogs;
public class ButtonStartControl : MonoBehaviour
{
	public Text goldtext, leveltext;
	public Button Level2, Level3, Level4;
	public GameObject mask_lock2, mask_lock3, mask_lock4;

	public uDialog_NotificationPanel NotificationPanel;
	public eThemeImageSet ImageSet = eThemeImageSet.SharpEdges;
	public eOutlineMode OutlineMode = eOutlineMode.Shadow;
	public string ColorScheme = "Dark";


	public RectTransform contentWindowContent;

	public void Start()
	{
		goldtext.text = PlayerPrefs.GetInt("gold").ToString();
		leveltext.text= "LEVEL "+ PlayerPrefs.GetInt("level",1).ToString();

	}
	void Enable()
	{
		goldtext.text = PlayerPrefs.GetInt("gold").ToString();
		leveltext.text= "LEVEL "+ PlayerPrefs.GetInt("level",1).ToString();

	}
	int current_level=0;
	public void Show_message(string level)
	{
		ShowSimpleDialog("Simple Dialog", "This is a simple <i>modal</i> Dialog.");
	}
	private uDialog ShowSimpleDialog(string title, string text, bool closeButton = false, eIconType iconType = eIconType.None)
	{
		var dialog = uDialog.NewDialog()
			.SetTitleText(title)
			.SetContentText(text)

			.SetModal(true, true)
			.SetDestroyAfterClose(true)
			.SetAllowDraggingViaTitle();

		if (closeButton)
		{
			dialog.AddButton("Close", (d) => d.Close());
		}

		return dialog;
	}

	public void Check_Level1()
	{
		current_level = PlayerPrefs.GetInt ("level");
		if (current_level > 10 && current_level < 30) {
			mask_lock2.SetActive (false);
			Play_level2 ();
		} else {
			//Show_message ("10");
		}
	}
	public void Check_Level2()
	{
		current_level = PlayerPrefs.GetInt ("level");
		if (current_level > 30 && current_level < 50) {
			mask_lock2.SetActive (false);
			mask_lock3.SetActive (false);
			Play_level3 ();
		}else {
			//Show_message ("30");
		}
	}
	public void Check_Level3()
	{
		current_level = PlayerPrefs.GetInt ("level");
		if (current_level > 50 && current_level < 750) {
			mask_lock2.SetActive (false);
			mask_lock3.SetActive (false);
			mask_lock4.SetActive (false);
			Play_level4 ();
		}else {
			//Show_message ("50");
		}
	}
    public void Play()
    {
        Application.LoadLevel("Play");
        AudioControl.Instance.clickButton();
    }
	public void Play_level2()
	{
		Application.LoadLevel("Play2");
		AudioControl.Instance.clickButton();
	}
	public void Play_level3()
	{
		Application.LoadLevel("Play3");
		AudioControl.Instance.clickButton();
	}
	public void Play_level4()
	{
		Application.LoadLevel("Play4");
		AudioControl.Instance.clickButton();
	}
    public void Shop()
    {
        Application.LoadLevel("Shop");
        AudioControl.Instance.clickButton();
    }
	public void Shop_IAP()
	{
		Application.LoadLevel("Shop_IAP");
		AudioControl.Instance.clickButton();
	}
    public void rate()
    {
        Application.OpenURL(" ");
    }

    public void showAds()
    {
		ShowRewardedVideo ();
    }
	void ShowRewardedVideo ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold",200) + 50);
			goldtext.text = PlayerPrefs.GetInt("gold").ToString();
			// Reward your player here.

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}
}
