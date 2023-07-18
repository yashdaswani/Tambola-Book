using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateTicket : MonoBehaviour
{
    public static GenerateTicket instance;
    public List<int> s = new List<int>();
    private int TotalIndividialPlayerTicket;
    public GameObject TicketPrefab;
    [HideInInspector]
    public bool isTicketPrefabGenearted = false;
    public GameObject tickets;
    public GameObject content;
    public GameObject PlayerPrefab;
    public static int count = 1;

    private void Awake()
    {

        instance = this;
    }

    private void Start()
    {
        InstantiateTicket();
    }


    public void InstantiateTicket()
    {
        
        GameObject contentClone = content.transform.GetChild(0).gameObject;
        int players = contentClone.transform.childCount - 1;
        for (int i = 0; i < players; i++)
        {
            GameObject player = Instantiate(PlayerPrefab, tickets.transform);
            player.name = i.ToString();
            int ticket = int.Parse(contentClone.transform.GetChild(i + 1).GetChild(2).GetComponent<TextMeshProUGUI>().text);
            Debug.Log(ticket);
            for (int t = 0; t < ticket; t++)
            {
                GameObject go = Instantiate(TicketPrefab, player.transform);
                string name = contentClone.transform.GetChild(i + 1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
                string extractname = name.Substring(name.IndexOf(" ") + 1);
                go.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = extractname + " - " + count.ToString();
                count++;
            }
                GenerateTicketNumbers.instance.AssignTickets();

            for (int t = 0; t < ticket; t++)
            {
                GameObject go = tickets.transform.GetChild(i).GetChild(t).gameObject;

                GameObject ticketCont = go.transform.GetChild(1).gameObject;


                for (int j = 0; j < 3; j++)
                {
                    GameObject row = ticketCont.transform.GetChild(j).gameObject;
                    for (int k = 0; k < 9; k++)
                    {
                        GameObject grid = row.transform.GetChild(k).gameObject;
                        string text = grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                        int no;
                        if (int.TryParse(text, out no))
                        {
                            s.Add(no);
                        }
                        else
                        {
                            s.Add(-1);
                        }

                    }
                }


                
            
            }
        }


    }

    public void InstantiateForAfterGeneratedTicket()
    {
        GameObject player = Instantiate(PlayerPrefab, tickets.transform);
        int i = tickets.transform.childCount - 1;
        player.name = i.ToString();
        int ticket = int.Parse(GameManager.Instance.EnterPlayerTicketsPanelAfterGenerateing.text);
        for (int t = 0; t < ticket; t++)
        {
            GameObject go = Instantiate(TicketPrefab, player.transform);
            string name = GameManager.Instance.EnterPlayerNamePanelAfterGenerateing.text;
            go.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = name + " - " + count.ToString();
            count++;
        }
        GenerateTicketNumbers.instance.AssignTickets();
        for (int t = 0; t < ticket; t++)
        {
            GameObject go = tickets.transform.GetChild(i).GetChild(t).gameObject;

            GameObject ticketCont = go.transform.GetChild(1).gameObject;


            for (int j = 0; j < 3; j++)
            {
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                for (int k = 0; k < 9; k++)
                {
                    GameObject grid = row.transform.GetChild(k).gameObject;
                    string text = grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                    int no;
                    if (int.TryParse(text, out no))
                    {
                        s.Add(no);
                    }
                    else
                    {
                        s.Add(-1);
                    }

                }
            }

        }
    }


    //public void GeneratedTicketPlayer()
    //{
    //    TotalIndividialPlayerTicket = GameManager.;
    //    Debug.Log("dds");
    //    for (int i = 0; i < TotalIndividialPlayerTicket; i++)
    //    {
    //        Debug.Log("d");
    //        GameObject go = Instantiate(TicketPrefab,Content.transform);
    //        GameObject ticketCont = go.transform.GetChild(1).gameObject;


    //        for (int j = 0; j < 3; j++)
    //        {
    //            GameObject row = ticketCont.transform.GetChild(j).gameObject;
    //            for (int k = 0; k < 9; k++)
    //            {
    //                GameObject grid = row.transform.GetChild(k).gameObject;
    //                string text = grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
    //                int no;
    //                if (int.TryParse(text, out no))
    //                {
    //                    s.Add(no);
    //                }
    //                else
    //                {
    //                    s.Add(-1);
    //                }

    //            }
    //        }


    //        for (int ik = 0; ik < s.Count; ik++)
    //        {
    //            Debug.Log(s[ik]);
    //        }
    //        string extractedName = PlayerManager.instance.Playername.Substring(PlayerManager.instance.Playername.IndexOf(" ") + 1);
    //        go.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = extractedName + " - " + PlayerManager.instance.player_id + " - " + Group.ticketnumber;
    //        Debug.Log(Group.ticketnumber);
    //        Group.ticketnumber++;
    //    }
    //}
}
