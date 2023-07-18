using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Sockets;

public class SearchTicket : MonoBehaviour
{
    public  TMP_InputField searchInputField;
    public GameObject ContentSearch;
    public GameObject Tickets;
    public List<GameObject> ticketList = new List<GameObject>();
    public List<string> SummaryList = new List<string>();



    public static SearchTicket instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        // Attach a listener to the input field's OnEndEdit event
        searchInputField.onEndEdit.AddListener(SearchTickets);
        AssignTicket();
        
    }


    private void Update()
    {
        TicketVerificationMethod();
    }

    public void AssignTicket()
    {

        for (int i = 0; i < Tickets.transform.childCount; i++)
        {
            GameObject TicketCont = Tickets.transform.GetChild(i).gameObject;

            for (int j = 0; j < TicketCont.transform.childCount; j++)
            {
                GameObject ticket = TicketCont.transform.GetChild(j).gameObject;
                GameObject go = Instantiate(ticket, ContentSearch.transform);
                RectTransform rectTransform = go.gameObject.GetComponent<RectTransform>();
                Vector2 newSizeDelta = rectTransform.sizeDelta;
                newSizeDelta.x = 625; // Set the desired width
                rectTransform.sizeDelta = newSizeDelta;
                GameObject ticketCont = go.transform.GetChild(1).gameObject;
                RectTransform rectTransform1 = ticketCont.gameObject.GetComponent<RectTransform>();
                Vector2 newSizeDelta1 = rectTransform1.sizeDelta;
                newSizeDelta1.x = 600; // Set the desired width
                rectTransform1.sizeDelta = newSizeDelta1;

                go.SetActive(true);
                ticketList.Add(go);
            }

        }

    }


    public void assign()
    {
        for (int i = 0; i < Tickets.transform.childCount; i++)
        {
            GameObject TicketCont = Tickets.transform.GetChild(i).gameObject;
            //GameObject go = Instantiate(ticket, ContentSearch.transform);
        }
    }



        private void SearchTickets(string searchText)
    {
        searchText = searchText.ToLower(); // Convert search text to lowercase for case-insensitive comparison

        foreach (GameObject ticket in ticketList)
        {
            TMP_Text ticketText = ticket.transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_Text>();

            // Check if the ticket's text contains the search text
            bool isMatch = ticketText.text.ToLower().Contains(searchText);

            // Set the ticket's visibility based on the search result
            ticket.SetActive(isMatch);
        }
    }

    public void MarkNumberonTickets(int number)
    {
       

       for (int t =0;t<ContentSearch.transform.childCount;t++) 
        {
            GameObject ticket = ContentSearch.transform.GetChild(t).gameObject;
            GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
            for(int i = 0; i < 3; i++)
            {
                GameObject row = ticketCont.transform.GetChild(i).gameObject;
                for(int j = 0; j < 9; j++)
                {
                    GameObject grid = row.transform.GetChild(j).gameObject;
                    string n = grid.transform.GetComponentInChildren<TextMeshProUGUI>().text;
                    int no;
                    if (int.TryParse(n, out no))
                    {
                        if(no == number)
                        {
                            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                            UnityEngine.UI.Image gridImage = grid.GetComponent<UnityEngine.UI.Image>();

                            gridImage.color = Color.red;
                        }   
                    }
                    
                }
            }
        }
    }

    public void TicketVerificationMethod()
    {
        foreach (GameObject ticket in ticketList)
        {
            TicketVerification.instance.TicketDividendVerificationMethod(ticket);
        }


        for (int i = 0; i < Tickets.transform.childCount; i++)
        {
            GameObject TicketCont = Tickets.transform.GetChild(i).gameObject;
            //int n = TicketCont.transform.childCount;
            //if(VerifyUI.instance.currentToggleIndex==1)
            //{
            //    int t = n / 2;
            //    for(int j = 0; j < t; j++)
            //    {
            //        GameObject t1;
            //        TicketCont.transform.GetChild(i)

            //    }
            //}
            TicketVerification.instance.TicketSetwiseVerificationMethod(TicketCont);
        }

    }


    public void MarkedTicket(int number)
    {
        for (int t = 0; t < Tickets.transform.childCount; t++)
        {
            GameObject TicketCont = Tickets.transform.GetChild(t).gameObject;
            for (int i = 0; i < TicketCont.transform.childCount; i++)
            {
                GameObject ticketPrefab = TicketCont.transform.GetChild(i).gameObject;
                GameObject ticketPrefabCont = ticketPrefab.transform.GetChild(1).gameObject;
                for (int j = 0; j < 3; j++)
                {
                    GameObject row = ticketPrefabCont.transform.GetChild(j).gameObject;
                    for (int k = 0; k < 9; k++)
                    {
                        GameObject grid = row.transform.GetChild(k).gameObject;
                        string n = grid.transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int no;
                        if (int.TryParse(n, out no))
                        {
                            if (no == number)
                            {
                                grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                                UnityEngine.UI.Image gridImage = grid.GetComponent<UnityEngine.UI.Image>();

                                gridImage.color = Color.red;
                            }
                        }

                    }

                }
            }
        }
    }


}
