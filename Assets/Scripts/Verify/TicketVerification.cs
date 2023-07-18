using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TicketVerification : MonoBehaviour
{
    public static TicketVerification instance;
    public GameObject Tickets;
    public List<GameObject> s = new List<GameObject>();
    public List<GameObject> s_6 = new List<GameObject>();
    public List<GameObject> Grid = new List<GameObject>();
    public List<GameObject> Grid_6 = new List<GameObject>();
    public GameObject VerifyTicketPrefab;
    public GameObject ContentVerify;
    public GameObject DividendPrizes;
    public GameObject PendingDividend;
    public GameObject ContentSummary;
    private List<string> SummaryList = new List<string>(); 
    public List<int> TicketInputs = new List<int>();

    public GameObject VerifyPanel; 
    public GameObject SummaryPanel;
    public GameObject SearchPanel;

    public GameObject[] TicketContPrefabs;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AddSummaryTOList();
    }

    public void TicketDividendVerificationMethod(GameObject TicketPrefab)
    {
        s.Clear();
        GameObject TicketCont = TicketPrefab.transform.GetChild(1).gameObject;
        for(int i = 0; i < 3;i++)
        {
            GameObject row = TicketCont.transform.GetChild(i).gameObject;
            for(int j = 0;j < 9;j++)
            {
                GameObject grid = row.transform.GetChild(j).gameObject;
                if (grid.transform.GetComponentInChildren<TextMeshProUGUI>().text != "")
                {
                    s.Add(grid);
                }
            }
        }
        Grid.Clear();
        for (int i = 0; i < 3; i++)
        {
            GameObject row = TicketCont.transform.GetChild(i).gameObject;
            for (int j = 0; j < 9; j++)
            {
                GameObject grid = row.transform.GetChild(j).gameObject;
                Grid.Add(grid);
                
            }
        }
        for (int t = 0; t < SummaryList.Count; t++)
        {
            string desc = SummaryList[t];
            switch (desc)
            { 
                case "4 Corners":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "King Corners":
                    if (CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Queen Corners":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[10]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "4 Corner and Center":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Bulls Eyes":
                    if (CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[13]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Twin Lines":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "6 Corners":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "6 Corners and Center":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Reverse Twin":
                    if (CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[13]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Early 5/Jaldi 5":
                    int count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if(CheckMarkedGrid(grid))
                            {
                                count++;
                                if(count==5)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab,desc);
                                }
                            }
                        }
                    }
                     break;
                case "Early 6/Jaldi 6":
                     count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 6)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 7/Jaldi 7":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 7)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 8/Jaldi 8":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 8)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 9/Jaldi 9":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 9)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 10/Jaldi 10":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 10)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 11/Jaldi 11":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 11)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 12/Jaldi 12":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 12)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 13/Jaldi 13":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 13)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Early 14/Jaldi 14":
                    count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (CheckMarkedGrid(grid))
                            {
                                count++;
                                if (count == 14)
                                {
                                    SummaryList.Remove(desc);
                                    RemoveGameObjectFromPendingList(desc);
                                    InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                                }
                            }
                        }
                    }
                    break;
                case "Breakfast":
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 3; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if(CheckMarkedGrid(grid))
                            {
                               
                            }
                        }
                    }
                      break;
                case "Day || Jawani":
                    bool allNumbersMarked = true;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int n = int.Parse(text);
                        if (n <= 45 && !CheckMarkedGrid(s[i]))
                        {
                            allNumbersMarked = false;
                            break;
                        }
                    }

                    if (allNumbersMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Night || Budhapa":
                    allNumbersMarked = true;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int n = int.Parse(text);
                        if (n >= 46 && n <= 90 && !CheckMarkedGrid(s[i]))
                        {
                            allNumbersMarked = false;
                            break;
                        }
                    }

                    if (allNumbersMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Center Laddu":
                    if (CheckMarkedGrid(s[7]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Bamboo":
                    if (CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Safe":
                    if (CheckEmptymarked(Grid[11]) && CheckEmptymarked(Grid[12]) && CheckEmptymarked(Grid[13]) && CheckEmptymarked(Grid[14]) && CheckEmptymarked(Grid[15]) && CheckEmptymarked(Grid[16]) && CheckEmptymarked(Grid[17]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Fence":
                    bool allNumbersOnBoundaryMarked = true;

                    // Check top row
                    for (int j = 0; j < 9; j++)
                    {
                        if (!CheckMarkedGrid(Grid[j]))
                        {
                            allNumbersOnBoundaryMarked = false;
                            break;
                        }
                    }

                    // Check bottom row
                    for (int j = 9; j < 18; j++)
                    {
                        if (!CheckMarkedGrid(Grid[j]))
                        {
                            allNumbersOnBoundaryMarked = false;
                            break;
                        }
                    }

                    // Check left and right columns
                    for (int i = 1; i < 3; i++)
                    {
                        if (!CheckMarkedGrid(Grid[i * 9]) || !CheckMarkedGrid(Grid[i * 9 + 8]))
                        {
                            allNumbersOnBoundaryMarked = false;
                            break;
                        }
                    }

                    if (allNumbersOnBoundaryMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "First Half":
                    bool isFirstHalfMarked = true;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 3; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (!CheckEmptymarked(grid))
                            {
                                isFirstHalfMarked = false;
                                break;
                            }
                        }

                        if (!isFirstHalfMarked)
                            break;
                    }

                    if (isFirstHalfMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Second Half":
                    bool isSecondHalfMarked = true;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for (int j = 2; j < 5; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
                            if (!CheckEmptymarked(grid))
                            {
                                isSecondHalfMarked = false;
                                break;
                            }
                        }

                        if (!isSecondHalfMarked)
                            break;
                    }

                    if (isSecondHalfMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;

                case "Shehnai Bidaai":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;

                case "Brahma":
                     allNumbersMarked = true;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int n = int.Parse(text);
                        if (n <= 30 && !CheckMarkedGrid(s[i]))
                        {
                            allNumbersMarked = false;
                            break;
                        }
                    }

                    if (allNumbersMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Vishnu":
                    allNumbersMarked = true;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int n = int.Parse(text);
                        if (n >= 31 && n <= 60 && !CheckMarkedGrid(s[i]))
                        {
                            allNumbersMarked = false;
                            break;
                        }
                    }

                    if (allNumbersMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Mahesh":
                    allNumbersMarked = true;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int n = int.Parse(text);
                        if (n >= 61 && n <= 90 && !CheckMarkedGrid(s[i]))
                        {
                            allNumbersMarked = false;
                            break;
                        }
                    }

                    if (allNumbersMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Railway Truck":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Drum":
                    if (CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "ZIP":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[7])  && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "ZAP":
                    if (CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Letter C":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[1]) && CheckEmptymarked(s[2]) && CheckEmptymarked(s[3]) && CheckEmptymarked(s[4]) && CheckEmptymarked(s[5]) && CheckEmptymarked(s[6]) && CheckEmptymarked(s[7]) && CheckEmptymarked(s[8]) && CheckEmptymarked(s[9]) &&  CheckEmptymarked(s[18]) && CheckEmptymarked(s[19]) && CheckEmptymarked(s[20]) && CheckEmptymarked(s[21]) && CheckEmptymarked(s[22]) && CheckEmptymarked(s[23]) && CheckEmptymarked(s[24]) && CheckEmptymarked(s[25]) && CheckEmptymarked(s[26]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Letter I":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[1]) && CheckEmptymarked(s[2]) && CheckEmptymarked(s[3]) && CheckEmptymarked(s[4]) && CheckEmptymarked(s[5]) && CheckEmptymarked(s[6]) && CheckEmptymarked(s[7]) && CheckEmptymarked(s[8]) && CheckEmptymarked(s[13]) && CheckEmptymarked(s[18]) && CheckEmptymarked(s[19]) && CheckEmptymarked(s[20]) && CheckEmptymarked(s[21]) && CheckEmptymarked(s[22]) && CheckEmptymarked(s[23]) && CheckEmptymarked(s[24]) && CheckEmptymarked(s[25]) && CheckEmptymarked(s[26]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Letter D":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[1]) && CheckEmptymarked(s[2]) && CheckEmptymarked(s[3]) && CheckEmptymarked(s[4]) && CheckEmptymarked(s[5]) && CheckEmptymarked(s[6]) && CheckEmptymarked(s[7]) && CheckEmptymarked(s[8]) && CheckEmptymarked(s[9]) && CheckEmptymarked(s[17]) && CheckEmptymarked(s[18]) && CheckEmptymarked(s[19]) && CheckEmptymarked(s[20]) && CheckEmptymarked(s[21]) && CheckEmptymarked(s[22]) && CheckEmptymarked(s[23]) && CheckEmptymarked(s[24]) && CheckEmptymarked(s[25]) && CheckEmptymarked(s[26]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "CID":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[1]) && CheckEmptymarked(s[2]) && CheckEmptymarked(s[4]) && CheckEmptymarked(s[6]) && CheckEmptymarked(s[7]) && CheckEmptymarked(s[8]) && CheckEmptymarked(s[9]) && CheckEmptymarked(s[13]) && CheckEmptymarked(s[15]) && CheckEmptymarked(s[17]) && CheckEmptymarked(s[18]) && CheckEmptymarked(s[19]) && CheckEmptymarked(s[20]) && CheckEmptymarked(s[22]) && CheckEmptymarked(s[24]) && CheckEmptymarked(s[25]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Letter H":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[8]) && CheckEmptymarked(s[9]) && CheckEmptymarked(s[10]) && CheckEmptymarked(s[11]) && CheckEmptymarked(s[12]) && CheckEmptymarked(s[13]) && CheckEmptymarked(s[14]) && CheckEmptymarked(s[15]) && CheckEmptymarked(s[16]) && CheckEmptymarked(s[17]) && CheckEmptymarked(s[18])  && CheckEmptymarked(s[26]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Letter T":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[1]) && CheckEmptymarked(s[2]) && CheckEmptymarked(s[3]) && CheckEmptymarked(s[4]) && CheckEmptymarked(s[5]) && CheckEmptymarked(s[6]) && CheckEmptymarked(s[7]) && CheckEmptymarked(s[8]) && CheckEmptymarked(s[13]) && CheckEmptymarked(s[22]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Letter L":
                    if (CheckEmptymarked(s[0])  && CheckEmptymarked(s[9]) && CheckEmptymarked(s[18]) && CheckEmptymarked(s[19]) && CheckEmptymarked(s[20]) && CheckEmptymarked(s[21]) && CheckEmptymarked(s[22]) && CheckEmptymarked(s[23]) && CheckEmptymarked(s[24]) && CheckEmptymarked(s[25]) && CheckEmptymarked(s[26]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Digit 7":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[1]) && CheckEmptymarked(s[2]) && CheckEmptymarked(s[3]) && CheckEmptymarked(s[4]) && CheckEmptymarked(s[5]) && CheckEmptymarked(s[6]) && CheckEmptymarked(s[7]) && CheckEmptymarked(s[8]) &&  CheckEmptymarked(s[17]) &&  CheckEmptymarked(s[26]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Pyramid":
                    if (CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Reverse Pyramid":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Circle":
                    if (CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[8]) &&  CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "All Even":
                    bool areAllEvenMarked = true;
                    for(int i = 0; i < s.Count;i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int n = int.Parse(text);
                        if (n % 2 == 0 && !CheckMarkedGrid(s[i]))
                        {
                            areAllEvenMarked = false;
                            break;
                        }
                    }
                    if (areAllEvenMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "All Odd":
                    bool areAllOddMarked = true;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int n = int.Parse(text);
                        if (n % 2 != 0 && !CheckMarkedGrid(s[i]))
                        {
                            areAllOddMarked = false;
                            break;
                        }
                    }
                    if (areAllOddMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;

                case "Eclipse":
                    if (CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Plus":
                    if (CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Temp / BP":
                    int smallestNumber = int.MaxValue;
                    int highestNumber = int.MinValue;

                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int number = int.Parse(text);

                        if (number < smallestNumber)
                            smallestNumber = number;

                        if (number > highestNumber)
                            highestNumber = number;
                    }

                    bool areSmallestAndHighestMarked = CheckMarkedGrid(GetGridByNumber(smallestNumber)) && CheckMarkedGrid(GetGridByNumber(highestNumber));

                    if (areSmallestAndHighestMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Double Temp":
                    List<int> numbers = new List<int>();

                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int number = int.Parse(text);
                        numbers.Add(number);
                    }

                    numbers.Sort();

                    bool areTwoSmallestAndTwoHighestMarked = CheckMarkedGrid(GetGridByNumber(numbers[0])) &&
                                                             CheckMarkedGrid(GetGridByNumber(numbers[1])) &&
                                                             CheckMarkedGrid(GetGridByNumber(numbers[numbers.Count - 1])) &&
                                                             CheckMarkedGrid(GetGridByNumber(numbers[numbers.Count - 2]));

                    if (areTwoSmallestAndTwoHighestMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Triple Temp":
                    List<int> numbers_Triple = new List<int>();

                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int number = int.Parse(text);
                        numbers_Triple.Add(number);
                    }

                    numbers_Triple.Sort();

                    bool areThreeSmallestAndThreeHighestMarked = CheckMarkedGrid(GetGridByNumber(numbers_Triple[0])) &&
                                                                 CheckMarkedGrid(GetGridByNumber(numbers_Triple[1])) &&
                                                                 CheckMarkedGrid(GetGridByNumber(numbers_Triple[2])) &&
                                                                 CheckMarkedGrid(GetGridByNumber(numbers_Triple[numbers_Triple.Count - 1])) &&
                                                                 CheckMarkedGrid(GetGridByNumber(numbers_Triple[numbers_Triple.Count - 2])) &&
                                                                 CheckMarkedGrid(GetGridByNumber(numbers_Triple[numbers_Triple.Count - 3]));

                    if (areThreeSmallestAndThreeHighestMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "5 Min 5 Max":
                    List<int> numbers_five = new List<int>();

                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int number = int.Parse(text);
                        numbers_five.Add(number);
                    }

                    numbers_five.Sort();

                    bool areFiveSmallestAndFiveHighestMarked = true;
                    for (int i = 0; i < 5; i++)
                    {
                        if (!CheckMarkedGrid(GetGridByNumber(numbers_five[i])) || !CheckMarkedGrid(GetGridByNumber(numbers_five[numbers_five.Count - 1 - i])))
                        {
                            areFiveSmallestAndFiveHighestMarked = false;
                            break;
                        }
                    }

                    if (areFiveSmallestAndFiveHighestMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "5 Minimum":
                    List<int> numbers_5Min = new List<int>();

                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        int number = int.Parse(text);
                        numbers_5Min.Add(number);
                    }

                    numbers_5Min.Sort();

                    bool areFiveMinimumMarked = true;
                    for (int i = 0; i < 5; i++)
                    {
                        if (!CheckMarkedGrid(GetGridByNumber(numbers_5Min[i])))
                        {
                            areFiveMinimumMarked = false;
                            break;
                        }
                    }

                    if (areFiveMinimumMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Anda":
                    bool anda = true;
                    bool zero = false;
                    for(int i = 0; i < s.Count;i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if(text.Contains("0"))
                        {
                            zero = true;
                            if(!CheckMarkedGrid(s[i]))
                            {
                                anda = false;
                                break;
                            }
                            else
                            {
                                anda = true;
                            }
                            
                        }
                    }
                    if(anda && zero)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Danda":
                    bool danda = true;
                    bool one = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("1"))
                        {
                            one = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                danda = false;
                                break;
                            }
                            else
                            {
                                danda = true;
                            }

                        }
                    }
                    if (danda && one)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Anda Danda":
                    bool numberContaining = true;
                    bool present = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("1") && text.Contains("0"))
                        {
                            present = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                numberContaining = false;
                                break;
                            }
                            else
                            {
                                numberContaining = true;
                            }

                        }
                    }
                    if (numberContaining && present)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "5 Pandav":
                     numberContaining = true;
                     present = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("5"))
                        {
                            present = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                numberContaining = false;
                                break;
                            }
                            else
                            {
                                numberContaining = true;
                            }

                        }
                    }
                    if (numberContaining && present)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Hockey Stick":
                    numberContaining = true;
                    present = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("7"))
                        {
                            present = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                numberContaining = false;
                                break;
                            }
                            else
                            {
                                numberContaining = true;
                            }

                        }
                    }
                    if (numberContaining && present)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Fat Lady":
                    numberContaining = true;
                    present = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("8"))
                        {
                            present = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                numberContaining = false;
                                break;
                            }
                            else
                            {
                                numberContaining = true;
                            }

                        }
                    }
                    if (numberContaining && present)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Ugly Duckling":
                    numberContaining = true;
                    present = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("2"))
                        {
                            present = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                numberContaining = false;
                                break;
                            }
                            else
                            {
                                numberContaining = true;
                            }

                        }
                    }
                    if (numberContaining && present)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Naughty 6 & 9":
                    numberContaining = true;
                    present = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("6") && text.Contains("9"))
                        {
                            present = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                numberContaining = false;
                                break;
                            }
                            else
                            {
                                numberContaining = true;
                            }

                        }
                    }
                    if (numberContaining && present)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "26 January":
                    numberContaining = true;
                    present = false;
                    for (int i = 0; i < s.Count; i++)
                    {
                        string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text.Contains("6") && text.Contains("2"))
                        {
                            present = true;
                            if (!CheckMarkedGrid(s[i]))
                            {
                                numberContaining = false;
                                break;
                            }
                            else
                            {
                                numberContaining = true;
                            }

                        }
                    }
                    if (numberContaining && present)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "1 Pair (Row)":
                    bool isPairedMarked = false;
                    for(int i =0;i < 3;i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                        for(int j = 0;j < 8;j++)
                        {
                            GameObject grid1 = row.transform.GetChild(j).gameObject;
                            GameObject grid2 = row.transform.GetChild(j + 1).gameObject;
                            if(!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                isPairedMarked = true;
                                break; 
                            }
                        }
                        if (isPairedMarked)
                        {
                            break;
                        }
                    }

                    if (isPairedMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "2 Pair (Row)":
                     bool isTwoPairedMarked = false;
                    int pairCount = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;
                         
                        for (int j = 0; j < 8; j++)
                        {
                            GameObject grid1 = row.transform.GetChild(j).gameObject;
                            GameObject grid2 = row.transform.GetChild(j + 1).gameObject;
                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                pairCount++;

                                if (pairCount == 2)
                                {
                                    isTwoPairedMarked = true;
                                    break;
                                }

                            }
                        }
                        if (isTwoPairedMarked)
                        {
                            break;
                        }
                    }

                    if (isTwoPairedMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;

                case "3 Pair (Row)":
                    isPairedMarked = false;
                    pairCount = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 8; j++)
                        {
                            GameObject grid1 = row.transform.GetChild(j).gameObject;
                            GameObject grid2 = row.transform.GetChild(j + 1).gameObject;
                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                pairCount++;

                                if (pairCount == 3)
                                {
                                    isPairedMarked = true;
                                    break;
                                }

                            }
                        }
                        if (isPairedMarked)
                        {
                            break;
                        }
                    }

                    if (isPairedMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;

                case "4 Pair (Row)":
                    isPairedMarked = false;
                    pairCount = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 8; j++)
                        {
                            GameObject grid1 = row.transform.GetChild(j).gameObject;
                            GameObject grid2 = row.transform.GetChild(j + 1).gameObject;
                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                pairCount++;

                                if (pairCount == 4)
                                {
                                    isPairedMarked = true;
                                    break;
                                }

                            }
                        }
                        if (isPairedMarked)
                        {
                            break;
                        }
                    }

                    if (isPairedMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;

                case "5 Pair (Row)":
                    isPairedMarked = false;
                    pairCount = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = TicketCont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 8; j++)
                        {
                            GameObject grid1 = row.transform.GetChild(j).gameObject;
                            GameObject grid2 = row.transform.GetChild(j + 1).gameObject;
                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                pairCount++;

                                if (pairCount == 5 || pairCount == 6 || pairCount == 7)
                                {
                                    isPairedMarked = true;
                                    break;
                                }

                            }
                        }
                        if (isPairedMarked)
                        {
                            break;
                        }
                    }

                    if (isPairedMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "1 Pair (Column)":
                     isPairedMarked = false;
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject row1 = TicketCont.transform.GetChild(i).gameObject;
                            GameObject row2 = TicketCont.transform.GetChild(i + 1).gameObject;

                            GameObject grid1 = row1.transform.GetChild(j).gameObject;
                            GameObject grid2 = row2.transform.GetChild(j).gameObject;

                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                isPairedMarked = true;
                                break;
                            }
                        }
                        if (isPairedMarked)
                        {
                            break;
                        }
                    }

                    if (isPairedMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "2 Pair (Column)":
                     pairCount = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        int currentPairCount = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject row1 = TicketCont.transform.GetChild(i).gameObject;
                            GameObject row2 = TicketCont.transform.GetChild(i + 1).gameObject;

                            GameObject grid1 = row1.transform.GetChild(j).gameObject;
                            GameObject grid2 = row2.transform.GetChild(j).gameObject;

                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                currentPairCount++;
                            }
                        }
                        if (currentPairCount == 2)
                        {
                            pairCount = 2;
                            break;
                        }
                    }

                    if (pairCount == 2)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "3 Pair (Column)":
                     pairCount = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        int currentPairCount = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject row1 = TicketCont.transform.GetChild(i).gameObject;
                            GameObject row2 = TicketCont.transform.GetChild(i + 1).gameObject;

                            GameObject grid1 = row1.transform.GetChild(j).gameObject;
                            GameObject grid2 = row2.transform.GetChild(j).gameObject;

                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                currentPairCount++;
                            }
                        }
                        if (currentPairCount == 2)
                        {
                            pairCount++;
                        }
                        else if (currentPairCount < 2)
                        {
                            pairCount = 0;
                        }

                        if (pairCount == 3)
                        {
                            break;
                        }
                    }

                    if (pairCount == 3)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "4 Pair (Column)":
                     pairCount = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        int currentPairCount = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject row1 = TicketCont.transform.GetChild(i).gameObject;
                            GameObject row2 = TicketCont.transform.GetChild(i + 1).gameObject;

                            GameObject grid1 = row1.transform.GetChild(j).gameObject;
                            GameObject grid2 = row2.transform.GetChild(j).gameObject;

                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                currentPairCount++;
                            }
                        }
                        if (currentPairCount == 2)
                        {
                            pairCount++;
                        }
                        else if (currentPairCount < 2)
                        {
                            pairCount = 0;
                        }

                        if (pairCount == 4)
                        {
                            break;
                        }
                    }

                    if (pairCount == 4)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "All Pair (Column)":
                    bool allPairsMarked = true;
                    for (int j = 0; j < 8; j++)
                    {
                        int currentPairCount = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject row1 = TicketCont.transform.GetChild(i).gameObject;
                            GameObject row2 = TicketCont.transform.GetChild(i + 1).gameObject;

                            GameObject grid1 = row1.transform.GetChild(j).gameObject;
                            GameObject grid2 = row2.transform.GetChild(j).gameObject;

                            if (!CheckEmptyGrid(grid1) && !CheckEmptyGrid(grid2) && CheckMarkedGrid(grid1) && CheckMarkedGrid(grid2))
                            {
                                currentPairCount++;
                            }
                        }
                        if (currentPairCount != 2)
                        {
                            allPairsMarked = false;
                            break;
                        }
                    }

                    if (allPairsMarked)
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;


                case "First / Top Line":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[4]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Second / Middle Line":
                    if (CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[9]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Third Line / Last Line":
                    if (CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "I Love You 143":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "We Love You 243":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Love You Too 433":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "You And Me 332":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2])  && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "124":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "421":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[10]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "225":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Work From Home 444":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Stay At Home 424":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6])  && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "123":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "333":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Jai Shree Ram 353":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[5]) && CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[11]) && CheckMarkedGrid(s[12]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "4 2 ka 1(Reverse)":
                    if (CheckMarkedGrid(s[1]) && CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "333(reverse)":
                    if ( CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "3 2 ka 1 (Reverse)":
                    if (CheckMarkedGrid(s[2]) && CheckMarkedGrid(s[3]) && CheckMarkedGrid(s[4]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[9]) && CheckMarkedGrid(s[12]) && CheckMarkedGrid(s[13]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "Wear Mask":
                    if (CheckMarkedGrid(s[0]) && CheckMarkedGrid(s[4]) &&  CheckMarkedGrid(s[6]) && CheckMarkedGrid(s[7]) && CheckMarkedGrid(s[8]) && CheckMarkedGrid(s[10]) && CheckMarkedGrid(s[14]))
                    {
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                        InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                    }
                    break;
                case "House":
                    count = 0;
                    for(int i=0;i < s.Count;i++)
                    {
                        if (CheckMarkedGrid(s[i]))
                        {
                            count++;
                            if (count == 15)
                            {
                                SummaryList.Remove(desc);
                                RemoveGameObjectFromPendingList(desc);
                                InstantiateTicketVerifyPrefab(TicketPrefab, desc);
                            }
                        }
                    }
                    break;
            }

        }

    }




    public void TicketSetwiseVerificationMethod(GameObject TicketCont)
    {
        s_6.Clear();
        for (int i = 0; i < TicketCont.transform.childCount; i++)
        {
            GameObject ticketPrefab = TicketCont.transform.GetChild(i).gameObject;
            GameObject ticketPrefabCont = ticketPrefab.transform.GetChild(1).gameObject;
            for (int j = 0; j < 3; j++)
            {
                GameObject row = ticketPrefabCont.transform.GetChild(j).gameObject;
                for(int k =0 ; k < 9; k++)
                {
                    GameObject grid = row.transform.GetChild(k).gameObject;
                    if (grid.transform.GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        s_6.Add(grid);
                    }
                }
               
            }
        }


        Grid_6.Clear();
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
                    Grid_6.Add(grid);
                }

            }
        }


        for (int t = 0; t < SummaryList.Count; t++)
        {
            string desc = SummaryList[t];
            switch (desc)
            {
                case "Block 1 / Breakfast 1":
                    if (CheckEmptymarked(Grid_6[0]) && CheckEmptymarked(Grid_6[1]) && CheckEmptymarked(Grid_6[2]) && CheckEmptymarked(Grid_6[9]) && CheckEmptymarked(Grid_6[10]) && CheckEmptymarked(Grid_6[11]) && CheckEmptymarked(Grid_6[18]) && CheckEmptymarked(Grid_6[19]) && CheckEmptymarked(Grid_6[20]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 2 / Lunch 1":
                    if (CheckEmptymarked(Grid_6[3]) && CheckEmptymarked(Grid_6[4]) && CheckEmptymarked(Grid_6[5]) && CheckEmptymarked(Grid_6[12]) && CheckEmptymarked(Grid_6[13]) && CheckEmptymarked(Grid_6[14]) && CheckEmptymarked(Grid_6[21]) && CheckEmptymarked(Grid_6[22]) && CheckEmptymarked(Grid_6[23]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 3 / Dinner 1":
                    if (CheckEmptymarked(Grid_6[6]) && CheckEmptymarked(Grid_6[7]) && CheckEmptymarked(Grid_6[8]) && CheckEmptymarked(Grid_6[15]) && CheckEmptymarked(Grid_6[16]) && CheckEmptymarked(Grid_6[17]) && CheckEmptymarked(Grid_6[24]) && CheckEmptymarked(Grid_6[25]) && CheckEmptymarked(Grid_6[26]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 4 / Breakfast 2":
                    if (CheckEmptymarked(Grid_6[27]) && CheckEmptymarked(Grid_6[28]) && CheckEmptymarked(Grid_6[29]) && CheckEmptymarked(Grid_6[36]) && CheckEmptymarked(Grid_6[37]) && CheckEmptymarked(Grid_6[38]) && CheckEmptymarked(Grid_6[45]) && CheckEmptymarked(Grid_6[46]) && CheckEmptymarked(Grid_6[47]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 5 / Lunch 2":
                    if (CheckEmptymarked(Grid_6[30]) && CheckEmptymarked(Grid_6[31]) && CheckEmptymarked(Grid_6[32]) && CheckEmptymarked(Grid_6[39]) && CheckEmptymarked(Grid_6[40]) && CheckEmptymarked(Grid_6[41]) && CheckEmptymarked(Grid_6[48]) && CheckEmptymarked(Grid_6[49]) && CheckEmptymarked(Grid_6[50]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 6 / Dinner 2":
                    if (CheckEmptymarked(Grid_6[33]) && CheckEmptymarked(Grid_6[34]) && CheckEmptymarked(Grid_6[35]) && CheckEmptymarked(Grid_6[42]) && CheckEmptymarked(Grid_6[43]) && CheckEmptymarked(Grid_6[44]) && CheckEmptymarked(Grid_6[51]) && CheckEmptymarked(Grid_6[52]) && CheckEmptymarked(Grid_6[53]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 7 / Breakfast 3":
                    if (CheckEmptymarked(Grid_6[54]) && CheckEmptymarked(Grid_6[55]) && CheckEmptymarked(Grid_6[56]) && CheckEmptymarked(Grid_6[63]) && CheckEmptymarked(Grid_6[64]) && CheckEmptymarked(Grid_6[65]) && CheckEmptymarked(Grid_6[72]) && CheckEmptymarked(Grid_6[73]) && CheckEmptymarked(Grid_6[74]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 8 / Lunch 3":
                    if (CheckEmptymarked(Grid_6[57]) && CheckEmptymarked(Grid_6[58]) && CheckEmptymarked(Grid_6[59]) && CheckEmptymarked(Grid_6[66]) && CheckEmptymarked(Grid_6[67]) && CheckEmptymarked(Grid_6[68]) && CheckEmptymarked(Grid_6[75]) && CheckEmptymarked(Grid_6[76]) && CheckEmptymarked(Grid_6[77]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 9 / Dinner 3":
                    if (CheckEmptymarked(Grid_6[60]) && CheckEmptymarked(Grid_6[61]) && CheckEmptymarked(Grid_6[62]) && CheckEmptymarked(Grid_6[69]) && CheckEmptymarked(Grid_6[70]) && CheckEmptymarked(Grid_6[71]) && CheckEmptymarked(Grid_6[78]) && CheckEmptymarked(Grid_6[79]) && CheckEmptymarked(Grid_6[80]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 10 / Breakfast 4":
                    if (CheckEmptymarked(Grid_6[81]) && CheckEmptymarked(Grid_6[82]) && CheckEmptymarked(Grid_6[83]) && CheckEmptymarked(Grid_6[90]) && CheckEmptymarked(Grid_6[91]) && CheckEmptymarked(Grid_6[92]) && CheckEmptymarked(Grid_6[99]) && CheckEmptymarked(Grid_6[100]) && CheckEmptymarked(Grid_6[101]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 11 / Lunch 4":
                    if (CheckEmptymarked(Grid_6[84]) && CheckEmptymarked(Grid_6[85]) && CheckEmptymarked(Grid_6[86]) && CheckEmptymarked(Grid_6[93]) && CheckEmptymarked(Grid_6[94]) && CheckEmptymarked(Grid_6[95]) && CheckEmptymarked(Grid_6[102]) && CheckEmptymarked(Grid_6[103]) && CheckEmptymarked(Grid_6[104]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 12 / Dinner 4":
                    if (CheckEmptymarked(Grid_6[87]) && CheckEmptymarked(Grid_6[88]) && CheckEmptymarked(Grid_6[89]) && CheckEmptymarked(Grid_6[96]) && CheckEmptymarked(Grid_6[97]) && CheckEmptymarked(Grid_6[98]) && CheckEmptymarked(Grid_6[105]) && CheckEmptymarked(Grid_6[106]) && CheckEmptymarked(Grid_6[107]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 13 / Breakfast 5":
                    if (CheckEmptymarked(Grid_6[108]) && CheckEmptymarked(Grid_6[109]) && CheckEmptymarked(Grid_6[110]) && CheckEmptymarked(Grid_6[118]) && CheckEmptymarked(Grid_6[119]) && CheckEmptymarked(Grid_6[117]) && CheckEmptymarked(Grid_6[127]) && CheckEmptymarked(Grid_6[128]) && CheckEmptymarked(Grid_6[126]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 14 / Lunch 5":
                    if (CheckEmptymarked(Grid_6[111]) && CheckEmptymarked(Grid_6[112]) && CheckEmptymarked(Grid_6[113]) && CheckEmptymarked(Grid_6[121]) && CheckEmptymarked(Grid_6[122]) && CheckEmptymarked(Grid_6[120]) && CheckEmptymarked(Grid_6[130]) && CheckEmptymarked(Grid_6[131]) && CheckEmptymarked(Grid_6[129]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 15 / Dinner 5":
                    if (CheckEmptymarked(Grid_6[115]) && CheckEmptymarked(Grid_6[116]) && CheckEmptymarked(Grid_6[114]) && CheckEmptymarked(Grid_6[124]) && CheckEmptymarked(Grid_6[125]) && CheckEmptymarked(Grid_6[123]) && CheckEmptymarked(Grid_6[133]) && CheckEmptymarked(Grid_6[134]) && CheckEmptymarked(Grid_6[132]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 16 / Breakfast 6":
                    if (CheckEmptymarked(Grid_6[136]) && CheckEmptymarked(Grid_6[137]) && CheckEmptymarked(Grid_6[135]) && CheckEmptymarked(Grid_6[145]) && CheckEmptymarked(Grid_6[146]) && CheckEmptymarked(Grid_6[144]) && CheckEmptymarked(Grid_6[154]) && CheckEmptymarked(Grid_6[155]) && CheckEmptymarked(Grid_6[153]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 17 / Lunch 6":
                    if (CheckEmptymarked(Grid_6[139]) && CheckEmptymarked(Grid_6[140]) && CheckEmptymarked(Grid_6[138]) && CheckEmptymarked(Grid_6[148]) && CheckEmptymarked(Grid_6[149]) && CheckEmptymarked(Grid_6[147]) && CheckEmptymarked(Grid_6[157]) && CheckEmptymarked(Grid_6[158]) && CheckEmptymarked(Grid_6[156]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Block 18 / Dinner 6":
                    if (CheckEmptymarked(Grid_6[142]) && CheckEmptymarked(Grid_6[143]) && CheckEmptymarked(Grid_6[140]) && CheckEmptymarked(Grid_6[151]) && CheckEmptymarked(Grid_6[152]) && CheckEmptymarked(Grid_6[150]) && CheckEmptymarked(Grid_6[160]) && CheckEmptymarked(Grid_6[161]) && CheckEmptymarked(Grid_6[159]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line1":
                    if (CheckEmptymarked(s[0]) && CheckEmptymarked(s[1]) && CheckEmptymarked(s[2]) && CheckEmptymarked(s[3]) && CheckEmptymarked(s[4]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line2":
                    if (CheckEmptymarked(s[6]) && CheckEmptymarked(s[7]) && CheckEmptymarked(s[8]) && CheckEmptymarked(s[9]) && CheckEmptymarked(s[5]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line3":
                    if (CheckEmptymarked(s[10]) && CheckEmptymarked(s[11]) && CheckEmptymarked(s[12]) && CheckEmptymarked(s[13]) && CheckEmptymarked(s[14]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line4":
                    if (CheckEmptymarked(s[15]) && CheckEmptymarked(s[16]) && CheckEmptymarked(s[17]) && CheckEmptymarked(s[18]) && CheckEmptymarked(s[19]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line5":
                    if (CheckEmptymarked(s[20]) && CheckEmptymarked(s[21]) && CheckEmptymarked(s[22]) && CheckEmptymarked(s[23]) && CheckEmptymarked(s[24]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line6":
                    if (CheckEmptymarked(s[25]) && CheckEmptymarked(s[26]) && CheckEmptymarked(s[27]) && CheckEmptymarked(s[29]) && CheckEmptymarked(s[29]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line7":
                    if (CheckEmptymarked(s[30]) && CheckEmptymarked(s[31]) && CheckEmptymarked(s[32]) && CheckEmptymarked(s[33]) && CheckEmptymarked(s[34]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line8":
                    if (CheckEmptymarked(s[35]) && CheckEmptymarked(s[36]) && CheckEmptymarked(s[37]) && CheckEmptymarked(s[38]) && CheckEmptymarked(s[39]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line9":
                    if (CheckEmptymarked(s[40]) && CheckEmptymarked(s[41]) && CheckEmptymarked(s[42]) && CheckEmptymarked(s[43]) && CheckEmptymarked(s[44]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line10":
                    if (CheckEmptymarked(s[45]) && CheckEmptymarked(s[46]) && CheckEmptymarked(s[47]) && CheckEmptymarked(s[48]) && CheckEmptymarked(s[49]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line11":
                    if (CheckEmptymarked(s[50]) && CheckEmptymarked(s[51]) && CheckEmptymarked(s[52]) && CheckEmptymarked(s[53]) && CheckEmptymarked(s[54]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line12":
                    if (CheckEmptymarked(s[55]) && CheckEmptymarked(s[56]) && CheckEmptymarked(s[57]) && CheckEmptymarked(s[58]) && CheckEmptymarked(s[59]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line13":
                    if (CheckEmptymarked(s[60]) && CheckEmptymarked(s[61]) && CheckEmptymarked(s[62]) && CheckEmptymarked(s[63]) && CheckEmptymarked(s[64]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line14":
                    if (CheckEmptymarked(s[65]) && CheckEmptymarked(s[66]) && CheckEmptymarked(s[67]) && CheckEmptymarked(s[68]) && CheckEmptymarked(s[69]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line15":
                    if (CheckEmptymarked(s[70]) && CheckEmptymarked(s[71]) && CheckEmptymarked(s[72]) && CheckEmptymarked(s[73]) && CheckEmptymarked(s[74]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line16":
                    if (CheckEmptymarked(s[75]) && CheckEmptymarked(s[76]) && CheckEmptymarked(s[77]) && CheckEmptymarked(s[78]) && CheckEmptymarked(s[79]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line17":
                    if (CheckEmptymarked(s[80]) && CheckEmptymarked(s[81]) && CheckEmptymarked(s[82]) && CheckEmptymarked(s[83]) && CheckEmptymarked(s[84]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Line18":
                    if (CheckEmptymarked(s[85]) && CheckEmptymarked(s[86]) && CheckEmptymarked(s[87]) && CheckEmptymarked(s[88]) && CheckEmptymarked(s[89]))
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }
                    break;
                case "Ticket #1:Early 5":
                    int count = 0;
                   
                    for(int i =0; i < 15;i++ )
                    {
                        if (CheckMarkedGrid(s_6[i]))
                        {
                            count++;
                            if (count == 5)
                            {
                                SaveTicketContNumber(TicketCont);
                                InstantiateSetwiseTicketCOnt(TicketCont, desc);
                                SummaryList.Remove(desc);
                                RemoveGameObjectFromPendingList(desc);
                            }
                        }
                    }
                    break;
                 case "Ticket #2:Early 5":
                     count = 0;
                    for (int i = 15; i < 30; i++)
                    {
                        if (CheckMarkedGrid(s_6[i]))
                        {
                            count++;
                            if (count == 5)
                            {
                                SaveTicketContNumber(TicketCont);
                                InstantiateSetwiseTicketCOnt(TicketCont, desc);
                                SummaryList.Remove(desc);
                                RemoveGameObjectFromPendingList(desc);
                            }
                        }
                    }
                    break;
                case "Ticket #3:Early 5":
                    count = 0;
                    for (int i = 30; i < 45; i++)
                    {
                        if (CheckMarkedGrid(s_6[i]))
                        {
                            count++;
                            if (count == 5)
                            {
                                SaveTicketContNumber(TicketCont);
                                InstantiateSetwiseTicketCOnt(TicketCont, desc);
                                SummaryList.Remove(desc);
                                RemoveGameObjectFromPendingList(desc);
                            }
                        }
                    }
                    break;
                case "Ticket #4:Early 5":
                    count = 0;
                    for (int i = 45; i < 60; i++)
                    {
                        if (CheckMarkedGrid(s_6[i]))
                        {
                            count++;
                            if (count == 5)
                            {
                                SaveTicketContNumber(TicketCont);
                                InstantiateSetwiseTicketCOnt(TicketCont, desc);
                                SummaryList.Remove(desc);
                                RemoveGameObjectFromPendingList(desc);
                            }
                        }
                    }
                    break;
                case "Ticket #5:Early 5":
                    count = 0;
                    for (int i = 60; i < 75; i++)
                    {
                        if (CheckMarkedGrid(s_6[i]))
                        {
                            count++;
                            if (count == 5)
                            {
                                SaveTicketContNumber(TicketCont);
                                InstantiateSetwiseTicketCOnt(TicketCont, desc);
                                SummaryList.Remove(desc);
                                RemoveGameObjectFromPendingList(desc);
                            }
                        }
                    }
                    break;
                case "All 6 Top Lines":
                    bool areAllTopLinesMarked = true;
                    for (int i = 0; i < 6; i++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(i).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        GameObject topRow = ticketCont.transform.GetChild(0).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = topRow.transform.GetChild(j).gameObject;
                            if (!CheckEmptymarked(grid))
                            {
                                areAllTopLinesMarked = false;
                                break;
                            }
                        }

                        if (!areAllTopLinesMarked)
                        {
                            break;
                        }
                    }

                    if (areAllTopLinesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "All 6 Middle Lines":
                    bool areAllMiddleLinesMarked = true;
                    for (int i = 0; i < 6; i++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(i).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        GameObject middleRow = ticketCont.transform.GetChild(1).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = middleRow.transform.GetChild(j).gameObject;
                            if (!CheckEmptymarked(grid))
                            {
                                areAllMiddleLinesMarked = false;
                                break;
                            }
                        }

                        if (!areAllMiddleLinesMarked)
                        {
                            break;
                        }
                    }

                    if (areAllMiddleLinesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "All 6 Last Lines":
                    bool areAllLastLinesMarked = true;
                    for (int i = 0; i < 6; i++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(i).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        GameObject middleRow = ticketCont.transform.GetChild(2).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = middleRow.transform.GetChild(j).gameObject;
                            if (!CheckEmptymarked(grid))
                            {
                                areAllLastLinesMarked = false;
                                break;
                            }
                        }

                        if (!areAllLastLinesMarked)
                        {
                            break;
                        }
                    }

                    if (areAllLastLinesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Outer Lines(#1 & #18)":
                    bool isOuterLinesMarked = true;

                    // Check if all numbers of the 1st line are marked
                    GameObject ticket1 = TicketCont.transform.GetChild(0).gameObject;
                    GameObject ticket1Cont = ticket1.transform.GetChild(1).gameObject;
                    GameObject firstRowTicket1 = ticket1Cont.transform.GetChild(0).gameObject;

                    for (int i = 0; i < 9; i++)
                    {
                        GameObject grid = firstRowTicket1.transform.GetChild(i).gameObject;

                        if (!CheckEmptymarked(grid))
                        {
                            isOuterLinesMarked = false;
                            break;
                        }
                    }

                    // Check if all numbers of the 18th line are marked
                    GameObject ticket18 = TicketCont.transform.GetChild(17).gameObject;
                    GameObject ticket18Cont = ticket18.transform.GetChild(1).gameObject;
                    GameObject lastRowTicket18 = ticket18Cont.transform.GetChild(2).gameObject;

                    for (int i = 0; i < 9; i++)
                    {
                        GameObject grid = lastRowTicket18.transform.GetChild(i).gameObject;

                        if (!CheckEmptymarked(grid))
                        {
                            isOuterLinesMarked = false;
                            break;
                        }
                    }

                    // If all numbers of the 1st and 18th lines are marked, perform the corresponding actions
                    if (isOuterLinesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Ticket #1 House":
                    bool isTicket1HouseMarked = true;
                     ticket1 = TicketCont.transform.GetChild(0).gameObject;
                     ticket1Cont = ticket1.transform.GetChild(1).gameObject;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket1Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isTicket1HouseMarked = false;
                                break;
                            }
                        }

                        if (!isTicket1HouseMarked)
                        {
                            break;
                        }
                    }

                    if (isTicket1HouseMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Inner Lines(#9 & #10)":
                    bool isInnerLinesMarked = true;

                    // Check if all numbers of the 9th line are marked
                    GameObject ticket9 = TicketCont.transform.GetChild(8).gameObject;
                    GameObject ticket9Cont = ticket9.transform.GetChild(1).gameObject;
                    GameObject ninthRowTicket9 = ticket9Cont.transform.GetChild(2).gameObject;

                    for (int i = 0; i < 9; i++)
                    {
                        GameObject grid = ninthRowTicket9.transform.GetChild(i).gameObject;

                        if (!CheckEmptymarked(grid))
                        {
                            isInnerLinesMarked = false;
                            break;
                        }
                    }

                    // Check if all numbers of the 10th line are marked
                    GameObject ticket10 = TicketCont.transform.GetChild(9).gameObject;
                    GameObject ticket10Cont = ticket10.transform.GetChild(1).gameObject;
                    GameObject tenthRowTicket10 = ticket10Cont.transform.GetChild(0).gameObject;

                    for (int i = 0; i < 9; i++)
                    {
                        GameObject grid = tenthRowTicket10.transform.GetChild(i).gameObject;

                        if (!CheckEmptymarked(grid))
                        {
                            isInnerLinesMarked = false;
                            break;
                        }
                    }

                    // If all numbers of the 9th and 10th lines are marked, perform the corresponding actions
                    if (isInnerLinesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Ticket #2 House":
                    bool isTicket2HouseMarked = true;
                    GameObject ticket2 = TicketCont.transform.GetChild(1).gameObject;
                    GameObject ticket2Cont = ticket2.transform.GetChild(1).gameObject;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket2Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isTicket2HouseMarked = false;
                                break;
                            }
                        }

                        if (!isTicket2HouseMarked)
                        {
                            break;
                        }
                    }

                    if (isTicket2HouseMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Ticket #3 House":
                    bool isTicket3HouseMarked = true;
                    GameObject ticket3 = TicketCont.transform.GetChild(2).gameObject;
                    GameObject ticket3Cont = ticket3.transform.GetChild(1).gameObject;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket3Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isTicket3HouseMarked = false;
                                break;
                            }
                        }

                        if (!isTicket3HouseMarked)
                        {
                            break;
                        }
                    }

                    if (isTicket3HouseMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Ticket #4 House":
                    bool isTicket4HouseMarked = true;
                    GameObject ticket4 = TicketCont.transform.GetChild(3).gameObject;
                    GameObject ticket4Cont = ticket4.transform.GetChild(1).gameObject;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket4Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isTicket4HouseMarked = false;
                                break;
                            }
                        }

                        if (!isTicket4HouseMarked)
                        {
                            break;
                        }
                    }

                    if (isTicket4HouseMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Ticket #5 House":
                    bool isTicket5HouseMarked = true;
                    GameObject ticket5 = TicketCont.transform.GetChild(4).gameObject;
                    GameObject ticket5Cont = ticket5.transform.GetChild(1).gameObject;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket5Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isTicket5HouseMarked = false;
                                break;
                            }
                        }

                        if (!isTicket5HouseMarked)
                        {
                            break;
                        }
                    }

                    if (isTicket5HouseMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Ticket #6 House":
                    bool isTicket6HouseMarked = true;
                    GameObject ticket6 = TicketCont.transform.GetChild(5).gameObject;
                    GameObject ticket6Cont = ticket6.transform.GetChild(1).gameObject;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket6Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isTicket6HouseMarked = false;
                                break;
                            }
                        }

                        if (!isTicket6HouseMarked)
                        {
                            break;
                        }
                    }

                    if (isTicket6HouseMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Odd Houses(#1,#3,#5)":
                    bool isOddHousesMarked = true;
                    GameObject ticket_1 = TicketCont.transform.GetChild(0).gameObject;
                    GameObject ticket_1Cont = ticket_1.transform.GetChild(1).gameObject;
                    GameObject ticket_3 = TicketCont.transform.GetChild(2).gameObject;
                    GameObject ticket_3Cont = ticket_3.transform.GetChild(1).gameObject;
                    GameObject ticket_5 = TicketCont.transform.GetChild(4).gameObject;
                    GameObject ticket_5Cont = ticket_5.transform.GetChild(1).gameObject;

                    // Check Ticket #1
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_1Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isOddHousesMarked = false;
                                break;
                            }
                        }

                        if (!isOddHousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #3
                    if (isOddHousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_3Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    isOddHousesMarked = false;
                                    break;
                                }
                            }

                            if (!isOddHousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    // Check Ticket #5
                    if (isOddHousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_5Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    isOddHousesMarked = false;
                                    break;
                                }
                            }

                            if (!isOddHousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (isOddHousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Even Houses(#2,#4,#6)":
                    bool isEvenHousesMarked = true;
                    GameObject ticket_2 = TicketCont.transform.GetChild(1).gameObject;
                    GameObject ticket_2Cont = ticket_2.transform.GetChild(1).gameObject;
                    GameObject ticket_4 = TicketCont.transform.GetChild(3).gameObject;
                    GameObject ticket_4Cont = ticket_4.transform.GetChild(1).gameObject;
                    GameObject ticket_6 = TicketCont.transform.GetChild(5).gameObject;
                    GameObject ticket_6Cont = ticket_6.transform.GetChild(1).gameObject;

                    // Check Ticket #2
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_2Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                isEvenHousesMarked = false;
                                break;
                            }
                        }

                        if (!isEvenHousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #4
                    if (isEvenHousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_4Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    isEvenHousesMarked = false;
                                    break;
                                }
                            }

                            if (!isEvenHousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    // Check Ticket #6
                    if (isEvenHousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_6Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    isEvenHousesMarked = false;
                                    break;
                                }
                            }

                            if (!isEvenHousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (isEvenHousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Top 3 Houses":
                    bool areTop3HousesMarked = true;
                     ticket_1 = TicketCont.transform.GetChild(0).gameObject;
                     ticket_1Cont = ticket_1.transform.GetChild(1).gameObject;
                     ticket_2 = TicketCont.transform.GetChild(1).gameObject;
                     ticket_2Cont = ticket_2.transform.GetChild(1).gameObject;
                     ticket_3 = TicketCont.transform.GetChild(2).gameObject;
                     ticket_3Cont = ticket_3.transform.GetChild(1).gameObject;

                    // Check Ticket #1
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_1Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                areTop3HousesMarked = false;
                                break;
                            }
                        }

                        if (!areTop3HousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #2
                    if (areTop3HousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_2Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areTop3HousesMarked = false;
                                    break;
                                }
                            }

                            if (!areTop3HousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    // Check Ticket #3
                    if (areTop3HousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_3Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areTop3HousesMarked = false;
                                    break;
                                }
                            }

                            if (!areTop3HousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (areTop3HousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Bottom 3 Houses":
                    bool areBottom3HousesMarked = true;
                     ticket_4 = TicketCont.transform.GetChild(3).gameObject;
                     ticket_4Cont = ticket_4.transform.GetChild(1).gameObject;
                     ticket_5 = TicketCont.transform.GetChild(4).gameObject;
                     ticket_5Cont = ticket_5.transform.GetChild(1).gameObject;
                     ticket_6 = TicketCont.transform.GetChild(5).gameObject;
                     ticket_6Cont = ticket_6.transform.GetChild(1).gameObject;

                    // Check Ticket #4
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_4Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                areBottom3HousesMarked = false;
                                break;
                            }
                        }

                        if (!areBottom3HousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #5
                    if (areBottom3HousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_5Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areBottom3HousesMarked = false;
                                    break;
                                }
                            }

                            if (!areBottom3HousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    // Check Ticket #6
                    if (areBottom3HousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_6Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areBottom3HousesMarked = false;
                                    break;
                                }
                            }

                            if (!areBottom3HousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (areBottom3HousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Outer Houses(#1 & #6)":
                    bool areOuterHousesMarked = true;
                     ticket_1 = TicketCont.transform.GetChild(0).gameObject;
                     ticket_1Cont = ticket_1.transform.GetChild(1).gameObject;
                     ticket_6 = TicketCont.transform.GetChild(5).gameObject;
                     ticket_6Cont = ticket_6.transform.GetChild(1).gameObject;

                    // Check Ticket #1
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_1Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                areOuterHousesMarked = false;
                                break;
                            }
                        }

                        if (!areOuterHousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #6
                    if (areOuterHousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_6Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areOuterHousesMarked = false;
                                    break;
                                }
                            }

                            if (!areOuterHousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (areOuterHousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Inner Houses(#3 & #4)":
                    bool areInnerHousesMarked = true;
                     ticket_3 = TicketCont.transform.GetChild(2).gameObject;
                     ticket_3Cont = ticket_3.transform.GetChild(1).gameObject;
                     ticket_4 = TicketCont.transform.GetChild(3).gameObject;
                     ticket_4Cont = ticket_4.transform.GetChild(1).gameObject;

                    // Check Ticket #3
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_3Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                areInnerHousesMarked = false;
                                break;
                            }
                        }

                        if (!areInnerHousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #4
                    if (areInnerHousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_4Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areInnerHousesMarked = false;
                                    break;
                                }
                            }

                            if (!areInnerHousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (areInnerHousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Top 2 Houses(#1 & #12)":
                    bool areTop2HousesMarked = true;
                     ticket_1 = TicketCont.transform.GetChild(0).gameObject;
                     ticket_1Cont = ticket_1.transform.GetChild(1).gameObject;
                     ticket_2 = TicketCont.transform.GetChild(11).gameObject;
                     ticket_2Cont = ticket_2.transform.GetChild(1).gameObject;

                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_1Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                areTop2HousesMarked = false;
                                break;
                            }
                        }

                        if (!areTop2HousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #2
                    if (areTop2HousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_2Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areTop2HousesMarked = false;
                                    break;
                                }
                            }

                            if (!areTop2HousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (areTop2HousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;


                case "Bottom 2 Houses(#5 & #6)":
                    bool areBottom2HousesMarked = true;
                     ticket_5 = TicketCont.transform.GetChild(4).gameObject;
                     ticket_5Cont = ticket_5.transform.GetChild(1).gameObject;
                     ticket_6 = TicketCont.transform.GetChild(5).gameObject;
                     ticket_6Cont = ticket_6.transform.GetChild(1).gameObject;

                    // Check Ticket #5
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticket_5Cont.transform.GetChild(i).gameObject;

                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;

                            if (!CheckEmptymarked(grid))
                            {
                                areBottom2HousesMarked = false;
                                break;
                            }
                        }

                        if (!areBottom2HousesMarked)
                        {
                            break;
                        }
                    }

                    // Check Ticket #6
                    if (areBottom2HousesMarked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticket_6Cont.transform.GetChild(i).gameObject;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (!CheckEmptymarked(grid))
                                {
                                    areBottom2HousesMarked = false;
                                    break;
                                }
                            }

                            if (!areBottom2HousesMarked)
                            {
                                break;
                            }
                        }
                    }

                    if (areBottom2HousesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Super 12":
                    bool isSuper12Marked = true;
                    for(int x = 0; x < TicketCont.transform.childCount;x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        // Iterate over each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;

                            // Check if any 2 numbers in the row are not marked
                            int markedCount = 0;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (CheckMarkedGrid(grid))
                                {
                                    markedCount++;

                                    if (markedCount == 2)
                                    {
                                        break;
                                    }
                                }
                            }

                            // If less than 2 numbers are marked in the row, set the flag to false and break
                            if (markedCount < 2)
                            {
                                isSuper12Marked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSuper12Marked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSuper12Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Super 18":
                    bool isSuper18Marked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        // Iterate over each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;

                            // Check if any 3 numbers in the row are not marked
                            int markedCount = 0;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (CheckMarkedGrid(grid))
                                {
                                    markedCount++;

                                    if (markedCount == 3)
                                    {
                                        break;
                                    }
                                }
                            }

                            // If less than 3 numbers are marked in the row, set the flag to false and break
                            if (markedCount < 3)
                            {
                                isSuper18Marked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSuper18Marked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSuper18Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Super 24":
                    bool isSuper24Marked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        // Iterate over each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;

                            // Check if any 4 numbers in the row are not marked
                            int markedCount = 0;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (CheckMarkedGrid(grid))
                                {
                                    markedCount++;

                                    if (markedCount == 4)
                                    {
                                        break;
                                    }
                                }
                            }

                            // If less than 4 numbers are marked in the row, set the flag to false and break
                            if (markedCount < 4)
                            {
                                isSuper24Marked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSuper24Marked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSuper24Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Super 30":
                    bool isSuper30Marked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        // Iterate over each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;

                            // Check if any 5 numbers in the row are not marked
                            int markedCount = 0;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (CheckMarkedGrid(grid))
                                {
                                    markedCount++;

                                    if (markedCount == 5)
                                    {
                                        break;
                                    }
                                }
                            }

                            // If less than 5 numbers are marked in the row, set the flag to false and break
                            if (markedCount < 5)
                            {
                                isSuper30Marked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSuper30Marked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSuper30Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Super 36":
                    bool isSuper36Marked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        // Iterate over each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;

                            // Check if any 6 numbers in the row are not marked
                            int markedCount = 0;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (CheckMarkedGrid(grid))
                                {
                                    markedCount++;

                                    if (markedCount == 6)
                                    {
                                        break;
                                    }
                                }
                            }

                            // If less than 6 numbers are marked in the row, set the flag to false and break
                            if (markedCount < 6)
                            {
                                isSuper36Marked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSuper36Marked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSuper36Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Super 42":
                    bool isSuper42Marked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;
                        // Iterate over each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;

                            // Check if any 7 numbers in the row are not marked
                            int markedCount = 0;

                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;

                                if (CheckMarkedGrid(grid))
                                {
                                    markedCount++;

                                    if (markedCount == 7)
                                    {
                                        break;
                                    }
                                }
                            }

                            // If less than 7 numbers are marked in the row, set the flag to false and break
                            if (markedCount < 7)
                            {
                                isSuper42Marked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSuper42Marked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSuper42Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Sheet Queen Corners":
                    bool isSheetQueenCornersMarked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;

                        // Check the first number of each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;
                            GameObject grid = row.transform.GetChild(0).gameObject;

                            // If the first number is not marked, set the flag to false and break
                            if (!CheckMarkedGrid(grid))
                            {
                                isSheetQueenCornersMarked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSheetQueenCornersMarked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSheetQueenCornersMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "Sheet King Corners":
                    bool isSheetKingCornersMarked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;

                        // Check the fifth number of each row in the ticket
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCont.transform.GetChild(i).gameObject;
                            GameObject grid = row.transform.GetChild(4).gameObject;

                            // If the fifth number is not marked, set the flag to false and break
                            if (!CheckMarkedGrid(grid))
                            {
                                isSheetKingCornersMarked = false;
                                break;
                            }
                        }

                        // If any ticket fails the condition, break the loop
                        if (!isSheetKingCornersMarked)
                        {
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSheetKingCornersMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Sheet Corners":
                    bool isSheetCornersMarked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;

                        // Check the first and fifth numbers of the top row
                        GameObject topRow = ticketCont.transform.GetChild(0).gameObject;
                        GameObject firstNumberTop = topRow.transform.GetChild(0).gameObject;
                        GameObject fifthNumberTop = topRow.transform.GetChild(4).gameObject;

                        // Check the first and fifth numbers of the bottom row
                        GameObject bottomRow = ticketCont.transform.GetChild(2).gameObject;
                        GameObject firstNumberBottom = bottomRow.transform.GetChild(0).gameObject;
                        GameObject fifthNumberBottom = bottomRow.transform.GetChild(4).gameObject;

                        // If any of the corner numbers are not marked, set the flag to false and break
                        if (!CheckMarkedGrid(firstNumberTop) || !CheckMarkedGrid(fifthNumberTop) || !CheckMarkedGrid(firstNumberBottom) || !CheckMarkedGrid(fifthNumberBottom))
                        {
                            isSheetCornersMarked = false;
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSheetCornersMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Beginners 6":
                    bool isBeginners6Marked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;

                        // Check the first number of the top line
                        GameObject topRow = ticketCont.transform.GetChild(0).gameObject;
                        GameObject firstNumberTop = topRow.transform.GetChild(0).gameObject;

                        // If the first number of the top line is not marked, set the flag to false and break
                        if (!CheckMarkedGrid(firstNumberTop))
                        {
                            isBeginners6Marked = false;
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isBeginners6Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Finishers 6":
                    bool isFinishers6Marked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;

                        // Check the fifth number of the bottom line
                        GameObject bottomRow = ticketCont.transform.GetChild(2).gameObject;
                        GameObject fifthNumberBottom = bottomRow.transform.GetChild(4).gameObject;

                        // If the fifth number of the bottom line is not marked, set the flag to false and break
                        if (!CheckMarkedGrid(fifthNumberBottom))
                        {
                            isFinishers6Marked = false;
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isFinishers6Marked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "Sheet Bull Eyes":
                    bool isSheetBullEyesMarked = true;
                    for (int x = 0; x < TicketCont.transform.childCount; x++)
                    {
                        GameObject ticket = TicketCont.transform.GetChild(x).gameObject;
                        GameObject ticketCont = ticket.transform.GetChild(1).gameObject;

                        // Check the third number of the middle line
                        GameObject middleRow = ticketCont.transform.GetChild(1).gameObject;
                        GameObject thirdNumberMiddle = middleRow.transform.GetChild(2).gameObject;

                        // If the third number of the middle line is not marked, set the flag to false and break
                        if (!CheckMarkedGrid(thirdNumberMiddle))
                        {
                            isSheetBullEyesMarked = false;
                            break;
                        }
                    }

                    // If all tickets satisfy the condition, perform the corresponding actions
                    if (isSheetBullEyesMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;
                case "8 Corners":
                    bool is8CornersMarked = true;

                    // Check the 1st and 5th numbers of the Top Line of Ticket #1
                     ticket_1 = TicketCont.transform.GetChild(0).gameObject;
                     ticket_1Cont = ticket_1.transform.GetChild(1).gameObject;
                    GameObject topRowTicket1 = ticket_1Cont.transform.GetChild(0).gameObject;
                    GameObject firstNumberTopTicket1 = topRowTicket1.transform.GetChild(0).gameObject;
                    GameObject fifthNumberTopTicket1 = topRowTicket1.transform.GetChild(4).gameObject;

                    if (!CheckMarkedGrid(firstNumberTopTicket1) || !CheckMarkedGrid(fifthNumberTopTicket1))
                    {
                        is8CornersMarked = false;
                        break;
                    }

                    // Check the 1st and 5th numbers of the Bottom Line of Ticket #3
                     ticket_3 = TicketCont.transform.GetChild(2).gameObject;
                     ticket_3Cont = ticket_3.transform.GetChild(1).gameObject;
                    GameObject bottomRowTicket3 = ticket_3Cont.transform.GetChild(2).gameObject;
                    GameObject firstNumberBottomTicket3 = bottomRowTicket3.transform.GetChild(0).gameObject;
                    GameObject fifthNumberBottomTicket3 = bottomRowTicket3.transform.GetChild(4).gameObject;

                    if (!CheckMarkedGrid(firstNumberBottomTicket3) || !CheckMarkedGrid(fifthNumberBottomTicket3))
                    {
                        is8CornersMarked = false;
                        break;
                    }

                    // Check the 1st and 5th numbers of the Top Line of Ticket #4
                     ticket_4 = TicketCont.transform.GetChild(3).gameObject;
                     ticket_4Cont = ticket_4.transform.GetChild(1).gameObject;
                    GameObject topRowTicket4 = ticket_4Cont.transform.GetChild(0).gameObject;
                    GameObject firstNumberTopTicket4 = topRowTicket4.transform.GetChild(0).gameObject;
                    GameObject fifthNumberTopTicket4 = topRowTicket4.transform.GetChild(4).gameObject;

                    if (!CheckMarkedGrid(firstNumberTopTicket4) || !CheckMarkedGrid(fifthNumberTopTicket4))
                    {
                        is8CornersMarked = false;
                        break;
                    }

                    // Check the 1st and 5th numbers of the Bottom Line of Ticket #6
                     ticket_6 = TicketCont.transform.GetChild(5).gameObject;
                     ticket_6Cont = ticket_6.transform.GetChild(1).gameObject;
                    GameObject bottomRowTicket6 = ticket_6Cont.transform.GetChild(2).gameObject;
                    GameObject firstNumberBottomTicket6 = bottomRowTicket6.transform.GetChild(0).gameObject;
                    GameObject fifthNumberBottomTicket6 = bottomRowTicket6.transform.GetChild(4).gameObject;

                    if (!CheckMarkedGrid(firstNumberBottomTicket6) || !CheckMarkedGrid(fifthNumberBottomTicket6))
                    {
                        is8CornersMarked = false;
                        break;
                    }

                    // If all conditions are satisfied, perform the corresponding actions
                    if (is8CornersMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);
                    }

                    break;

                case "4 Corners":
                    bool is4CornersMarked = true;

                    // Check the 1st and 5th numbers of the Top Line of Ticket #1
                     ticket_1 = TicketCont.transform.GetChild(0).gameObject;
                     ticket_1Cont = ticket_1.transform.GetChild(1).gameObject;
                     topRowTicket1 = ticket_1Cont.transform.GetChild(0).gameObject;
                     firstNumberTopTicket1 = topRowTicket1.transform.GetChild(0).gameObject;
                     fifthNumberTopTicket1 = topRowTicket1.transform.GetChild(4).gameObject;

                    if (!CheckMarkedGrid(firstNumberTopTicket1) || !CheckMarkedGrid(fifthNumberTopTicket1))
                    {
                        is4CornersMarked = false;
                        break;
                    }

                    // Check the 1st and 5th numbers of the Bottom Line of Ticket #6
                     ticket_6 = TicketCont.transform.GetChild(5).gameObject;
                     ticket_6Cont = ticket_6.transform.GetChild(1).gameObject;
                     bottomRowTicket6 = ticket_6Cont.transform.GetChild(2).gameObject;
                     firstNumberBottomTicket6 = bottomRowTicket6.transform.GetChild(0).gameObject;
                     fifthNumberBottomTicket6 = bottomRowTicket6.transform.GetChild(4).gameObject;

                    if (!CheckMarkedGrid(firstNumberBottomTicket6) || !CheckMarkedGrid(fifthNumberBottomTicket6))
                    {
                        is4CornersMarked = false;
                        break;
                    }

                    // If all conditions are satisfied, perform the corresponding actions
                    if (is4CornersMarked)
                    {
                        SaveTicketContNumber(TicketCont);
                        InstantiateSetwiseTicketCOnt(TicketCont, desc);
                        SummaryList.Remove(desc);
                        RemoveGameObjectFromPendingList(desc);

                    }

                    break;

            }
        }
    }


    


    public void SaveTicketContNumber(GameObject TicketCont)
    {
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
        }
    }

    public void InstantiateSetwiseTicketCOnt(GameObject TicketCont,string desc)
    {
        BoardManager.Instance.claimNotification.gameObject.SetActive(true);
        BoardManager.Instance.showingNoti = true;


        if (VerifyUI.instance.currentToggleIndex == 1 )
        {
            int ticketsCount = TicketCont.transform.childCount;
            GameObject go = Instantiate(TicketContPrefabs[0], ContentVerify.transform);
            go.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = desc;
            GameObject ClaimDesc = go.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
            GameObject ticket = go.transform.GetChild(1).gameObject;
            GameObject Cont = ticket.transform.GetChild(0).GetChild(1).gameObject;
            int id = 0;
            for (int i = 0; i < Cont.transform.childCount; i++)
            {
                GameObject ticketcont = Cont.transform.GetChild(i).gameObject;
                for (int j = 0; j < 3; j++)
                {
                    GameObject row = ticketcont.transform.GetChild(j).gameObject;
                    for (int k = 0; k < 9; k++)
                    {
                        GameObject grid = row.transform.GetChild(k).gameObject;

                        if (TicketInputs[id] == -1)
                        {
                            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                        }
                        else
                        {
                            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                            foreach (int number in BoardManager.Instance.generatedNumbersStack)
                            {
                                if (number == TicketInputs[id])
                                {
                                    grid.GetComponent<Image>().color = Color.red;
                                    grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                                }
                            }
                        }
                        id++;
                    }
                }
            }

            GameObject ApproveButton = go.transform.GetChild(2).gameObject;
            ApproveButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                ApproveClaimButton(desc, ApproveButton, ClaimDesc);

            });

        }



        if (VerifyUI.instance.currentToggleIndex == 2 && TicketCont.transform.childCount == 3)
        {
            GameObject go = Instantiate(TicketContPrefabs[1], ContentVerify.transform);
            go.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = desc;
            GameObject ClaimDesc = go.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
            GameObject ticket = go.transform.GetChild(1).gameObject;
            GameObject Cont = ticket.transform.GetChild(0).GetChild(1).gameObject;
            int id = 0;
            for (int i = 0; i < Cont.transform.childCount; i++)
            {
                GameObject ticketcont = Cont.transform.GetChild(i).gameObject;
                for (int j = 0; j < 3; j++)
                {
                    GameObject row = ticketcont.transform.GetChild(j).gameObject;
                    for (int k = 0; k < 9; k++)
                    {
                        GameObject grid = row.transform.GetChild(k).gameObject;

                        if (TicketInputs[id] == -1)
                        {
                            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                        }
                        else
                        {
                            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                            foreach (int number in BoardManager.Instance.generatedNumbersStack)
                            {
                                if(number == TicketInputs[id])
                                {
                                    grid.GetComponent<Image>().color = Color.red;
                                    grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                                }
                            }
                        }
                        id++;
                    }
                }
            }

            GameObject ApproveButton = go.transform.GetChild(2).gameObject;
            ApproveButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                ApproveClaimButton(desc, ApproveButton,ClaimDesc);

            });

        }
        if (VerifyUI.instance.currentToggleIndex == 3 && TicketCont.transform.childCount==6)
        {
            GameObject go = Instantiate(TicketContPrefabs[2], ContentVerify.transform);
            go.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = desc;
            GameObject ClaimDesc = go.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
            GameObject ticket = go.transform.GetChild(1).gameObject;
            GameObject Cont = ticket.transform.GetChild(0).GetChild(1).gameObject;
            int id = 0;
            for (int i = 0; i < Cont.transform.childCount; i++)
            {
                GameObject ticketcont = Cont.transform.GetChild(i).gameObject;
                for (int j = 0; j < 3; j++)
                {
                    GameObject row = ticketcont.transform.GetChild(j).gameObject;
                    for (int k = 0; k < 9; k++)
                    {
                        GameObject grid = row.transform.GetChild(k).gameObject;

                        if (TicketInputs[id] == -1)
                        {
                            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                        }
                        else
                        {
                            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = TicketInputs[id].ToString();
                            foreach (int number in BoardManager.Instance.generatedNumbersStack)
                            {
                                if (number == TicketInputs[id])
                                {
                                    grid.GetComponent<Image>().color = Color.red;
                                    grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                                }
                            }
                        }
                        id++;
                    }
                }
            }

            GameObject ApproveButton = go.transform.GetChild(2).gameObject;
            ApproveButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                ApproveClaimButton(desc, ApproveButton, ClaimDesc);

            });
        }

        
    }




    public void ApproveClaimButton( string desc,GameObject button,GameObject claim)
    {
        button.GetComponent<Image>().color= Color.white;
        button.transform.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        claim.GetComponent<TextMeshProUGUI>().text = "(Claim Approved)";
        claim.GetComponent<TextMeshProUGUI>().color = Color.green;
        
    }


    public bool CheckMarkedGrid(GameObject g)
    {
        UnityEngine.UI.Image gridImage = g.GetComponent<UnityEngine.UI.Image>();
        if(gridImage.color == Color.red)
        {
            return true;
        }
        return false;
    }

    public string ReturnTicketName(GameObject Ticket)
    {
        GameObject details = Ticket.transform.GetChild(0).gameObject;
        string text = details.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        return text;
    }

    public void InstantiateTicketVerifyPrefab(GameObject gameObject,string desc)
    {
        BoardManager.Instance.claimNotification.gameObject.SetActive(true);
        BoardManager.Instance.showingNoti = true;
        GameObject go = Instantiate(VerifyTicketPrefab, ContentVerify.transform);
        GameObject ClaimDesc = go.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        AddDescToTicket(go, desc);
        GameObject TicketCont = go.transform.GetChild(1).gameObject;
        GameObject go_ticket = Instantiate(gameObject, TicketCont.transform);
        RectTransform rectTransform = go_ticket.GetComponent<RectTransform>();
        if(rectTransform != null)
        {
            Vector2 newSizeDelta = rectTransform.sizeDelta;
            newSizeDelta.y = 415; // Set the desired width
            rectTransform.sizeDelta = newSizeDelta;
            RectTransform rect = go_ticket.transform.GetChild(1).GetComponent<RectTransform>();
            Vector2 newSizeDelta1 = rect.sizeDelta;
            newSizeDelta1.y = 241;
            rect.sizeDelta = newSizeDelta1;

        }
        GameObject ApproveButton = go.transform.GetChild(2).gameObject;
        ApproveButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            ApproveClaimButton(desc, ApproveButton, ClaimDesc);

        });

    }

    public void AddSummaryTOList()
    {
        for (int i = 1; i < ContentSummary.transform.childCount; i++)
        {
            GameObject SummaryPrefab = ContentSummary.transform.GetChild(i).gameObject;
            GameObject go_DividendPrizes = Instantiate(SummaryPrefab, DividendPrizes.transform);
            GameObject go_PendingDividend = Instantiate(SummaryPrefab, PendingDividend.transform);
            RectTransform rectTransform = go_DividendPrizes.GetComponent<RectTransform>();
            RectTransform rectTransform1 = go_PendingDividend.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                Vector2 newSizeDelta = rectTransform.sizeDelta;
                newSizeDelta.x = 564; // Set the desired width
                rectTransform.sizeDelta = newSizeDelta;
                Vector2 newSizeDelta1 = rectTransform1.sizeDelta;
                newSizeDelta1.x = 564; // Set the desired width
                rectTransform1.sizeDelta = newSizeDelta1;
            }
            string name = go_DividendPrizes.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            int dotIndex = name.IndexOf('.');
            if (dotIndex != -1)
            {
                // Remove the index and dot
                name = name.Substring(dotIndex + 1).TrimStart();
            }
            name = name.Replace(".", "");
            go_PendingDividend.name = name;
            SummaryList.Add(name);      
        }

        foreach(string i in SummaryList)
        {
            Debug.Log(i);
        }
    }


    public void RemoveGameObjectFromPendingList(string name)
    {
        for(int i = 1;i < PendingDividend.transform.childCount;i++)
        {
            GameObject go = PendingDividend.transform.GetChild(i).gameObject;
            if(go.name == name)
            {
                Destroy(go);
            }
        }
    }

    public void AddDescToTicket(GameObject prefab,string desc)
    {
        prefab.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = desc;
    }

    public void CallsFunctions(GameObject ticketPrefab,string desc)
    {
        InstantiateTicketVerifyPrefab(ticketPrefab,desc);
        SummaryList.Remove(desc);
        RemoveGameObjectFromPendingList(desc);
    }



    public void OpenVerifySearchPanel()
    {
        SummaryPanel.SetActive(true);
    }

    public void CloseSummaryPanel()
    {
        SummaryPanel.SetActive(false);
    }

    public void OpenSearchPanel()
    {
        SearchPanel.SetActive(true);
        SummaryPanel.SetActive(false);
    }
    public void CloseSearchPanel()
    {
        SearchPanel.SetActive(false);
    }

    public void BackVerifyButton()
    {
        VerifyPanel.SetActive(false);
        SummaryPanel.SetActive(false);
        SearchPanel.SetActive(false);
        StartCoroutine(BoardManager.Instance.AutoGenerateNumbersCoroutine(BoardManager.Instance.slider.value));
    }

    public void MarkedTicketVerificationNumber(int number)
    {
        if(ContentVerify.transform.childCount!=0)
        {
            for (int t = 0; t < ContentVerify.transform.childCount; t++)
            {
                GameObject ticketVerifyprefab = ContentVerify.transform.GetChild(t).gameObject;
                if(ticketVerifyprefab.tag == "Setwise")
                {
                    GameObject ticket = ticketVerifyprefab.transform.GetChild(1).gameObject;
                    GameObject Cont = ticket.transform.GetChild(0).GetChild(1).gameObject;
                    for(int y= 0; y < Cont.transform.childCount;y++)
                    {
                        GameObject ticketCOnt = Cont.transform.GetChild(y).gameObject;
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject row = ticketCOnt.transform.GetChild(i).gameObject;
                            for (int j = 0; j < 9; j++)
                            {
                                GameObject grid = row.transform.GetChild(j).gameObject;
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
                else
                {
                    GameObject ticket = ticketVerifyprefab.transform.GetChild(1).gameObject;
                    GameObject ticketCont = ticket.transform.GetChild(0).GetChild(1).gameObject;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject row = ticketCont.transform.GetChild(i).gameObject;
                        for (int j = 0; j < 9; j++)
                        {
                            GameObject grid = row.transform.GetChild(j).gameObject;
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

    public bool CheckEmptymarked(GameObject g)
    {
       
        if (g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
                return true;            
        }
        else
        {
            if (CheckMarkedGrid(g))
            {
                return true;
            }
        }

        return false;
       
    }

    public bool CheckEmptyGrid(GameObject g)
    {
        if (g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
            return true;
        }
        return false;
    }


    private GameObject GetGridByNumber(int number)
    {
        for (int i = 0; i < s.Count; i++)
        {
            string text = s[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
            int n = int.Parse(text);
            if (n == number)
            {
                return s[i];
            }
        }
        return null; // If the grid element with the specified number is not found
    }


}
