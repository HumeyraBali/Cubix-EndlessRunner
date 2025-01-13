using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private GameTimeManager timer;
    [SerializeField] GameObject store;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject LeaderBoardPanel;
    [SerializeField] GameObject LeaderBoardCanvas;
    [SerializeField] GameObject firstTimePopup;
    private bool isFirstTime;
    private bool firstTimeEnter;

    void Start()
    {
        timer = FindObjectOfType<GameTimeManager>();

        isFirstTime = !PlayerPrefs.HasKey("HasOpenedBefore");

        if (isFirstTime)
        {
            PlayerPrefs.SetInt("HasOpenedBefore", 1); // Mark as opened
            PlayerPrefs.Save();
        }
    }

    public void Update()
    {
        if (firstTimeEnter && Input.GetKeyDown(KeyCode.Return))
        {
            firstTimeEnter = false;
            firstTimePopup.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
    public void StartGame()
    {
        if (isFirstTime)
        {
            firstTimeEnter = true;
            firstTimePopup.SetActive(true); 
            mainMenu.SetActive(false);
        }
        else
        {
            timer.ResetTimer();
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadLeaderBoardActive()
    {
        LeaderBoardCanvas.SetActive(true);
        LeaderBoardPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LoadLeaderBoardInActive()
    {
        LeaderBoardCanvas.SetActive(false);
        LeaderBoardPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StoreActive()
    {
        store.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StoreInActive()
    {
        store.SetActive(false);
        mainMenu.SetActive(true);
    }


}
