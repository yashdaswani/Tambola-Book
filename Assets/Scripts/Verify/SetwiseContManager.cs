using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetwiseContManager : MonoBehaviour
{
    public GameObject childPrefab;
    public static SetwiseContManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public Dictionary<int, string[]> DividendChildBlockNames = new Dictionary<int, string[]>
    {
         { 0, new string[]  { "Block 1 / Breakfast 1","Block 2 / Lunch 1","Block 3 / Dinner 1",
                             "Block 4 / Breakfast 2","Block 5 / Lunch 2","Block 6 / Dinner 2",
                             "Block 7 / Breakfast 3","Block 8 / Lunch 3","Block 9 / Dinner 3",
                             "Block 10 / Breakfast 4","Block 11 / Lunch 4","Block 12 / Dinner 4",
                             "Block 13 / Breakfast 5","Block 14 / Lunch 5","Block 15 / Dinner 5",
                             "Block 16 / Breakfast 6","Block 17 / Lunch 6","Block 18 / Dinner 6"
                           }
        },
        { 1, new string[]  { "Line1","Line2","Line3","Line4","Line5","Line6","Line7","Line8","Line9",
                             "Line10","Line11","Line12","Line13","Line14","Line15","Line16","Line17","Line18"
                           }
        },

        { 2, new string[] {
                            "Ticket #1:Early 5", "Ticket #2:Early 5","Ticket #3:Early 5","Ticket #4:Early 5","Ticket #5:Early 5","Ticket #6:Early 5"
                          }
        },
        { 3 , new string[] {
                               "All 6 Top Lines","All 6 Middle Lines","All 6 Last Lines","Outer Lines(#1 & #18)","Inner Lines(#9 & #10)"
                           }
        },
        { 4, new string[]
                            {
                               "Super 12","Super 18","Super 24","Super 30","Super 36","Super 42"
                            }
        },
        {5 ,new string[]
                            {
                                "Sheet Queen Corners","Sheet King Corners","Sheet Corners",
                                "Beginners 6","Finishers 6","Sheet Bull Eyes","8 Corners","4 Corners"
                            }
        },
        { 6 , new string[]
                            {
                                "Ticket #1 House","Ticket #2 House","Ticket #3 House","Ticket #4 House","Ticket #5 House","Ticket #6 House",
                                "Odd Houses(#1,#3,#5)","Even Houses(#2,#4,#6)","Top 3 Houses","Bottom 3 Houses","Outer Houses(#1 & #6)",
                                "Inner Houses(#3 & #4)","Top 2 Houses(#1 & #2)","Bottom 2 Houses(#5 & #6)"
                            }
        },
    };


    void Start()
    {
        InitializeChildDividend();
    }

    private void Update()
    {

    }


    public void InitializeChildDividend()
    {
        

        for (int i = 0; i < 7; i++)
        {
            GameObject DividendPrefab = gameObject.transform.GetChild(i).gameObject;
            GameObject childCont = DividendPrefab.transform.GetChild(1).gameObject;
            childCont.SetActive(false);
            for (int j = 0; j < DividendChildBlockNames[i].Length; j++)
            {
                GameObject go = Instantiate(childPrefab, childCont.transform);
                go.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = DividendChildBlockNames[i][j];
                go.name = DividendChildBlockNames[i][j];
            }

        }

       

    }

    public void Changeinsetwise()
    {
        RectTransform rectTransform = VerifyUI.instance.SetwiseCont.GetComponent<RectTransform>();
        
        if (VerifyUI.instance.currentToggleIndex == 0)
        {
            for (int i = 0; i < 7; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }


            VerifyUI.instance.setwiseText.text = "SETWISE GAME : (0 Tickets)";
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 5f);
            }
            VerifyUI.instance.setwiseTextDesc.text = "";
            return;
        }


        if (VerifyUI.instance.currentToggleIndex == 1)
        {
            int[] active = { 6, 6, 2 ,2};
            for (int i = 0; i < 3; i++)
            {
                GameObject DividendPrefab = gameObject.transform.GetChild(i).gameObject;
                DividendPrefab.SetActive(true);
                for(int j = 0;j<DividendPrefab.transform.GetChild(1).childCount;j++)
                {
                    DividendPrefab.transform.GetChild(1).GetChild(j).gameObject.SetActive(false);
                }
                for(int j = 0; j < active[i];j++)
                {
                    GameObject childCont = DividendPrefab.transform.GetChild(1).gameObject;
                    childCont.transform.GetChild(j).gameObject.SetActive(true);
                }
            }
            gameObject.transform.GetChild(6).gameObject.SetActive(true);
            for(int i = 0; i < gameObject.transform.GetChild(6).GetChild(1).childCount;i++)
            {
                gameObject.transform.GetChild(6).GetChild(1).GetChild(i).gameObject.SetActive(false);

            }
                gameObject.transform.GetChild(6).GetChild(1).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(true);

            for (int i = 3; i < 6; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

            VerifyUI.instance.setwiseText.text = "SETWISE GAME : (2 Tickets)";
            
        }

        if (VerifyUI.instance.currentToggleIndex == 2)
        {
            int[] active = { 9, 9, 3 ,3,3,3,2};
            for (int i = 0; i < 7; i++)
            {
                GameObject DividendPrefab = gameObject.transform.GetChild(i).gameObject;
                DividendPrefab.SetActive(true);
                for (int j = 0; j < DividendPrefab.transform.GetChild(1).childCount; j++)
                {
                    DividendPrefab.transform.GetChild(1).GetChild(j).gameObject.SetActive(false);
                }
                for (int j = 0; j < active[i]; j++)
                {
                    GameObject childCont = DividendPrefab.transform.GetChild(1).gameObject;
                    childCont.transform.GetChild(j).gameObject.SetActive(true);
                }
            }
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            VerifyUI.instance.setwiseText.text = "SETWISE GAME : (3 Tickets)";
        }

        if (VerifyUI.instance.currentToggleIndex == 3)
        {
            for (int i = 0; i < 7; i++)
            {
                GameObject DividendPrefab = gameObject.transform.GetChild(i).gameObject;
                DividendPrefab.SetActive(true);
                for (int j = 0; j < DividendPrefab.transform.GetChild(1).childCount; j++)
                {
                    DividendPrefab.transform.GetChild(1).GetChild(j).gameObject.SetActive(true);
                }
            }
            VerifyUI.instance.setwiseText.text = "SETWISE GAME : (6 Tickets)";

        }
       
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 200f);
        }
        VerifyUI.instance.DividendPerTicketTextPanel.text = VerifyUI.instance.DividendPerTicketText.text;
        VerifyUI.instance.setwiseTextDesc.text = VerifyUI.instance.DividendPerSetText.text + "\n + \n " + VerifyUI.instance.HousePerSetText.text + "\n + \n " + VerifyUI.instance.SheetDividendPerSetText.text;
    }


}
