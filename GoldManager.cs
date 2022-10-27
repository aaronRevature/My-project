using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class GoldManager : MonoBehaviour {
    public static GoldManager Instance;
    public int balance;
    [SerializeField] private int testGold = 0;
    public int score { get; set; }
    public readonly string GOLD_KEY = "goldKey";
    public readonly string GOLD_WEEKLY = "goldWeekly";
    public readonly string GOLD_DAILY = "goldDaily";

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        LoadGold();
        } 
        public void LoadGold(){
           score = PlayerPrefs.GetInt(GOLD_KEY, testGold);
            }
         public void AddGold(int balance){
           score += balance;
           PlayerPrefs.SetInt(GOLD_KEY, score);
           PlayerPrefs.Save();
            }
         public void RemoveGold(int balance){
            score -= balance; 
            PlayerPrefs.SetInt(GOLD_KEY, score);
            PlayerPrefs.Save(); 
            }


}
