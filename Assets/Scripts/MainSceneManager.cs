using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{

    public GameObject HowToPlayePanel;
    public GameObject DividendPanel;
    public GameObject MainPanel;
    public GameObject ReadmePanel;
    public GameObject JoinPanel;

    
    
    public void OpenHowToPlayPanel()
    {
        HowToPlayePanel.SetActive(true);
        MainPanel.SetActive(false);
        DividendPanel.SetActive(false);
        ReadmePanel.SetActive(false);
    }
    
    public void OpenDividendPanel()
    {
        DividendPanel.SetActive(true);
        MainPanel.SetActive(false);
        ReadmePanel.SetActive(false );
        HowToPlayePanel.SetActive(false);
    }
    public void OpenReadMePanel()
    {
        DividendPanel.SetActive(false);
        MainPanel.SetActive(false);
        ReadmePanel.SetActive(true );
        HowToPlayePanel.SetActive(false);
    }

    void HandleBackButton()
    {
        // Check if the panel is active before closing it
        if (HowToPlayePanel != null && HowToPlayePanel.activeSelf)
        {
            HowToPlayePanel.SetActive(false);
            MainPanel.SetActive(true);
        }
        
        if (DividendPanel != null && DividendPanel.activeSelf)
        {
            DividendPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
        if (ReadmePanel != null && ReadmePanel.activeSelf)
        {
            ReadmePanel.SetActive(false);
            MainPanel.SetActive(true);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBackButton();
        }
    }


    public void HostGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitJoinGame()
    {
        JoinPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    
    public void JoinGame()
    {
        JoinPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

   
}
