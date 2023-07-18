using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Linq;

public class GenerateDividendTicket : MonoBehaviour
{
    public GameObject TicketInBlockPanel;
    public TMP_Text DividendName;
    public TMP_Text DividendFeature;
    public GameObject Ticket_6_Prefab;
    public GameObject Ticket_1_Prefab;
    public static GenerateDividendTicket instance;
    public GameObject[] Rows;
    public GameObject[] Grid6_;
    public GameObject[] Rows1_;
    public GameObject[] Grid1_;
    private void Awake()
    {
        instance = this;
        int index = Rows.Length;
        int index_1_ = Rows1_.Length;
       
        GameObject cont_6_ = Ticket_6_Prefab.transform.GetChild(1).gameObject;
        for (int i=0;i< cont_6_.transform.childCount;i++)
        {
            GameObject TickContgo = cont_6_.transform.GetChild(i).gameObject;
            for(int j = 0; j < 3;j++)
            {
                GameObject Go_Row = TickContgo.transform.GetChild(j).gameObject;
                Array.Resize(ref Rows, index + 1);
                Rows[index] = Go_Row;
                index++;
            }
        }

        GameObject cont_1_ = Ticket_1_Prefab.transform.GetChild(1).GetChild(0).gameObject;
        for (int i = 0; i < 3; i++)
        {
           
                GameObject Go_Row_1_ = cont_1_.transform.GetChild(i).gameObject;
               
                Array.Resize(ref Rows1_, index_1_ + 1);
                Rows1_[index_1_] = Go_Row_1_;
                index_1_++;
            
        }



    }

