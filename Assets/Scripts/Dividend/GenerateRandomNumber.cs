using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateRandomNumber : MonoBehaviour
{
    private const int totalNumbers = 90;

    private List<int> numberPool = new List<int>();
    public static GenerateRandomNumber instance;
    public bool isNumberAssign = false;
    private void Awake()
    {
        instance = this;

        GenerateNumberPool();
        AssignTickets();
    }

    private void Start()
    {

    }

    private void GenerateNumberPool()
    {

        for (int i = 1; i <= totalNumbers; i++)
        {
            numberPool.Add(i);
        }

    }

    public void AssignTickets()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject ticketCont = gameObject.transform.GetChild(i).gameObject;

            for (int j = 0; j < 3; j++)
            {
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                List<int> list = new List<int>();
                int random = Random.Range(0, 14);
                int[] arr0 = new int[] { 0, 1, 4, 7, 8 };
                int[] arr1 = new int[] { 0, 2, 4, 6, 7 };
                int[] arr2 = new int[] { 1, 3, 5, 6, 8 };
                int[] arr3 = new int[] { 0, 1, 3, 4, 6 };
                int[] arr4 = new int[] { 2, 3, 5, 7, 8 };
                int[] arr5 = new int[] { 0, 3, 5, 6, 8 };
                int[] arr6 = new int[] { 1, 2, 4, 5, 7 };
                int[] arr7 = new int[] { 0, 1, 4, 5, 8 };
                int[] arr8 = new int[] { 2, 3, 5, 6, 8 };
                int[] arr9 = new int[] { 1, 3, 4, 5, 8 };
                int[] arr10 = new int[] { 1, 3, 4, 5, 8 };
                int[] arr11 = new int[] { 1, 2, 5, 6, 8 };
                int[] arr12 = new int[] { 0, 2, 3, 5, 7 };
                int[] arr13 = new int[] { 0, 3, 4, 6, 8 };
                if (random == 0 )
                {
                    for (int z = 0; z < arr0.Length; z++)
                    {
                        list.Add(arr0[z]);
                    }
                    
                }
                if (random == 1)
                {
                    for (int z = 0; z < arr1.Length; z++)
                    {
                        list.Add(arr1[z]);
                    }
                    
                }
                if (random == 2)
                {
                    for (int z = 0; z < arr2.Length; z++)
                    {
                        list.Add(arr2[z]);
                    }
                }
                if (random == 3)
                {
                    for (int z = 0; z < arr3.Length; z++)
                    {
                        list.Add(arr3[z]);
                    }
                   
                }
                if (random == 4)
                {
                    for (int z = 0; z < arr4.Length; z++)
                    {
                        list.Add(arr4[z]);
                    }
                    
                }
                if (random == 5)
                {
                    for (int z = 0; z < arr5.Length; z++)
                    {
                        list.Add(arr5[z]);
                    }
                }
                if (random == 6)
                {
                    for (int z = 0; z < arr6.Length; z++)
                    {
                        list.Add(arr6[z]);
                    }
                   
                }
                if (random == 7)
                {
                    for (int z = 0; z < arr7.Length; z++)
                    {
                        list.Add(arr7[z]);
                    }
                    
                }
                if (random == 8)
                {
                    for (int z = 0; z < arr8.Length; z++)
                    {
                        list.Add(arr8[z]);
                    }
                   
                }
                if (random == 9)
                {
                    for (int z = 0; z < arr9.Length; z++)
                    {
                        list.Add(arr9[z]);
                    }
                    
                }
                if (random == 10)
                {
                    for (int z = 0; z < arr10.Length; z++)
                    {
                        list.Add(arr10[z]);
                    }
                   
                }
                if (random == 11)
                {
                    for (int z = 0; z < arr11.Length; z++)
                    {
                        list.Add(arr11[z]);
                    }
                    
                }
                if (random == 12)
                {
                    for (int z = 0; z < arr12.Length; z++)
                    {
                        list.Add(arr12[z]);
                    }
                }
                if (random == 13)
                {
                    for (int z = 0; z < arr13.Length; z++)
                    {
                        list.Add(arr13[z]);
                    }
                }
                //for (int k = 0; k < 5; k++)
                //{
                //    //int rndm = Random.Range(0, 9);


                //    //while (list.Contains(rndm))
                //    //{
                //    //    rndm = Random.Range(0, 9);
                //    //}

                //    //list.Add(rndm);

                //}

                for (int k = 0; k < 5; k++)
                {
                    int n = GenerateNumber();
                    row.transform.GetChild(list[k]).GetComponentInChildren<TextMeshProUGUI>().text = n.ToString();
                }
            }
        }
        isNumberAssign = true;
        if(gameObject.CompareTag("Theme Ticket"))
        {
            return;
        }
        else
        {
            GenerateDividendTicket.instance.SaveGrid_1_();
            GenerateDividendTicket.instance.SaveGrid_6_();
        }
        

    }




    private int GenerateNumber()
    {
        int randomIndex = UnityEngine.Random.Range(0, numberPool.Count);
        int selectedNumber = numberPool[randomIndex];
        numberPool.RemoveAt(randomIndex);
        return selectedNumber;
    }


}