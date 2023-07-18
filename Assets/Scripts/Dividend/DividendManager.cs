using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DividendManager : MonoBehaviour
{
    public GameObject DividendBlockPrefab;
    public GameObject DividendChildBlockPrefab;

    public List<string> DividendBlockNames = new List<string> {"18 BLOCKS", "18 lines" , "6 (Early 5/ Lucky 5" , "Special Lines" , "Corners" ,
                                                                "Early/Jaldi/Quickly/Lucky" , "Extra"  , "Letters/Worlds" , "Math" ,
                                                                "Min - Max /Temperature/BP" , "All Number Start & End With" , "Pairs" ,
                                                                "Row/Line" , "Super Numbers" , "Sheet Corners" , "Special Numbers" , "Special Houses",
                                                                "House"
    };

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
                            "Ticket #1:Early 5", "Ticket #2:Early 5","Ticket #3:Early 5","Ticket #4:Early 5","Ticket #5:Early 5"
                          }
        },
        { 3 , new string[] { 
                               "All 6 Top Lines","All 6 Middle Lines","All 6 Last Lines","Outer Lines(#1 & #18)","Inner Lines(#9 & #10)"
                           }
        }, 
        { 4 , new string[] { "4 Corner","King Corners","Queen Corners","4 Corner and Center","Bulls Eyes",
                             "Twin Lines","6 Corners","6 Corners and Center","Reverse Twin"
                           }
        },
        { 5 , new string[] { "Early 5/Jaldi 5","Early 6/Jaldi 6","Early 7/Jaldi 7","Early 8/Jaldi 8","Early 9/Jaldi 9",
                             "Early 10/Jaldi 10","Early 11/Jaldi 11","Early 12/Jaldi 12","Early 13/Jaldi 13","Early 14/Jaldi 14"
                           }
        },
        { 6 , new string[] { "Breakfast","Lunch","Dinner","Day || Jawani","Night || Budhapa","Center Laddu","Bamboo","Safe","Fence","First Half","Sencond Half",
                             "Shehnai Bidaai","Brahma","Vishnu","Mahesh","Railway Truck","Drum","ZIP","ZAP"
                           }
        },
        { 7 , new string[] { "Letter C","Letter I","Letter D","CID","Letter H","Letter T","Letter L","Digit 7"
                            
                            }
        },
        { 8 , new string[]
                            {
                                "Pyramid","Reverse Pyramid","Circle","All Even","All Odd","Eclipse","Plus"
                            }
        },
        { 9 , new string[]
                            {
                                "Temp / BP","Double Temp","Triple Temp","5 Min 5 Max","5 Minimum","5 Max Number"
                            }
        },
        { 10 , new string[]
                            {
                                "Anda","Danda","Anda Danda","5 Pandav","Hockey Stick","Fat Lady","Ugly Duckling","Naughty 6 & 9","26 January"
                            }
        },
        { 11 , new string[]
                            {
                                "1 Pair (Row)","2 Pair (Row)","3 Pair (Row)","4 Pair (Row)","All Pair (Row)",
                                "1 Pair (Column)","2 Pair (Column)","3 Pair (Column)","4 Pair (Column)","All Pair (Column)"
                            }
        },
        { 12 , new string[]
                            {
                                "First / Top Line","Second / Middle Line","Third Line / Last Line"

                            } 
        },
        { 13, new string[]
                            {
                               "Super 12","Super 18","Super 24","Super 30","Super 36","Super 42"
                            } 
        },
        {14 ,new string[]
                            {
                                "Sheet Queen Corners","Sheet King Corners","Sheet Corners",
                                "Beginners 6","Finishers 6","Sheet Bull Eyes","8 Corners","4 Corners"
                            } 
        },
        { 15 , new string[]
                            {
                                "I Love You 143","We Love You 243","Love You Too 433","You And Me 332","124","421","225","Work From Home 444",
                                "Stay At Home 424","123","333","Jai Shree Ram 353","4 2 ka 1(Reverse)","333(reverse)","3 2 ka 1 (Reverse)","Wear Mask"
                            }
        },
        { 16 , new string[]
                            {
                                "Ticket #1 House","Ticket #2 House","Ticket #3 House","Ticket #4 House","Ticket #5 House","Ticket #6 House",
                                "Odd Houses(#1,#3,#5)","Even Houses(#2,#4,#6)","Top 3 Houses","Bottom 3 Houses","Outer Houses(#1 & #6)",
                                "Inner Houses(#3 & #4)","Top 2 Houses(#1 & #12)","Bottom 2 Houses(#5 & #6)"
                            }
        },
        { 17 , new string[]
                            {
                                "House"
                            }
        }


    };

    private void Start()
    {
        Debug.Log(gameObject.name);

        for(int i = 0; i < DividendBlockNames.Count; i++)
        {
           GameObject go= Instantiate(DividendBlockPrefab,gameObject.transform);
            go.gameObject.name = DividendBlockNames[i];
            go.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = DividendBlockNames[i];
           // go.transform.SetAsLastSibling();
            int count = DividendChildBlockNames[i].Length;
            for (int j = 0; j < count; j++)
            {
                GameObject gochild = Instantiate(DividendChildBlockPrefab, gameObject.transform);
                //gochild.transform.SetAsLastSibling();
                gochild.gameObject.name = DividendChildBlockNames[i][j];
                gochild.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = DividendChildBlockNames[i][j];
            }
            
        }

        
    }


}