    public void ResetTicket_1_()
    {
        for (int i = 0; i < Grid1_.Length; i++)
        {
            Grid1_[i].GetComponent<Image>().color = Color.white;
            Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }

        for(int i = 0;i<Rows1_.Length;i++)
        {
            for(int j = 0; j < Rows1_[i].transform.childCount; j++)
            {
                Rows1_[i].transform.GetChild(j).GetComponent<Image>().color = Color.white;
                Rows1_[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }
    }
    public void ResetTicket_6_()
    {
        for (int i = 0; i < Grid6_.Length; i++)
        {
            Grid6_[i].GetComponent<Image>().color = Color.white;
            Grid6_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }

        for (int i = 0; i < Rows.Length; i++)
        {
            for (int j = 0; j < Rows[i].transform.childCount; j++)
            {
                Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.white;
                Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }
    }

    public void SaveGrid_1_()
    {
        int index_Grid_1_ = Grid1_.Length;
        GameObject cont_1_ = Ticket_1_Prefab.transform.GetChild(1).GetChild(0).gameObject;
       
        for (int i = 0; i < 3; i++)
        {

            GameObject Go_Row_1_ = cont_1_.transform.GetChild(i).gameObject;
            for (int j = 0; j < 9; j++)
            {
                GameObject Grid = Go_Row_1_.transform.GetChild(j).gameObject;
                if (Grid.transform.GetComponentInChildren<TextMeshProUGUI>().text != "")
                {
                    Array.Resize(ref Grid1_, index_Grid_1_ + 1);
                    Grid1_[index_Grid_1_] = Grid;
                    index_Grid_1_++;
                }
            }
            

        }
    }
    public void SaveGrid_6_()
    {
        int index_Grid_6_ = Grid6_.Length;
        GameObject cont_6_ = Ticket_6_Prefab.transform.GetChild(1).gameObject;
        for (int t = 0; t < 6; t++)
        {
            GameObject cont = cont_6_.transform.GetChild(t).gameObject;
            for (int i = 0; i < 3; i++)
            {
                GameObject Go_Row_1_ = cont.transform.GetChild(i).gameObject;
                for (int j = 0; j < 9; j++)
                {
                    GameObject Grid = Go_Row_1_.transform.GetChild(j).gameObject;
                    if (Grid.transform.GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Array.Resize(ref Grid6_, index_Grid_6_ + 1);
                        Grid6_[index_Grid_6_] = Grid;
                        index_Grid_6_++;
                    }
                }


            }
        }
            
    }


    public void MarkRedColor()
    {
       
        switch(DividendName.text)
        {
            case "Block 1 / Breakfast 1":
                for(int i=0;i<3;i++)
                {
                    for(int j=0;j<3;j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;

            case "Block 2 / Lunch 1":
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;

            case "Block 3 / Dinner 1":
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;

            case "Block 4 / Breakfast 2":
                for (int i = 3; i < 6; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 5 / Lunch 2":
                for (int i = 3; i < 6; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 6 / Dinner 2":
                for (int i = 3; i < 6; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 7 / Breakfast 3":
                for (int i = 6; i < 9; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 8 / Lunch 3":
                for (int i = 6; i < 9; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 9 / Dinner 3":
                for (int i = 6; i < 9; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 10 / Breakfast 4":
                for (int i = 9; i < 12; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 11 / Lunch 4":
                for (int i = 9; i < 12; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 12 / Dinner 4":
                for (int i = 9; i < 12; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 13 / Breakfast 5":
                for (int i = 12; i < 15; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 14 / Lunch 5":
                for (int i = 12; i < 15; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 15 / Dinner 5":
                for (int i = 12; i < 15; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 16 / Breakfast 6":
                for (int i = 15; i < 18; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 17 / Lunch 6":
                for (int i = 15; i < 18; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Block 18 / Dinner 6":
                for (int i = 15; i < 18; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line1":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[0].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    
                }
                break;
            case "Line2":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[1].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line3":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[2].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[3].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line4":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[3].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[3].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[3].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line5":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[4].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[4].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[4].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line6":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[6].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[6].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[6].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line7":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[6].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[6].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[6].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line8":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[7].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[7].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[7].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line9":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[8].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[8].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[8].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line10":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[9].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[9].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[9].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line11":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[10].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[10].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[10].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line12":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[11].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[11].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[11].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line13":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[12].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[12].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[12].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line14":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[13].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[13].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[13].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line15":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[14].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[14].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[14].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line16":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[15].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[15].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[15].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line17":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[16].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[16].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[16].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Line18":
                for (int i = 0; i < 9; i++)
                {
                    if (Rows[17].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                    {
                        Rows[17].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                        Rows[17].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Ticket #1:Early 5":
                List<GameObject> values = new List<GameObject>();
                for (int i = 0; i < 3; i++)
                {
                    GameObject row = Rows[i];
                    for(int j =0; j < 9;j++)
                    {
                        string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                        if(text!="")
                        {
                            values.Add(row.transform.GetChild(j).gameObject);
                        }
                    }
                    
                }

                for(int i=0; i < 5;i++)
                {
                    int random = UnityEngine.Random.Range(0, values.Count);
                    GameObject markedGameobject = values[random];
                    values.RemoveAt(random);
                    markedGameobject.GetComponent<Image>().color = Color.red;
                    markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                 break;
            case "Ticket #2:Early 5":
                List<GameObject> values1 = new List<GameObject>();
                for (int i = 3; i < 6; i++)
                {
                    GameObject row = Rows[i];
                    for(int j =0; j < 9;j++)
                    {
                        string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                        if(text!="")
                        {
                            values1.Add(row.transform.GetChild(j).gameObject);
                        }
                    }
                    
                }

                for(int i=0; i < 5;i++)
                {
                    int random = UnityEngine.Random.Range(0, values1.Count);
                    GameObject markedGameobject = values1[random];
                    values1.RemoveAt(random);
                    markedGameobject.GetComponent<Image>().color = Color.red;
                    markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                 break;
            case "Ticket #3:Early 5":
                List<GameObject> values2 = new List<GameObject>();
                for (int i = 3; i < 6; i++)
                {
                    GameObject row = Rows[i];
                    for (int j = 0; j < 9; j++)
                    {
                        string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text != "")
                        {
                            values2.Add(row.transform.GetChild(j).gameObject);
                        }
                    }

                }

                for (int i = 0; i < 5; i++)
                {
                    int random = UnityEngine.Random.Range(0, values2.Count);
                    GameObject markedGameobject = values2[random];
                    values2.RemoveAt(random);
                    markedGameobject.GetComponent<Image>().color = Color.red;
                    markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Ticket #4:Early 5":
                List<GameObject> values3 = new List<GameObject>();
                for (int i = 3; i < 6; i++)
                {
                    GameObject row = Rows[i];
                    for (int j = 0; j < 9; j++)
                    {
                        string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text != "")
                        {
                            values3.Add(row.transform.GetChild(j).gameObject);
                        }
                    }

                }

                for (int i = 0; i < 5; i++)
                {
                    int random = UnityEngine.Random.Range(0, values3.Count);
                    GameObject markedGameobject = values3[random];
                    values3.RemoveAt(random);
                    markedGameobject.GetComponent<Image>().color = Color.red;
                    markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Ticket #5:Early 5":
                List<GameObject> values4 = new List<GameObject>();
                for (int i = 3; i < 6; i++)
                {
                    GameObject row = Rows[i];
                    for (int j = 0; j < 9; j++)
                    {
                        string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                        if (text != "")
                        {
                            values4.Add(row.transform.GetChild(j).gameObject);
                        }
                    }

                }

                for (int i = 0; i < 5; i++)
                {
                    int random = UnityEngine.Random.Range(0, values4.Count);
                    GameObject markedGameobject = values4[random];
                    values4.RemoveAt(random);
                    markedGameobject.GetComponent<Image>().color = Color.red;
                    markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "All 6 Top Lines":
                int[] arr = { 0, 3, 6, 9, 12, 15 };
                foreach(int index in arr)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (Rows[index].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                        {
                            Rows[index].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                            Rows[index].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                        }
                    }
                }

                break;
            case "All 6 Middle Lines":
                int[] arr1 = { 0, 3, 6, 9, 12, 15 };
                foreach (int index in arr1)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (Rows[index+1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                        {
                            Rows[index+1].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                            Rows[index + 1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                        }
                    }
                }

                break;
            case "All 6 Last Lines":
                int[] arr2 = { 0, 3, 6, 9, 12, 15 };
                foreach (int index in arr2)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (Rows[index+2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                        {
                            Rows[index+2].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                            Rows[index+2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                        }
                    }
                }

                break;
            case "Outer Lines(#1 & #18)":
                int[] arr3 = { 0 , 17 };
                foreach (int index in arr3)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (Rows[index].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                        {
                            Rows[index].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                            Rows[index].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                        }
                    }
                }

                break;
            case "Inner Lines(#9 & #10)":
                int[] arr4 = { 8 , 9 };
                foreach (int index in arr4)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (Rows[index ].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != "")
                        {
                            Rows[index ].transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
                            Rows[index ].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                        }
                    }
                }

                break;
            case "4 Corner":
                ResetTicket_1_();
                Debug.Log("sdfv");
                Grid1_[0].GetComponent<Image>().color = Color.red;
                Grid1_[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[4].GetComponent<Image>().color = Color.red;
                Grid1_[4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[10].GetComponent<Image>().color = Color.red;
                Grid1_[10].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[14].GetComponent<Image>().color = Color.red;
                Grid1_[14].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "King Corners":
                ResetTicket_1_();
                Grid1_[4].GetComponent<Image>().color = Color.red;
                Grid1_[4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[9].GetComponent<Image>().color = Color.red;
                Grid1_[9].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[14].GetComponent<Image>().color = Color.red;
                Grid1_[14].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;

            case "Queen Corners":
                ResetTicket_1_();
                Grid1_[0].GetComponent<Image>().color = Color.red;
                Grid1_[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[5].GetComponent<Image>().color = Color.red;
                Grid1_[5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[10].GetComponent<Image>().color = Color.red;
                Grid1_[10].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;

            case "4 Corner and Center":
                ResetTicket_1_();
                Grid1_[0].GetComponent<Image>().color = Color.red;
                Grid1_[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[4].GetComponent<Image>().color = Color.red;
                Grid1_[4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[7].GetComponent<Image>().color = Color.red;
                Grid1_[7].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[10].GetComponent<Image>().color = Color.red;
                Grid1_[10].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[14].GetComponent<Image>().color = Color.red;
                Grid1_[14].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;

            case "Bulls Eyes":
                ResetTicket_1_();
                Grid1_[1].GetComponent<Image>().color = Color.red;
                Grid1_[1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[3].GetComponent<Image>().color = Color.red;
                Grid1_[3].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[6].GetComponent<Image>().color = Color.red;
                Grid1_[6].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[8].GetComponent<Image>().color = Color.red;
                Grid1_[8].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[11].GetComponent<Image>().color = Color.red;
                Grid1_[11].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[13].GetComponent<Image>().color = Color.red;
                Grid1_[13].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;

            case "Twin Lines":
                ResetTicket_1_();
                Grid1_[0].GetComponent<Image>().color = Color.red;
                Grid1_[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[1].GetComponent<Image>().color = Color.red;
                Grid1_[1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[5].GetComponent<Image>().color = Color.red;
                Grid1_[5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[6].GetComponent<Image>().color = Color.red;
                Grid1_[6].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[10].GetComponent<Image>().color = Color.red;
                Grid1_[10].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[11].GetComponent<Image>().color = Color.red;
                Grid1_[11].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                
                break;
            case "6 Corners":
                ResetTicket_1_();
                Grid1_[0].GetComponent<Image>().color = Color.red;
                Grid1_[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[4].GetComponent<Image>().color = Color.red;
                Grid1_[4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[5].GetComponent<Image>().color = Color.red;
                Grid1_[5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[9].GetComponent<Image>().color = Color.red;
                Grid1_[9].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[10].GetComponent<Image>().color = Color.red;
                Grid1_[10].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[14].GetComponent<Image>().color = Color.red;
                Grid1_[14].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

                break;
            case "6 Corners and Center":
                ResetTicket_1_();
                Grid1_[0].GetComponent<Image>().color = Color.red;
                Grid1_[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[4].GetComponent<Image>().color = Color.red;
                Grid1_[4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[5].GetComponent<Image>().color = Color.red;
                Grid1_[5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[7].GetComponent<Image>().color = Color.red;
                Grid1_[7].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[9].GetComponent<Image>().color = Color.red;
                Grid1_[9].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[10].GetComponent<Image>().color = Color.red;
                Grid1_[10].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[14].GetComponent<Image>().color = Color.red;
                Grid1_[14].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Reverse Twin":
                ResetTicket_1_();
                Grid1_[3].GetComponent<Image>().color = Color.red;
                Grid1_[3].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[4].GetComponent<Image>().color = Color.red;
                Grid1_[4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[9].GetComponent<Image>().color = Color.red;
                Grid1_[9].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[8].GetComponent<Image>().color = Color.red;
                Grid1_[8].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[13].GetComponent<Image>().color = Color.red;
                Grid1_[13].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[14].GetComponent<Image>().color = Color.red;
                Grid1_[14].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Early 5/Jaldi 5":
                ResetTicket_1_();
                List<int> unique_5_ = new List<int>();
                for (int k = 0; k < 5; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_5_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_5_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 6/Jaldi 6":
                ResetTicket_1_();
                List<int> unique_6_ = new List<int>();
                for (int k = 0; k < 6; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_6_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_6_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 7/Jaldi 7":
                ResetTicket_1_();
                List<int> unique_7_ = new List<int>();
                for (int k = 0; k < 7; k++)
                { 
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_7_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_7_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 8/Jaldi 8":
                ResetTicket_1_();
                List<int> unique_8_ = new List<int>();
                for (int k = 0; k < 8; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_8_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_8_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 9/Jaldi 9":
                ResetTicket_1_();
                List<int> unique_9_ = new List<int>();
                for (int k = 0; k < 9; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_9_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_9_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 10/Jaldi 10":
                ResetTicket_1_();
                List<int> unique_10_ = new List<int>();
                for (int k = 0; k < 10; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_10_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_10_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 11/Jaldi 11":
                ResetTicket_1_();
                List<int> unique_11_ = new List<int>();
                for (int k = 0; k < 11; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_11_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_11_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 12/Jaldi 12":
                ResetTicket_1_();
                List<int> unique_12_ = new List<int>();
                for (int k = 0; k < 12; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_12_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_12_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 13/Jaldi 13":
                ResetTicket_1_();
                List<int> unique_13_ = new List<int>();
                for (int k = 0; k < 13; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_13_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_13_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Early 14/Jaldi 14":
                ResetTicket_1_();
                List<int> unique_14_ = new List<int>();
                for (int k = 0; k < 14; k++)
                {
                    int rndm = UnityEngine.Random.Range(0, 15);
                    while (unique_14_.Contains(rndm))
                    {
                        rndm = UnityEngine.Random.Range(0, 15);
                    }
                    unique_14_.Add(rndm); // Add the generated number to the list of unique numbers
                    Grid1_[rndm].GetComponent<Image>().color = Color.red;
                    Grid1_[rndm].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "Breakfast":
                ResetTicket_1_();
                for (int i=0;i<Rows1_.Length;i++)
                {
                    for(int j = 0;j<3;j++)
                    {
                        Rows1_[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows1_[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Lunch":
                ResetTicket_1_();
                for (int i = 0; i < Rows1_.Length; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Rows1_[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows1_[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Dinner":
                ResetTicket_1_();
                for (int i = 0; i < Rows1_.Length; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Rows1_[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows1_[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Day || Jawani":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                    int n  = int.Parse(text);
                    if(n<=45)
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Night || Budhapa":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                    int n = int.Parse(text);
                    if (45 < n && n < 91)
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Center Laddu":
                ResetTicket_1_();
                Grid1_[7].GetComponent<Image>().color = Color.red;
                Grid1_[7].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;

            case "Bamboo":
                ResetTicket_1_();
                Grid1_[2].GetComponent<Image>().color = Color.red;
                Grid1_[2].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[7].GetComponent<Image>().color = Color.red;
                Grid1_[7].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[12].GetComponent<Image>().color = Color.red;
                Grid1_[12].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;

            case "Safe":
                ResetTicket_1_();
                for(int i =1;i<8;i++)
                {
                    Rows1_[1].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Fence":
                ResetTicket_1_();
                for (int i = 0; i < Rows1_.Length; i++)
                {
                    for (int j = 0; j < Rows1_[i].transform.childCount; j++)
                    {
                        Rows1_[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows1_[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                for (int i = 1; i < 8; i++)
                {
                    Rows1_[1].transform.GetChild(i).GetComponent<Image>().color = Color.white;
                    Rows1_[1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
                }
                break;
            case "First Half":
                ResetTicket_1_();
                int[] FH = { 0, 1, 2, 5, 6, 7, 10, 11, 12 };
                for(int i=0;i<FH.Length;i++)
                {
                    Grid1_[FH[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[FH[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Second Half":
                ResetTicket_1_();
                int[] SH = { 2, 3, 4, 7, 8, 9, 12, 13, 14 };
                for (int i = 0; i < SH.Length;i++)
                {
                    Grid1_[SH[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SH[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Shehnai Bidaai":
                ResetTicket_1_();
                int[] SB = { 0, 1, 2, 12, 13, 14 };
                for (int i = 0; i < SB.Length; i++)
                {
                    Grid1_[SB[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SB[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Brahma":
                ResetTicket_1_();
                for(int i=0;i<Grid1_.Length;i++)
                {
                    string text = Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                    int n = int.Parse(text);
                    if(n<=31)
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Vishnu":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                    int n = int.Parse(text);
                    if (30 < n && n >=60)
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Mahesh":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text;
                    int n = int.Parse(text);
                    if (n>=60)
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Drum":
                ResetTicket_1_();
                int[] Drum_number = {1,2,3,5,6,7,10,11,12 };
                for (int i = 0; i < Drum_number.Length; i++)
                {
                    Grid1_[Drum_number[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[Drum_number[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "ZIP":
                ResetTicket_1_();
                int[] ZIP = {1,2,7,13,14 };
                for (int i = 0; i < ZIP.Length; i++)
                {
                    Grid1_[ZIP[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[ZIP[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "ZAP":
                ResetTicket_1_();
                int[] ZAP = { 1,3,4 ,7,10,11};
                for (int i = 0; i < ZAP.Length; i++)
                {
                    Grid1_[ZAP[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[ZAP[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Letter C":
                ResetTicket_1_();
                for(int i = 0;i < 9;i++)
                {
                    Rows1_[0].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    Rows1_[2].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                Rows1_[1].transform.GetChild(0).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Letter I":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[0].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    Rows1_[2].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                Rows1_[1].transform.GetChild(4).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Letter D":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[0].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    Rows1_[2].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                Rows1_[1].transform.GetChild(0).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Rows1_[1].transform.GetChild(8).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(8).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "CID":
                ResetTicket_1_();
                int[] inta = {0,1,2,4,6,7,8 };
                for(int i = 0; i < inta.Length;i++)
                {
                    Rows1_[0].transform.GetChild(inta[i]).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(inta[i]).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    Rows1_[2].transform.GetChild(inta[i]).GetComponent<Image>().color = Color.red;
                    Rows1_[2].transform.GetChild(inta[i]).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                Rows1_[1].transform.GetChild(0).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Rows1_[1].transform.GetChild(4).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Rows1_[1].transform.GetChild(6).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(6).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Rows1_[1].transform.GetChild(8).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(8).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Letter H":
                ResetTicket_1_();
                int[] intb = { 0,8 };
                for (int i = 0; i < intb.Length; i++)
                {
                    Rows1_[0].transform.GetChild(intb[i]).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(intb[i]).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    Rows1_[2].transform.GetChild(intb[i]).GetComponent<Image>().color = Color.red;
                    Rows1_[2].transform.GetChild(intb[i]).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                for(int i = 0;i<9;i++)
                {
                    Rows1_[1].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
               
               
                break;
            case "Letter T":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[0].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                Rows1_[1].transform.GetChild(4).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Rows1_[2].transform.GetChild(4).GetComponent<Image>().color = Color.red;
                Rows1_[2].transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Letter L":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[2].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                Rows1_[1].transform.GetChild(0).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Rows1_[0].transform.GetChild(0).GetComponent<Image>().color = Color.red;
                Rows1_[0].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Digit 7":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[0].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                Rows1_[1].transform.GetChild(8).GetComponent<Image>().color = Color.red;
                Rows1_[1].transform.GetChild(8).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Rows1_[2].transform.GetChild(8).GetComponent<Image>().color = Color.red;
                Rows1_[2].transform.GetChild(8).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;

            case "Pyramid":
                ResetTicket_1_();
                Grid1_[2].GetComponent<Image>().color = Color.red;
                Grid1_[2].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[6].GetComponent<Image>().color = Color.red;
                Grid1_[6].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[8].GetComponent<Image>().color = Color.red;
                Grid1_[8].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[10].GetComponent<Image>().color = Color.red;
                Grid1_[10].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[12].GetComponent<Image>().color = Color.red;
                Grid1_[12].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[14].GetComponent<Image>().color = Color.red;
                Grid1_[14].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Reverse Pyramid":
                ResetTicket_1_();
                Grid1_[0].GetComponent<Image>().color = Color.red;
                Grid1_[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[2].GetComponent<Image>().color = Color.red;
                Grid1_[2].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[4].GetComponent<Image>().color = Color.red;
                Grid1_[4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[6].GetComponent<Image>().color = Color.red;
                Grid1_[6].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[8].GetComponent<Image>().color = Color.red;
                Grid1_[8].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[12].GetComponent<Image>().color = Color.red;
                Grid1_[12].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Circle":
                ResetTicket_1_();
                Grid1_[2].GetComponent<Image>().color = Color.red;
                Grid1_[2].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[6].GetComponent<Image>().color = Color.red;
                Grid1_[6].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[8].GetComponent<Image>().color = Color.red;
                Grid1_[8].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[12].GetComponent<Image>().color = Color.red;
                Grid1_[12].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "All Even":
                ResetTicket_1_();
                for(int i =0;i < Grid1_.Length;i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                    if (n%2==0)
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "All Odd":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                    if (n % 2 != 0)
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Eclipse":
                ResetTicket_1_();
                int[] intc = {1,2,3,5,9,11,12,13 };
                for(int i = 0; i < intc.Length;i++)
                {
                    Grid1_[intc[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[intc[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Plus":
                ResetTicket_1_();
                int[] intd = { 2,6,7,8,12 };
                for (int i = 0; i < intd.Length; i++)
                {
                    Grid1_[intd[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[intd[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Temp / BP":
                ResetTicket_1_();
                int[] inte = new int[15];
                int min = int.Parse(Grid1_[0].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                int max = int.Parse(Grid1_[0].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                int minIndex = 0;
                int maxIndex = 0;
                for(int i = 0;i<Grid1_.Length;i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                    if (n < min)
                    {
                        min = n;
                        minIndex = i;
                    }
                    if(n > max)
                    {
                        max = n;
                        maxIndex = i;
                    }
                }

                Grid1_[minIndex].GetComponent<Image>().color = Color.red;
                Grid1_[minIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Grid1_[maxIndex].GetComponent<Image>().color = Color.red;
                Grid1_[maxIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                break;
            case "Double Temp":
                ResetTicket_1_();
                int[] highestNumbers = new int[2];
                int[] lowestNumbers = new int[2];

                // Assign values to the inte array

                 min = int.Parse(Grid1_[0].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                 max = int.Parse(Grid1_[0].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                 minIndex = 0;
                 maxIndex = 0;

                for (int i = 0; i < Grid1_.Length; i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                    if (n < min)
                    {
                        min = n;
                        minIndex = i;
                    }
                    if (n > max)
                    {
                        max = n;
                        maxIndex = i;
                    }
                }

                lowestNumbers[0] = min;
                highestNumbers[0] = max;

                Grid1_[maxIndex].GetComponent<Image>().color = Color.red;
                Grid1_[maxIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

                Grid1_[minIndex].GetComponent<Image>().color = Color.red;
                Grid1_[minIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

                minIndex = maxIndex = 0;
                min = int.MaxValue;
                max = int.MinValue;

                for (int i = 0; i < Grid1_.Length; i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                    if (n < min && n != lowestNumbers[0])
                    {
                        min = n;
                        minIndex = i;
                    }
                    if (n > max && n != highestNumbers[0])
                    {
                        max = n;
                        maxIndex = i;
                    }
                }

                lowestNumbers[1] = min;
                highestNumbers[1] = max;

                // Highlighting the highest and lowest numbers in Grid1_

                Grid1_[maxIndex].GetComponent<Image>().color = Color.red;
                Grid1_[maxIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

                Grid1_[minIndex].GetComponent<Image>().color = Color.red;
                Grid1_[minIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;


                break;
            case "Triple Temp":
                 ResetTicket_1_();
                 highestNumbers = new int[3];
                 lowestNumbers = new int[3];

                // Assign values to the int array

                int[] numbers = new int[Grid1_.Length];
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    numbers[i] = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                }

                Array.Sort(numbers); // Sort the numbers array in ascending order

                // Assign the three smallest numbers to lowestNumbers array
                for (int i = 0; i < 3; i++)
                {
                    lowestNumbers[i] = numbers[i];
                }

                // Assign the three largest numbers to highestNumbers array
                int numbersLength = numbers.Length;
                for (int i = 0; i < 3; i++)
                {
                    highestNumbers[i] = numbers[numbersLength - 1 - i];
                }

                // Highlighting the three highest and three lowest numbers in Grid1_
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);

                    if (lowestNumbers.Contains(n))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    else if (highestNumbers.Contains(n))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }


                break;

            case "5 Min 5 Max":
                ResetTicket_1_();
                 highestNumbers = new int[5];
                 lowestNumbers = new int[5];

                // Assign values to the int array

                 numbers = new int[Grid1_.Length];
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    numbers[i] = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                }

                Array.Sort(numbers); // Sort the numbers array in ascending order

                // Assign the five smallest numbers to lowestNumbers array
                for (int i = 0; i < 5; i++)
                {
                    lowestNumbers[i] = numbers[i];
                }

                // Assign the five largest numbers to highestNumbers array
                 numbersLength = numbers.Length;
                for (int i = 0; i < 5; i++)
                {
                    highestNumbers[i] = numbers[numbersLength - 1 - i];
                }

                // Highlighting the five highest and five lowest numbers in Grid1_
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);

                    if (lowestNumbers.Contains(n))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    else if (highestNumbers.Contains(n))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }

                break;

            case "5 Minimum":
                ResetTicket_1_();
                lowestNumbers = new int[5];

                // Assign values to the int array

                numbers = new int[Grid1_.Length];
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    numbers[i] = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                }

                Array.Sort(numbers); // Sort the numbers array in ascending order

                // Assign the five smallest numbers to lowestNumbers array
                for (int i = 0; i < 5; i++)
                {
                    lowestNumbers[i] = numbers[i];
                }

                // Assign the five largest numbers to highestNumbers array
                numbersLength = numbers.Length;
               

                // Highlighting the five highest and five lowest numbers in Grid1_
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);

                    if (lowestNumbers.Contains(n))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                   
                }
                break;

            case "5 Max Number":
                ResetTicket_1_();
                highestNumbers = new int[5];
               

                // Assign values to the int array

                numbers = new int[Grid1_.Length];
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    numbers[i] = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);
                }

                Array.Sort(numbers); // Sort the numbers array in ascending order

                // Assign the five smallest numbers to lowestNumbers array
               

                // Assign the five largest numbers to highestNumbers array
                numbersLength = numbers.Length;
                for (int i = 0; i < 5; i++)
                {
                    highestNumbers[i] = numbers[numbersLength - 1 - i];
                }

                // Highlighting the five highest and five lowest numbers in Grid1_
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    int n = int.Parse(Grid1_[i].transform.GetComponentInChildren<TextMeshProUGUI>().text);

                     if (highestNumbers.Contains(n))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }

                break;

            case "Anda":
                ResetTicket_1_();
                for(int i=0;i<Grid1_.Length;i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if(text.Contains("0"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Danda":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("1"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Anda Danda":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("0") || text.Contains("1"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "5 Pandav":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("5"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Hockey Stick":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("7"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Fat Lady":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("8"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Ugly Duckling":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("2"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Naughty 6 & 9":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("6") || text.Contains("9"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "26 January":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string text = Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().text;
                    if (text.Contains("2") || text.Contains("6"))
                    {
                        Grid1_[i].GetComponent<Image>().color = Color.red;
                        Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "1 Pair (Row)":
                ResetTicket_1_();
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    string name1 = Grid1_[i].gameObject.name;
                    string name2 = Grid1_[i + 1].gameObject.name;
                    int openingParenthesisIndex = name1.IndexOf('(');

                    // Find the closing parenthesis index
                    int closingParenthesisIndex = name1.IndexOf(')');

                    if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                    {
                        // Extract the substring between the parentheses
                        string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                        string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                        // Convert the extracted string to an integer
                        int number1;
                        int number2;
                        number1 = int.Parse(numberString1);
                        number2 = int.Parse(numberString2);
                        if(number1 +1 == number2)
                        {
                            Grid1_[i].GetComponent<Image>().color = Color.red;
                            Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                            Grid1_[i+1].GetComponent<Image>().color = Color.red;
                            Grid1_[i+1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                            break;
                        }
                    }
                }
                    break;
            case "2 Pair (Row)":
                ResetTicket_1_();
                int count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i != 14)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 1].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 + 1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 1].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 2)
                                        break; // Breaks out of the outer loop
                                }
                            }
                        }
                    }
                }
                break;
            case "3 Pair (Row)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i != 14)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 1].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 + 1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 1].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 3)
                                        break; // Breaks out of the outer loop
                                }
                            }
                        }
                    }
                }
                break;
            case "4 Pair (Row)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i != 14)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 1].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 + 1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 1].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 4)
                                        break; // Breaks out of the outer loop
                                }
                            }
                        }
                    }
                }
                break;
            case "All Pair (Row)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i != 14)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 1].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 + 1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 1].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                   
                                }
                            }
                        }
                    }
                }
                break;

            case "1 Pair (Column)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i < 10)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 5].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 5].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case "2 Pair (Column)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i < 10)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 5].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 5].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 2)
                                        break; // Breaks out of the outer loop
                                }
                            }
                        }
                    }
                }
                break;
            case "3 Pair (Column)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i < 10)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 4].gameObject.name;
                        string name3 = Grid1_[i + 5].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString3 = name3.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            int number3;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 4].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 3)
                                        break; // Breaks out of the outer loop
                                }

                            }
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString3, out number3))
                            {
                                if (number1 == number3)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 5].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 3)
                                        break; // Breaks out of the outer loop
                                }

                            }
                        }
                    }
                }
                break;
            case "4 Pair (Column)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i < 10)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 4].gameObject.name;
                        string name3 = Grid1_[i + 5].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString3 = name3.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            int number3;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 4].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 4)
                                        break; // Breaks out of the outer loop
                                }

                            }
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString3, out number3))
                            {
                                if (number1 == number3)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 5].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    if (count == 4)
                                        break; // Breaks out of the outer loop
                                }

                            }
                        }
                    }
                }
                break;
            case "All Pair (Column)":
                ResetTicket_1_();
                count = 0;
                for (int i = 0; i < Grid1_.Length; i++)
                {
                    if (i < 10)
                    {
                        string name1 = Grid1_[i].gameObject.name;
                        string name2 = Grid1_[i + 4].gameObject.name;
                        string name3 = Grid1_[i + 5].gameObject.name;
                        int openingParenthesisIndex = name1.IndexOf('(');

                        // Find the closing parenthesis index
                        int closingParenthesisIndex = name1.IndexOf(')');

                        if (openingParenthesisIndex != -1 && closingParenthesisIndex != -1)
                        {
                            // Extract the substring between the parentheses
                            string numberString1 = name1.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString2 = name2.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);
                            string numberString3 = name3.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                            // Convert the extracted string to an integer
                            int number1;
                            int number2;
                            int number3;
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString2, out number2))
                            {
                                if (number1 == number2)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 4].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 4].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;
                                    
                                }

                            }
                            if (int.TryParse(numberString1, out number1) && int.TryParse(numberString3, out number3))
                            {
                                if (number1 == number3)
                                {
                                    Grid1_[i].GetComponent<Image>().color = Color.red;
                                    Grid1_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    Grid1_[i + 5].GetComponent<Image>().color = Color.red;
                                    Grid1_[i + 5].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                                    count++;

                                }

                            }
                        }
                    }
                }
                break;
            case "Third Line / Last Line":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[2].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[2].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "First / Top Line":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[0].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[0].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Second / Middle Line":
                ResetTicket_1_();
                for (int i = 0; i < 9; i++)
                {
                    Rows1_[1].transform.GetChild(i).GetComponent<Image>().color = Color.red;
                    Rows1_[1].transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Super 12":
                List<GameObject> value = new List<GameObject>();
                int[] a = {0,3,6,9,12,15 };
                for(int x = 0; x < a.Length; x++)
                {
                    for (int i = a[x]; i < a[x] + 3; i++)
                    {
                        GameObject row = Rows[i];
                        for (int j = 0; j < 9; j++)
                        {
                            string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                            if (text != "")
                            {
                                value.Add(row.transform.GetChild(j).gameObject);
                            }
                        }

                    }

                    for (int i = 0; i < 2; i++)
                    {
                        int random = UnityEngine.Random.Range(0, value.Count);
                        GameObject markedGameobject = value[random];
                        value.RemoveAt(random);
                        markedGameobject.GetComponent<Image>().color = Color.red;
                        markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    value.Clear();
                }

               break;

            case "Super 18":
                List<GameObject> value1Super18 = new List<GameObject>(); // Renamed variable
                int[] bSuper18 = { 0, 3, 6, 9, 12, 15 };
                for (int x = 0; x < bSuper18.Length; x++)
                {
                    for (int i = bSuper18[x]; i < bSuper18[x] + 3; i++)
                    {
                        GameObject row = Rows[i];
                        for (int j = 0; j < 9; j++)
                        {
                            string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                            if (text != "")
                            {
                                value1Super18.Add(row.transform.GetChild(j).gameObject);
                            }
                        }
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        int random = UnityEngine.Random.Range(0, value1Super18.Count);
                        GameObject markedGameobject = value1Super18[random];
                        value1Super18.RemoveAt(random);
                        markedGameobject.GetComponent<Image>().color = Color.red;
                        markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    value1Super18.Clear();
                }
                break;

            case "Super 24":
                List<GameObject> value1Super24 = new List<GameObject>(); // Renamed variable
                int[] bSuper24 = { 0, 3, 6, 9, 12, 15 };
                for (int x = 0; x < bSuper24.Length; x++)
                {
                    for (int i = bSuper24[x]; i < bSuper24[x] + 3; i++)
                    {
                        GameObject row = Rows[i];
                        for (int j = 0; j < 9; j++)
                        {
                            string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                            if (text != "")
                            {
                                value1Super24.Add(row.transform.GetChild(j).gameObject);
                            }
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        int random = UnityEngine.Random.Range(0, value1Super24.Count);
                        GameObject markedGameobject = value1Super24[random];
                        value1Super24.RemoveAt(random);
                        markedGameobject.GetComponent<Image>().color = Color.red;
                        markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    value1Super24.Clear();
                }
                break;
           

            case "Super 30":
                List<GameObject> value1Super30 = new List<GameObject>();
                int[] bSuper30 = { 0, 3, 6, 9, 12, 15 };
                for (int x = 0; x < bSuper30.Length; x++)
                {
                    for (int i = bSuper30[x]; i < bSuper30[x] + 3; i++)
                    {
                        GameObject row = Rows[i];
                        for (int j = 0; j < 9; j++)
                        {
                            string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                            if (text != "")
                            {
                                value1Super30.Add(row.transform.GetChild(j).gameObject);
                            }
                        }
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        int random = UnityEngine.Random.Range(0, value1Super30.Count);
                        GameObject markedGameobject = value1Super30[random];
                        value1Super30.RemoveAt(random);
                        markedGameobject.GetComponent<Image>().color = Color.red;
                        markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    value1Super30.Clear();
                }
                break;
            case "Super 36":
                List<GameObject> value1Super36 = new List<GameObject>();
                int[] bSuper36 = { 0, 3, 6, 9, 12, 15 };
                for (int x = 0; x < bSuper36.Length; x++)
                {
                    for (int i = bSuper36[x]; i < bSuper36[x] + 3; i++)
                    {
                        GameObject row = Rows[i];
                        for (int j = 0; j < 9; j++)
                        {
                            string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                            if (text != "")
                            {
                                value1Super36.Add(row.transform.GetChild(j).gameObject);
                            }
                        }
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        int random = UnityEngine.Random.Range(0, value1Super36.Count);
                        GameObject markedGameobject = value1Super36[random];
                        value1Super36.RemoveAt(random);
                        markedGameobject.GetComponent<Image>().color = Color.red;
                        markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    value1Super36.Clear();
                }
                break;

            case "Super 42":
                List<GameObject> value1Super42 = new List<GameObject>();
                int[] bSuper42 = { 0, 3, 6, 9, 12, 15 };
                for (int x = 0; x < bSuper42.Length; x++)
                {
                    for (int i = bSuper42[x]; i < bSuper42[x] + 3; i++)
                    {
                        GameObject row = Rows[i];
                        for (int j = 0; j < 9; j++)
                        {
                            string text = row.transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text;
                            if (text != "")
                            {
                                value1Super42.Add(row.transform.GetChild(j).gameObject);
                            }
                        }
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        int random = UnityEngine.Random.Range(0, value1Super42.Count);
                        GameObject markedGameobject = value1Super42[random];
                        value1Super42.RemoveAt(random);
                        markedGameobject.GetComponent<Image>().color = Color.red;
                        markedGameobject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                    value1Super42.Clear();
                }
                break;
            case "Sheet Queen Corners":
                ResetTicket_6_();

                for (int i = 0; i < Grid6_.Length;i+=5)
                {
                    Grid6_[i].GetComponent<Image>().color = Color.red;
                    Grid6_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break; 
            case "Sheet King Corners":
                ResetTicket_6_();

                for (int i = 4; i < Grid6_.Length;i+=5)
                {
                    Grid6_[i].GetComponent<Image>().color = Color.red;
                    Grid6_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;

            case "Sheet Corners":
                ResetTicket_6_();
                int[] number = {0,4,10,14,15,19,25,29,30,34,40,44,45,49,55,59,60,64,70,74,75,79,85,89 };
                for(int i = 0;i< number.Length;i++)
                {
                    Grid6_[number[i]].GetComponent<Image>().color = Color.red;
                    Grid6_[number[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Beginners 6":
                ResetTicket_6_();
                for (int i = 0; i < Grid6_.Length; i += 15)
                {
                    Grid6_[i].GetComponent<Image>().color = Color.red;
                    Grid6_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Finishers 6":
                ResetTicket_6_();
                for (int i = 14; i < Grid6_.Length; i += 15)
                {
                    Grid6_[i].GetComponent<Image>().color = Color.red;
                    Grid6_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Sheet Bull Eyes":
                ResetTicket_6_();
                for (int i =7; i < Grid6_.Length; i += 15)
                {
                    Grid6_[i].GetComponent<Image>().color = Color.red;
                    Grid6_[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "8 Corners":
                ResetTicket_6_();
                int[] C_8 = {0,4,40,44,45,49,85,89 };
                for (int i = 0; i < C_8.Length; i++)
                {
                    Grid6_[C_8[i]].GetComponent<Image>().color = Color.red;
                    Grid6_[C_8[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "4 Corners":
                ResetTicket_6_();
                int[] C_4 = { 0, 4, 40, 44, 45, 49, 85, 89 };
                for (int i = 0; i < C_4.Length; i++)
                {
                    Grid6_[C_4[i]].GetComponent<Image>().color = Color.red;
                    Grid6_[C_4[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "I Love You 143":
                ResetTicket_1_();
                int[] SN_1 = { 0,5,6,7,8,10,11,12};
                for(int i=0;i<SN_1.Length;i++)
                {
                    Grid1_[SN_1[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_1[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            case "We Love You 243":
                ResetTicket_1_();
                int[] SN_2 = { 0,1,5,6,7,8,10,11,12 };
                for (int i = 0; i < SN_2.Length; i++)
                {
                    Grid1_[SN_2[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_2[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Love You Too 433":

                ResetTicket_1_();
                int[] SN_3 = { 0,1,2,3,5,6,7,10,11,12 };
                for (int i = 0; i < SN_3.Length; i++)
                {
                    Grid1_[SN_3[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_3[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "You And Me 332":
                ResetTicket_1_();
                int[] SN_4 = { 0,1,2,5,6,7,10,11 };
                for (int i = 0; i < SN_4.Length; i++)
                {
                    Grid1_[SN_4[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_4[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "124":
                ResetTicket_1_();
                int[] SN_5 = { 0,5,6,10,11,12,13 };
                for (int i = 0; i < SN_5.Length; i++)
                {
                    Grid1_[SN_5[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_5[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "421":
                ResetTicket_1_();
                int[] SN_6 = { 0, 1, 2, 3, 5, 6, 10 };
                for (int i = 0; i < SN_6.Length; i++)
                {
                    Grid1_[SN_6[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_6[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "225":
                ResetTicket_1_();
                int[] SN_7 = { 0, 1, 5, 6, 10, 11, 12, 13, 14 };
                for (int i = 0; i < SN_7.Length; i++)
                {
                    Grid1_[SN_7[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_7[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Work From Home 444":
                ResetTicket_1_();
                int[] SN_8 = { 0,1,2,3,5,6,7,8,10,11,12,13};
                for (int i = 0; i < SN_8.Length; i++)
                {
                    Grid1_[SN_8[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_8[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Stay At Home 424":
                ResetTicket_1_();
                int[] SN_9 = { 0, 1, 2, 3, 5, 6,  10, 11, 12, 13 };
                for (int i = 0; i < SN_9.Length; i++)
                {
                    Grid1_[SN_9[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_9[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "123":
                ResetTicket_1_();
                int[] SN_10 = { 0, 5, 6, 10, 11, 12 };
                for (int i = 0; i < SN_10.Length; i++)
                {
                    Grid1_[SN_10[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_10[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "333":
                ResetTicket_1_();
                int[] SN_11 = { 0, 1, 2, 5, 6, 7,  10, 11, 12 };
                for (int i = 0; i < SN_11.Length; i++)
                {
                    Grid1_[SN_11[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_11[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Jai Shree Ram 353":
                ResetTicket_1_();
                int[] SN_12 = { 0, 1, 2, 5, 6, 7, 8,9, 10, 11, 12};
                for (int i = 0; i < SN_12.Length; i++)
                {
                    Grid1_[SN_12[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_12[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "4 2 ka 1(Reverse)":
                ResetTicket_1_();
                int[] SN_13 = { 1,2,3,4,8,9,14 };
                for (int i = 0; i < SN_13.Length; i++)
                {
                    Grid1_[SN_13[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_13[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "333(reverse)":
                ResetTicket_1_();
                int[] SN_131 = { 2,3,4,7,8,9,12,13,14 };
                for (int i = 0; i < SN_131.Length; i++)
                {
                    Grid1_[SN_131[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_131[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "3 2 ka 1 (Reverse)":
                ResetTicket_1_();
                int[] SN_14 = { 2,3,4,8,9,14 };
                for (int i = 0; i < SN_14.Length; i++)
                {
                    Grid1_[SN_14[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_14[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "2Wear Mask25":
                ResetTicket_1_();
                int[] SN_15 = { 0,4,6,7,8,10,14};
                for (int i = 0; i < SN_15.Length; i++)
                {
                    Grid1_[SN_15[i]].GetComponent<Image>().color = Color.red;
                    Grid1_[SN_15[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                break;
            case "Ticket #1 House":
                for(int i=0; i < 3;i++)
                {
                    for(int j=0; j < 9;j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Ticket #2 House":
                for (int i = 3; i < 6; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Ticket #3 House":
                for (int i = 6; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Ticket #4 House":
                for (int i = 9; i < 12; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Ticket #5 House":
                for (int i = 12; i < 15; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Ticket #6 House":
                for (int i = 15; i < 18; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Odd Houses(#1,#3,#5)":
                int[] c = { 0, 6, 12 };
                for(int i = 0; i < c.Length;i++)
                {
                    for(int j = c[i]; j < c[i]+3;j++)
                    {
                        for (int k = 0;  k< 9; k++)
                        {
                            Rows[j].transform.GetChild(k).GetComponent<Image>().color = Color.red;
                            Rows[j].transform.GetChild(k).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                        }
                    }
                }
                break;
            case "Even Houses(#2,#4,#6)":
                int[] d = { 3, 9, 15 };
                for (int i = 0; i < d.Length; i++)
                {
                    for (int j = d[i]; j < d[i] + 3; j++)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            Rows[j].transform.GetChild(k).GetComponent<Image>().color = Color.red;
                            Rows[j].transform.GetChild(k).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                        }
                    }
                }
                break;
            case "Top 3 Houses":
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Bottom 3 Houses":
                for (int i = 9; i < 18; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Outer Houses(#1 & #6)":
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                for (int i = 15; i < 17; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Inner Houses(#3 & #4)":
                for (int i = 6; i < 12; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
               
                break;
            case "Top 2 Houses(#1 & #12)":
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;
            case "Bottom 2 Houses(#5 & #6)":
                for (int i = 12; i < 18; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Rows[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;

            case "House":
                ResetTicket_1_();
                for(int i = 0;i<3;i++)
                {
                    for(int j = 0; j < 9;j++)
                    {
                        Rows1_[i].transform.GetChild(j).GetComponent<Image>().color = Color.red;
                        Rows1_[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    }
                }
                break;

        }
    }

    public void backbutton()
    {
        ResetTicket_1_();
        TicketInBlockPanel.SetActive(false);
        for(int i = 0;i< Rows.Length;i++)
        {
            for(int j = 0; j<9; j++)
            {
                Rows[i].transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.white;
                Rows[i].transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }
    }
}
