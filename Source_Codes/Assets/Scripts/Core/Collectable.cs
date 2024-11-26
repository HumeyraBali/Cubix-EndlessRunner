using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Collectables : MonoBehaviour
{
    public int currentCoins;
    
    public void SaveCoins()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0); 
        totalCoins += currentCoins; 
        PlayerPrefs.SetInt("TotalCoins", totalCoins); 
        PlayerPrefs.Save(); 
    }
}
