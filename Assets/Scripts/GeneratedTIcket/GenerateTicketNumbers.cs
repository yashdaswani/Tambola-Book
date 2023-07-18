using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class GenerateTicketNumbers : MonoBehaviour
{
    public TMP_Text[] nText;
    private const int totalNumbers = 90;

    private List<int> numberPool = new List<int>();

    public static GenerateTicketNumbers instance;
    public bool isNumberAssign = false;
    private void Awake()
    {
        instance = this;

        GenerateNumberPool();
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
        InitializeRowLists();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject ticketPrefab = gameObject.transform.GetChild(i).gameObject;
            GameObject ticketCont = ticketPrefab.transform.GetChild(1).gameObject;

            for (int j = 0; j < 3; j++)
            {
                GameObject row = ticketCont.transform.GetChild(j).gameObject;
                
                int[] l = GetUniqueRowList();

                for (int k = 0; k < 5; k++)
                {
                         
                         int n = GenerateNumber(l[k]);
                         row.transform.GetChild(l[k]).GetComponentInChildren<TextMeshProUGUI>().text = n.ToString();

                }
            }
        }
        isNumberAssign = true;
    }


    private List<int[]> rowLists = new List<int[]>();

    private void InitializeRowLists()
    {
        rowLists.Add(new int[] { 0, 2, 5, 7, 8 });
        rowLists.Add(new int[] { 1, 2, 4, 6, 8 });
        rowLists.Add(new int[] { 0, 1, 3, 4, 8 });
        rowLists.Add(new int[] { 1, 3, 4, 6, 8 });
        rowLists.Add(new int[] { 0, 2, 3, 5, 6 });
        rowLists.Add(new int[] { 1, 4, 5, 7, 8 });
        rowLists.Add(new int[] { 0, 2, 4, 6, 8 });
        rowLists.Add(new int[] { 1, 2, 4, 6, 7 });
        rowLists.Add(new int[] { 0, 1, 3, 5, 6 });
        rowLists.Add(new int[] { 0, 2, 3, 6, 7 });
        rowLists.Add(new int[] { 1, 3, 5, 7, 8 });
        rowLists.Add(new int[] { 1, 4, 5, 7, 8 });
        rowLists.Add(new int[] { 0, 3, 4, 6, 8 });
        rowLists.Add(new int[] { 0, 2, 3, 5, 7 });
        rowLists.Add(new int[] { 1, 2, 4, 5, 7 });
        rowLists.Add(new int[] { 2, 4, 5, 7, 8 });
        rowLists.Add(new int[] { 2, 3, 5, 6, 8 });
        rowLists.Add(new int[] { 0, 1, 3, 6, 7 });
    }

    private int[] GetUniqueRowList()
    {
        if (rowLists.Count == 0)
        {
            Debug.LogWarning("All row lists have been used.");
            return null;
        }

        int randomIndex = Random.Range(0, rowLists.Count);
        int[] selectedRowList = rowLists[randomIndex];
        rowLists.RemoveAt(randomIndex);
        return selectedRowList;
    }


    private int GenerateNumber(int n)
    {


        int columnStartValue = n * 10;
        int columnEndValue = n * 10 + 9;

        if (n == 0)
        {
            columnStartValue = n * 10 + 1;
            columnEndValue = n * 10 + 9;
        }

        if (n == 8)
        {
             columnStartValue = n * 10;
             columnEndValue = n * 10 + 10;
        }

        List<int> validNumbers = new List<int>();
        for (int i = columnStartValue; i <= columnEndValue; i++)
        {
            if (numberPool.Contains(i))
            {
                validNumbers.Add(i);
            }
        }

        if (validNumbers.Count == 0)
        {
            return -1; // No available numbers in the column
        }

        int randomIndex = Random.Range(0, validNumbers.Count);
        int selectedNumber = validNumbers[randomIndex];
        numberPool.Remove(selectedNumber);

        return selectedNumber ;
    }


}