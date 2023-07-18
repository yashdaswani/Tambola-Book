using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class GeneratedTicketManager : MonoBehaviour
{
    public static GeneratedTicketManager Instance;
    public GameObject[] TicketPrefab;
    public GameObject[] ContentTicket;
    private int count = 1;
    public  List<int> TicketInputs = new List<int>();
    private int TotalIndividialPlayerTicket;
    public GameObject[] Rows_2;
    public GameObject[] Rows_3;
    public GameObject[] Rows_4;
    public GameObject[] Rows_5;
    public GameObject[] Rows_6;
    public string id ;
    [HideInInspector]
    public bool isTicketPrefabGenearted  = false;
    public bool[] isTicketPrefabGeneartedCont;
    public GameObject QRCodePanel;

    public TMP_Text buttonCounterText;


  //  private string text;
    private void Awake()
    {
        Instance = this;
        id = "hg";
        isTicketPrefabGeneartedCont = new bool[5];
        for (int i = 0; i < 5; i++)
        {
            isTicketPrefabGeneartedCont[i] = false;
        }
    }


   

    public void GeneratedTicketPlayer()
    {
        int index = gameObject.transform.GetSiblingIndex();
        GameObject go = gameObject.transform.parent.parent.gameObject;
        GameObject tickets = go.transform.GetChild(1).gameObject;
        GameObject ticketCont = tickets.transform.GetChild(index).gameObject;
        Debug.Log(ticketCont.transform.childCount);
        for(int i = 0;i<ticketCont.transform.childCount;i++)
        {
            GameObject ticketPrefab = Instantiate(ticketCont.transform.GetChild(i).gameObject, ContentTicket[0].transform);
            ticketPrefab.SetActive(true);
            GameObject ticketPrefabCont = ticketPrefab.transform.GetChild(1).gameObject;
            for(int j = 0;j<3;j++)
            {
                GameObject row = ticketPrefabCont.transform.GetChild(j).gameObject;
                for(int k = 0;k<9;k++)
                {
                    GameObject grid = row.transform.GetChild(k).gameObject;
                    string text = grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                    int no;
                    if (int.TryParse(text, out no))
                    {
                        TicketInputs.Add(no);
                    }
                    else
                    {
                        TicketInputs.Add(-1);
                    }
                }
            }
            for (int ik = 0; ik < TicketInputs.Count; ik++)
            {
                Debug.Log(TicketInputs[ik]);
            }
        }
        isTicketPrefabGenearted = true;
    }


   

    

    public void NumberButton()
    {
        TotalIndividialPlayerTicket = ContentTicket[0].transform.childCount;

        count++;
        if (count<7)
        {
            buttonCounterText.text = count.ToString();
            if(count==2)
            {
                ContentTicket[0].SetActive(false); 
                ContentTicket[1].SetActive(true);
                if (!isTicketPrefabGeneartedCont[0])
                TwoTicketContManager();
            }
            if (count == 3)
            {
                ContentTicket[1].SetActive(false);
                ContentTicket[2].SetActive(true);
                if (!isTicketPrefabGeneartedCont[1])
                    ThreeTicketContManager();
            }
            if (count == 4)
            {
                ContentTicket[2].SetActive(false);
                ContentTicket[3].SetActive(true);
                if (!isTicketPrefabGeneartedCont[2])
                    FourTicketContManager();
            }
            if (count == 5)
            {
                ContentTicket[3].SetActive(false);
                ContentTicket[4].SetActive(true);
                if (!isTicketPrefabGeneartedCont[3])
                    FiveTicketContManager();
            }
            if (count == 6)
            {
                ContentTicket[4].SetActive(false);
                ContentTicket[5].SetActive(true);
                if (!isTicketPrefabGeneartedCont[4])
                    SixTicketContManager();
            }
        }
        if(count > 6)
        {
            count = 1;
            buttonCounterText.text = count.ToString();
            ContentTicket[5].SetActive(false);
            ContentTicket[0].SetActive(true);
        }
    }

     public void OnButtonClick()
    {
        TotalIndividialPlayerTicket = ContentTicket[0].transform.childCount;
        count++;

        if (count > 6)
            count = 1;

        UpdateTicketContent();
    }

    private void UpdateTicketContent()
    {
        buttonCounterText.text = count.ToString();

        for (int i = 0; i < ContentTicket.Length; i++)
        {
            if (i == count - 1)
                ContentTicket[i].SetActive(true);
            else
                ContentTicket[i].SetActive(false);
        }
    }


    public void TwoTicketContManager()
    {
        int index = Rows_2.Length;
        int t = TotalIndividialPlayerTicket / 2;

        for (int i = 0; i < t; i++)
        {
            GameObject go_2 = Instantiate(TicketPrefab[1], ContentTicket[1].transform);
            GameObject COnt = go_2.transform.GetChild(1).gameObject;
            for (int j = 0; j < 2; j++)
            {
                GameObject ticketCOnt = COnt.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = ticketCOnt.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_2, index + 1);
                    Rows_2[index] = row;
                    index++;
                }
            }
        }
        

        if(TotalIndividialPlayerTicket % 2 ==1)
        {
            GameObject go_1 = Instantiate(TicketPrefab[0], ContentTicket[1].transform);
            GameObject ticketCont = go_1.transform.GetChild(1).gameObject;
            for(int j = 0;j < 3; j++)
            {
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                Array.Resize(ref Rows_2, index + 1);
                Rows_2[index] = row;
                index++;
            }
        }

        isTicketPrefabGeneartedCont[0] = true;
        int id = 0;//Also keep this at a seperate place and access by instance just like list from another common script
        foreach (var row in Rows_2)
        {
            for (int j = 0; j < row.transform.childCount; j++)
            {
                if (TicketInputs[id] == -1)
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                }
               
                id++;

            }
        }
    }


    public void ThreeTicketContManager()
    {
        int index = Rows_3.Length;
        int t = TotalIndividialPlayerTicket / 3;

        for (int i = 0; i < t; i++)
        {
            GameObject go_3 = Instantiate(TicketPrefab[2], ContentTicket[2].transform);
            GameObject COnt = go_3.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                GameObject ticketCOnt = COnt.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = ticketCOnt.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_3, index + 1);
                    Rows_3[index] = row;
                    index++;
                }
            }
        }


        if (TotalIndividialPlayerTicket % 3 == 1)
        {
            GameObject go_3 = Instantiate(TicketPrefab[0], ContentTicket[2].transform);
            GameObject ticketCont = go_3.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                Array.Resize(ref Rows_3, index + 1);
                Rows_3[index] = row;
                index++;
            }

        }
        if (TotalIndividialPlayerTicket % 3 == 2)
        {
            GameObject go_3 = Instantiate(TicketPrefab[1], ContentTicket[2].transform);
            GameObject Cont = go_3.transform.GetChild(1).gameObject;
            for (int j = 0; j < 2; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_3, index + 1);
                    Rows_3[index] = row;
                    index++;
                }
                
            }

        }
        isTicketPrefabGeneartedCont[1] = true;
        int id = 0;//Also keep this at a seperate place and access by instance just like list from another common script
        foreach (var row in Rows_3)
        {
            for (int j = 0; j < row.transform.childCount; j++)
            {
                if (TicketInputs[id] == -1)
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                }

                id++;

            }
        }
    } 
    
    public void FourTicketContManager()
    {
        int index = Rows_4.Length;
        int t = TotalIndividialPlayerTicket / 4;

        for (int i = 0; i < t; i++)
        {
            GameObject go_4 = Instantiate(TicketPrefab[3], ContentTicket[3].transform);
            GameObject COnt = go_4.transform.GetChild(1).gameObject;
            for (int j = 0; j < 4; j++)
            {
                GameObject ticketCOnt = COnt.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = ticketCOnt.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_4, index + 1);
                    Rows_4[index] = row;
                    index++;
                }
            }
        }


        if (TotalIndividialPlayerTicket % 4 == 1)
        {
           // Debug.Log("1");
            GameObject go_4 = Instantiate(TicketPrefab[0], ContentTicket[3].transform);
           // Debug.Log("2");
            GameObject ticketCont = go_4.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
               // Debug.Log("3");
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                Array.Resize(ref Rows_4, index + 1);
                Rows_4[index] = row;
                index++;
            }

        }
        if (TotalIndividialPlayerTicket % 4 == 2)
        {
            GameObject go_4 = Instantiate(TicketPrefab[1], ContentTicket[3].transform);
            GameObject Cont = go_4.transform.GetChild(1).gameObject;
            for (int j = 0; j < 2; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_4, index + 1);
                    Rows_4[index] = row;
                    index++;
                }
                
            }

        }

        if (TotalIndividialPlayerTicket % 4 == 3)
        {
            GameObject go_4 = Instantiate(TicketPrefab[2], ContentTicket[3].transform);
            GameObject Cont = go_4.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_4, index + 1);
                    Rows_4[index] = row;
                    index++;
                }

            }

        }
        isTicketPrefabGeneartedCont[2] = true;
        int id = 0;//Also keep this at a seperate place and access by instance just like list from another common script
        foreach (var row in Rows_4)
        {
            for (int j = 0; j < row.transform.childCount; j++)
            {
                if (TicketInputs[id] == -1)
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                }

                id++;

            }
        }
    }

    public void FiveTicketContManager()
    {
        int index = Rows_5.Length;
        int t = TotalIndividialPlayerTicket / 5;

        for (int i = 0; i < t; i++)
        {
            GameObject go_5 = Instantiate(TicketPrefab[4], ContentTicket[4].transform);
            GameObject COnt = go_5.transform.GetChild(1).gameObject;
            for (int j = 0; j < 5; j++)
            {
                GameObject ticketCOnt = COnt.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = ticketCOnt.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_5, index + 1);
                    Rows_5[index] = row;
                    index++;
                }
            }
        }


        if (TotalIndividialPlayerTicket % 5 == 1)
        {
            // Debug.Log("1");
            GameObject go_5 = Instantiate(TicketPrefab[0], ContentTicket[4].transform);
            // Debug.Log("2");
            GameObject ticketCont = go_5.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                // Debug.Log("3");
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                Array.Resize(ref Rows_5, index + 1);
                Rows_5[index] = row;
                index++;
            }

        }


        if (TotalIndividialPlayerTicket % 5 == 2)
        {
            GameObject go_5 = Instantiate(TicketPrefab[1], ContentTicket[4].transform);
            GameObject Cont = go_5.transform.GetChild(1).gameObject;
            for (int j = 0; j < 2; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_5, index + 1);
                    Rows_5[index] = row;
                    index++;
                }

            }

        }

        if (TotalIndividialPlayerTicket % 5 == 3)
        {
            GameObject go_5 = Instantiate(TicketPrefab[2], ContentTicket[4].transform);
            GameObject Cont = go_5.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_5, index + 1);
                    Rows_5[index] = row;
                    index++;
                }

            }

        }

        if (TotalIndividialPlayerTicket % 5 == 4)
        {
            GameObject go_5 = Instantiate(TicketPrefab[3], ContentTicket[4].transform);
            GameObject Cont = go_5.transform.GetChild(1).gameObject;
            for (int j = 0; j < 4; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_5, index + 1);
                    Rows_5[index] = row;
                    index++;
                }

            }

        }

        isTicketPrefabGeneartedCont[3] = true;
        int id = 0;//Also keep this at a seperate place and access by instance just like list from another common script
        foreach (var row in Rows_5)
        {
            for (int j = 0; j < row.transform.childCount; j++)
            {
                if (TicketInputs[id] == -1)
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                }

                id++;

            }
        }
    }

    public void SixTicketContManager()
    {
        int index = Rows_6.Length;
        int t = TotalIndividialPlayerTicket / 6;

        for (int i = 0; i < t; i++)
        {
            GameObject go_6 = Instantiate(TicketPrefab[5], ContentTicket[5].transform);
            GameObject COnt = go_6.transform.GetChild(1).gameObject;
            for (int j = 0; j < 6; j++)
            {
                GameObject ticketCOnt = COnt.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = ticketCOnt.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_6, index + 1);
                    Rows_6[index] = row;
                    index++;
                }
            }
        }

        if (TotalIndividialPlayerTicket % 6 == 1)
        {
            // Debug.Log("1");
            GameObject go_6 = Instantiate(TicketPrefab[0], ContentTicket[5].transform);
            // Debug.Log("2");
            GameObject ticketCont = go_6.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                // Debug.Log("3");
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                Array.Resize(ref Rows_6, index + 1);
                Rows_6[index] = row;
                index++;
            }

        }

        if (TotalIndividialPlayerTicket % 6 == 2)
        {
            GameObject go_6 = Instantiate(TicketPrefab[1], ContentTicket[5].transform);
            GameObject Cont = go_6.transform.GetChild(1).gameObject;
            for (int j = 0; j < 2; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_6, index + 1);
                    Rows_6[index] = row;
                    index++;
                }

            }

        }

        if (TotalIndividialPlayerTicket % 6 == 3)
        {
            GameObject go_6 = Instantiate(TicketPrefab[2], ContentTicket[5].transform);
            GameObject Cont = go_6.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_6, index + 1);
                    Rows_6[index] = row;
                    index++;
                }

            }

        }

        if (TotalIndividialPlayerTicket % 6 == 4)
        {
            GameObject go_6 = Instantiate(TicketPrefab[3], ContentTicket[5].transform);
            GameObject Cont = go_6.transform.GetChild(1).gameObject;
            for (int j = 0; j < 4; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_6, index + 1);
                    Rows_6[index] = row;
                    index++;
                }

            }

        }

        if (TotalIndividialPlayerTicket % 6 == 5)
        {
            GameObject go_6 = Instantiate(TicketPrefab[4], ContentTicket[5].transform);
            GameObject Cont = go_6.transform.GetChild(1).gameObject;
            for (int j = 0; j < 5; j++)
            {
                GameObject tickCont = Cont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 3; k++)
                {
                    GameObject row = tickCont.transform.GetChild(k).gameObject;
                    Array.Resize(ref Rows_6, index + 1);
                    Rows_6[index] = row;
                    index++;
                }

            }

        }
        isTicketPrefabGeneartedCont[4] = true;
        int id = 0;//Also keep this at a seperate place and access by instance just like list from another common script
        foreach (var row in Rows_6)
        {
            for (int j = 0; j < row.transform.childCount; j++)
            {
                if (TicketInputs[id] == -1)
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    row.transform.GetChild(j).GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                }

                id++;

            }
        }
    }

    public void QRPanel()
    {
        QRCodePanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBackButton();
        }
    }

    void HandleBackButton()
    {
        // Check if the panel is active before closing it
        if (QRCodePanel != null && QRCodePanel.activeSelf)
        {
            QRCodePanel.SetActive(false);
        }
    }

}
