using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Personal;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject AddGroupPanel;
    public GameObject EnterGameNamePanel;
    public GameObject AddPlayerPanel;
    public GameObject GroupPrefab;
    public TMP_InputField GroupNameInputField;
    public GameObject EnterPlayerNamePanel;
    public TMP_InputField PlayerNameInputField;
    private string groupname;
    private string Playername;
    public GameObject ContentGroup;
    public GameObject ContentPlayer;
    public GameObject ContentPlayerGeneratedTickets;
    public GameObject PlayerPrefab;
    public GameObject GroupDetails;
    public TMP_Text TicketnumberText ;
    private int Ticketnumber ;
    public TMP_Text noofPlayerText;
    public TMP_Text noofTicketText;
    public int TotalNumberOFPlayer;
    public GameObject GeneratedTicketPanel;
    public GameObject StartGamePanel;
    public GameObject EnterPlayerNameTicketPanel;
    public TMP_InputField EnterPlayerNamePanelAfterGenerateing;
    public TMP_InputField EnterPlayerTicketsPanelAfterGenerateing;

    public GameObject GenerateTicketBtn;

    public bool iSTicketGenerated = false;
    public GameObject GoContentPlayerGeneratedTickets;

    private int TotalNumberOfTicket;
    private int ticketcounter = 0;
    public GameObject TicketGeneratedPanel;
    public GameObject NotTicketGeneratedPanel;


    [Header("Panels")]
    public GameObject UpgradePanel;
    public GameObject VerifyPanel;
    public GameObject ThemePanel;
    public GameObject DeleteConfirmPanel;

    public GameObject GameVerifyPanel;
    public GameObject DeleteAllPlayerButton;
    public GameObject BTNCONTPLAYER;

    [Header("VerifyPanels")]
    public GameObject TicketPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        TotalNumbersofTickets();
        UpdateTotalNumberOFPlayer();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBackButton();
        }

        if (iSTicketGenerated)
        {

       // UpdateTicketsinGeneratePanel();
        }
    }


    public void NewGameBTN()
    {
        EnterGameNamePanel.SetActive(true);
    }


    public void CreateGroupBTN()
    {
        groupname = GroupNameInputField.text;
        Personal.ValuesSaver.AllGroupsUI group = new ValuesSaver.AllGroupsUI();
        group.GroupName = groupname;

        InstatiateGroupPrefab();
        EnterGameNamePanel.SetActive(false);
        AddGroupPanel.SetActive(true);
        AddPlayerPanel.SetActive(true);
        GroupDetails.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = groupname;
       // GroupDetails.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = groupname;
        GroupNameInputField.text = "";
       // ValuesSaver.Instance.AllGroups.Add(group);
    }

    public void ExitGroupButton()
    {
        AddGroupPanel.SetActive(false);
        EnterGameNamePanel.SetActive(false);
    }


    public void InstatiateGroupPrefab()
    {
        GameObject go = Instantiate(GroupPrefab,ContentGroup.transform);
        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = groupname;
        
    } 
    
    public void InstatiatePlayerPrefab()
    {
        GameObject go = Instantiate(PlayerPrefab,ContentPlayer.transform);
        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = TotalNumberOFPlayer+1 + ". " + Playername;
        go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Ticketnumber.ToString();
        TotalNumberOFPlayer++;
    }


    public void CloseAddPlayerPanel()
    {
        AddPlayerPanel.SetActive(false );
        AddGroupPanel.SetActive(true );
    }

    public void AddPLayerBTN()
    {
        EnterPlayerNamePanel.SetActive(true);
    }


    public void CreatePlayerBTN()
    {
        Playername = PlayerNameInputField.text;
        InstatiatePlayerPrefab();
        EnterPlayerNamePanel.SetActive(false);
        PlayerNameInputField.text = "";
    }

    public void ExitPlayerBtn()
    {
        EnterPlayerNamePanel.SetActive(false);
    }

   
    public void UpdateTotalNumberOFPlayer()
    {
        if(TotalNumberOFPlayer==0)
        {
            DeleteAllPlayerButton.SetActive(false );
            BTNCONTPLAYER.GetComponent<HorizontalLayoutGroup>().spacing = -77;
            GenerateTicketBtn.SetActive(false);

        }
        else
        {
            BTNCONTPLAYER.GetComponent<HorizontalLayoutGroup>().spacing = 15;
            DeleteAllPlayerButton.SetActive(true );
            GenerateTicketBtn.SetActive(true);
        }
        TotalNumberOFPlayer = ContentPlayer.transform.childCount-1;
        noofPlayerText.text = TotalNumberOFPlayer.ToString() + " Players";
    }
   


    public void IncrementTicketByOneGroup()
    {
        Ticketnumber = int.Parse(TicketnumberText.text);
        if(Ticketnumber < 7) {
        Ticketnumber++;
            TicketnumberText.text = Ticketnumber.ToString();
            //noofTicketText.text = Ticketnumber.ToString() + " Tickets";
        }
    }
    
    public void DecrementTicketByOneGroup()
    {
        Ticketnumber = int.Parse(TicketnumberText.text);
        if (Ticketnumber > 0 )
        {
            Ticketnumber--;
            TicketnumberText.text = Ticketnumber.ToString();
            //noofTicketText.text = Ticketnumber.ToString() + " Tickets";
        }
    }




    public void TotalNumbersofTickets()
    {
        int count = ContentPlayer.transform.childCount;
        int number=0;
        for (int i =1;i<count;i++)
        {
            number = number +  int.Parse(ContentPlayer.transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text);
        }
        TotalNumberOfTicket = number;
        noofTicketText.text=number.ToString() + " Tickets";
    }

    public void DeleteAllPlayer()
    {
        DeleteConfirmPanel.SetActive(true);
     }


    public void DeleteAllPlayerNO()
    {
        DeleteConfirmPanel.SetActive(false);
    }

    public void DeleteAllPlayerCOnfirm()
    {
        for (int i = 1; i < ContentPlayer.transform.childCount; i++)
        {
            GameObject Player = ContentPlayer.transform.GetChild(i).gameObject;
            Destroy(Player);
        }
        DeleteConfirmPanel.SetActive(false);
    }





    public void GenerateTicketBTN()
    {
        if (!iSTicketGenerated)
        {
            GeneratedTicketPanel.SetActive(true);

            GoContentPlayerGeneratedTickets = Instantiate(ContentPlayer, ContentPlayerGeneratedTickets.transform);

            GoContentPlayerGeneratedTickets.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            GoContentPlayerGeneratedTickets.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);

            UpdateTicketsinGeneratePanel();
            //AddPlayerPanel.SetActive(true );
            iSTicketGenerated = true;
        }
        GeneratedTicketPanel.SetActive(true);
            iSTicketGenerated = true;
    }

    public void UpdateTicketsinGeneratePanel()
    {
        int lowervalue = 0;
        int uppervalue = 0;
        for (int i = 1; i < GoContentPlayerGeneratedTickets.transform.childCount; i++)
        {
            Debug.Log(GoContentPlayerGeneratedTickets.name);
            string ticketno = GoContentPlayerGeneratedTickets.transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text;
            Debug.Log("ticketno" + ticketno);
            Debug.Log("ticketcounter" + ticketcounter);
             lowervalue = uppervalue + 1;
            Debug.Log(lowervalue);
             uppervalue = int.Parse(ticketno) + lowervalue - 1;
            ticketcounter = uppervalue;
            GoContentPlayerGeneratedTickets.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = ticketno + " Tickets" + " ( " + lowervalue + " - " + uppervalue + " ) ";
            GoContentPlayerGeneratedTickets.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.green;
        }
    }


    public void StartGameBTN()
    {
        StartGamePanel.SetActive(true);
    }

    public void AddPlayerAfterGeneratingTicketBtn()
    {
        EnterPlayerNameTicketPanel.SetActive(true);
    }


    public void CreatePlayerAfterGeneratingTicketBtn()
    {
        string ticketinputField = EnterPlayerTicketsPanelAfterGenerateing.text;
        string nameInputField = EnterPlayerNamePanelAfterGenerateing.text;
        GameObject go = Instantiate(PlayerPrefab, ContentPlayerGeneratedTickets.transform.GetChild(0).transform);
        int c = ContentPlayerGeneratedTickets.transform.GetChild(0).transform.childCount - 1;
        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = c + ". " + nameInputField;
        go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ticketinputField;
        UpdateTicketsinGeneratePanel();

        EnterPlayerNameTicketPanel.SetActive(false);
        GenerateTicket.instance.InstantiateForAfterGeneratedTicket();
        GenerateTicketPanel.instance.GeneratePanelAFteraddingPlayer();
    }

    public void ExitCreatePlayerAfterGeneratingTicketBtn()
    {
        EnterPlayerNameTicketPanel.SetActive(false);
    }

    public void OpenUpdradePanel()
    {
        UpgradePanel.SetActive(true);
    }

    public void Openverifypanel()
    {
        VerifyPanel.SetActive(true);
    }
    public void OpenGameverifypanel()
    {
        GameVerifyPanel.SetActive(true);
        if (BoardManager.Instance.claimNotification.gameObject.activeSelf)
        {
            BoardManager.Instance.claimNotification.gameObject.SetActive(false);
        }

    }

    public void OpenThemepanel()
    {
        ThemePanel.SetActive(true);
    }

    public void OkERRORPanel()
    {
        NotTicketGeneratedPanel.SetActive(false);
    }

    void HandleBackButton()
    {
        //if (AddPlayerPanel != null && AddPlayerPanel.activeSelf)
        //{
        //    AddPlayerPanel.SetActive(false);
        //}

        // Check if the panel is active before closing it
        if (UpgradePanel != null && UpgradePanel.activeSelf)
        {
            UpgradePanel.SetActive(false);
        }

        if (VerifyPanel != null && VerifyPanel.activeSelf)
        {
            VerifyPanel.SetActive(false);
        }
        
        if (ThemePanel != null && ThemePanel.activeSelf)
        {
            //ThemePanel.SetActive(false);
        }
        if (TicketGeneratedPanel != null && TicketGeneratedPanel.activeSelf)
        {
            TicketGeneratedPanel.SetActive(false);
        }
        //if (GeneratedTicketPanel != null && GeneratedTicketPanel.activeSelf && !IsAnyGeneratedpanelIsActive())
        //{
        //    GeneratedTicketPanel.SetActive(false);
        //}



    }

    public void BackTicketPanel()
    {
        TicketPanel.SetActive(false);
    }

    public bool IsAnyGeneratedpanelIsActive()
    {
        GameObject GeneratePanel = GeneratedTicketPanel.transform.GetChild(2).gameObject;
        for(int i=0;i<GeneratePanel.transform.childCount;i++)
        {
            GameObject GeneratePanelChild = GeneratePanel.transform.GetChild(i).gameObject;
            if (GeneratePanelChild.activeSelf)
            {
                return true;
            }
                
        }
        return false;
    }


}
