using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TicketsFiller : MonoBehaviour
{
    public static TicketsFiller Instance;
    // manually assign each row in inspector
                              // public List<int> s = new List<int>();// This is just a reference, you have to take reference by creating instance from the real generated list
    private void Awake()
    {
        Instance = this;
    }

    //void Start()

    //{
    //    int i = 0;//Also keep this at a seperate place and access by instance just like list from another common script
    //    foreach (var row in Rows)
    //    {
    //        for (int j = 0; j < row.transform.childCount; j++)
    //        {
    //            row.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = GeneratedTicketManager.Instance.s[i].ToString();
    //            i++;
                
    //        }
    //    }
    //}
}