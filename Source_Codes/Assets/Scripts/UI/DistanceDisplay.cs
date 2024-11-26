using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text  text;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;
    LevelStarter levelStarter;
    GameOverPlayer gameOverPlayer;
    private void Start() 
    {
        levelStarter = GetComponent<LevelStarter>();
        gameOverPlayer = FindObjectOfType<GameOverPlayer>();
    }

    void Update()
    {
        if (addingDis == false && levelStarter.startScore == true && gameOverPlayer.gameover == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        text.text = "" + disRun.ToString();
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}
