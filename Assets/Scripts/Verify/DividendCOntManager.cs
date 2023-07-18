using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class DividendCOntManager : MonoBehaviour
{
    public GameObject childPrefab;
    public Dictionary<int, string[]> DividendChildBlockNames = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "4 Corner","King Corners","Queen Corners","4 Corner and Center","Bulls Eyes",
                             "Twin Lines","6 Corners","6 Corners and Center","Reverse Twin"
                           }
        },
        { 1 , new string[] { "Early 5/Jaldi 5","Early 6/Jaldi 6","Early 7/Jaldi 7","Early 8/Jaldi 8","Early 9/Jaldi 9",
                             "Early 10/Jaldi 10","Early 11/Jaldi 11","Early 12/Jaldi 12","Early 13/Jaldi 13","Early 14/Jaldi 14"
                           }
        },
        { 2 , new string[] { "Breakfast","Lunch","Dinner","Day || Jawani","Night || Budhapa","Center Laddu","Bamboo","Safe","Fence","First Half","Sencond Half",
                             "Shehnai Bidaai","Brahma","Vishnu","Mahesh","Railway Truck","Drum","ZIP","ZAP"
                           }
        },
        { 3 , new string[] { "Letter C","Letter I","Letter D","CID","Letter H","Letter T","Letter L","Digit 7"

                            }
        },
        { 4 , new string[]
                            {
                                "Pyramid","Reverse Pyramid","Circle","All Even","All Odd","Eclipse","Plus"
                            }
        },
        { 5 , new string[]
                            {
                                "Temp / BP","Double Temp","Triple Temp","5 Min 5 Max","5 Minimum","5 Max Number"
                            }
        },
        { 6 , new string[]
                            {
                                "Anda","Danda","Anda Danda","5 Pandav","Hockey Stick","Fat Lady","Ugly Duckling","Naughty 6 & 9","26 January"
                            }
        },
        { 7 , new string[]
                            {
                                "1 Pair (Row)","2 Pair (Row)","3 Pair (Row)","4 Pair (Row)","All Pair (Row)",
                                "1 Pair (Column)","2 Pair (Column)","3 Pair (Column)","4 Pair (Column)","All Pair (Column)"
                            }
        },
        { 8 , new string[]
                            {
                                "First / Top Line","Second / Middle Line","Third Line / Last Line"

                            }
        },
        { 9 , new string[]
                            {
                                "I Love You 143","We Love You 243","Love You Too 433","You And Me 332","124","421","225","Work From Home 444",
                                "Stay At Home 424","123","333","Jai Shree Ram 353","4 2 ka 1(Reverse)","333(reverse)","3 2 ka 1 (Reverse)","Wear Mask"
                            }
        },
        { 10 , new string[]
                            {
                                "House"
                            }
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        InitializeChildDividend();
    }

    private void Update()
    {
        
    }

    public void InitializeChildDividend()
    {
        for(int i=0;i<11;i++)
        {
            GameObject DividendPrefab = gameObject.transform.GetChild(i).gameObject;
            GameObject childCont = DividendPrefab.transform.GetChild(1).gameObject;
            childCont.SetActive(false);
            for(int j = 0;j< DividendChildBlockNames[i].Length;j++)
            {
               GameObject go =  Instantiate(childPrefab, childCont.transform);
                go.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = DividendChildBlockNames[i][j];
                go.name = DividendChildBlockNames[i][j];
            }
            
        }
        
    }

    public void UpdatePoint()
    {
        for (int i = 0; i < 11; i++)
        {
            GameObject DividendPrefab = gameObject.transform.GetChild(i).gameObject;
            GameObject childCont = DividendPrefab.transform.GetChild(1).gameObject;
            for (int j = 0; j < childCont.transform.childCount; j++)
            {
                GameObject go = childCont.transform.GetChild(j).gameObject;
                GameObject cont = go.transform.GetChild(1).gameObject;
                string text = cont.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
                int spaceIndex = text.IndexOf(' ');
                if (spaceIndex != -1)
                {
                    // Get the substring before the space character
                    string numberString = text.Substring(0, spaceIndex);

                    // Try parsing the substring as an integer
                    if (int.TryParse(numberString, out int extractedNumber))
                    {
                        VerifyUI.instance.totalDividendPoints += extractedNumber;
                    }
                }
            }
        }

    }
}
