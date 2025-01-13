using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Store : MonoBehaviour
{
    public TMP_Text coinsText;

    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0); 
        coinsText.text = "Coins:" + totalCoins.ToString(); 
    }
}
