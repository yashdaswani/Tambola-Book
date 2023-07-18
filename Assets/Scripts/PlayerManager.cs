using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int player_id;
    public string Playername;
    public int PlayerTicket;
    public GameObject EditPanel;
    public TMP_Text EditPanelTicketNumberText;
    private int TicketAllowted;
    private int EditPanelTicketNumber;
    public GameObject EditButton;
    public static PlayerManager instance;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
         player_id = GeneratePlayerID();
        Debug.Log("Player ID: " + player_id);
        TicketAllowted = int.Parse(gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
        EditPanelTicketNumber = TicketAllowted;
    }


    private int GeneratePlayerID()
    {
        int minID = 1000; // Minimum 4-digit number
        int maxID = 9999; // Maximum 4-digit number

        return Random.Range(minID, maxID + 1);
    }

    public void IncrementTicketByOnePlayer()
    {
        
        if (EditPanelTicketNumber < 7)
        {
            EditPanelTicketNumber = EditPanelTicketNumber + 1 ;
            EditPanelTicketNumberText.text = EditPanelTicketNumber.ToString();
            //gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Ticketallowted.ToString();
            
        }
    }

    public void DecrementTicketByOnePlayer()
    {
        
        if (EditPanelTicketNumber > 0)
        {
            EditPanelTicketNumber--;
            EditPanelTicketNumberText.text = EditPanelTicketNumber.ToString();
            //gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Ticketallowted.ToString();
            
        }
    }

    public void EditBTNplayer()
    {
        EditPanel.SetActive(true);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        // Get the current sizeDelta
        Vector2 sizeDelta = rectTransform.sizeDelta;

        // Set the new height while preserving the original width
        sizeDelta.y = 250;

        // Assign the modified sizeDelta back to the RectTransform
        rectTransform.sizeDelta = sizeDelta;
        EditButton.SetActive(false);

    }

    public void MakeChangesPlayer()
    {
        gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = EditPanelTicketNumber.ToString();
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        // Get the current sizeDelta
        Vector2 sizeDelta = rectTransform.sizeDelta;

        // Set the new height while preserving the original width
        sizeDelta.y = 150;

        // Assign the modified sizeDelta back to the RectTransform
        rectTransform.sizeDelta = sizeDelta;
        EditPanel.SetActive(false);
        EditButton.SetActive(true);
    }


    public void OnClickPlayerPrefab()
    {
        if(GameManager.Instance.iSTicketGenerated)
        {
            int childindex = transform.GetSiblingIndex();
            Debug.Log(childindex);
            GenerateTicketPanel.instance.MakeActivePanel(childindex-1);
            Playername = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            PlayerTicket = int.Parse(gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
            if (!GeneratedTicketManager.Instance.isTicketPrefabGenearted)
            {
                GeneratedTicketManager.Instance.GeneratedTicketPlayer();
            }
            
        }
        else
        {
            GameManager.Instance.NotTicketGeneratedPanel.SetActive(true);
        }
    }


    public void OkButtonNotGeneratedTicket()
    {
        GameManager.Instance.NotTicketGeneratedPanel.SetActive(false);
    } 
    
    public void ScreenshotGeneratedTicket()
    {

    }
    
    public void ShareViaLink()
    {

    }
    
    public void QRLink()
    {

    }



}
