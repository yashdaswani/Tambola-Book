using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketController : MonoBehaviour
{
    public Text[] numberTexts;

    private void Start()
    {
        
    }

    private void AssignText()
    {

        for(int i = 0;i<3;i++)
        {
            GameObject row = gameObject.transform.GetChild(1).gameObject;


        }
    }

    public void SetNumbers(List<int> numbers)
    {
        // Ensure that the number of provided numbers matches the number of UI elements
        if (numbers.Count != numberTexts.Length)
        {
            Debug.LogError("Number count and UI element count do not match!");
            return;
        }

        // Assign each number to the corresponding UI element
        for (int i = 0; i < numbers.Count; i++)
        {
            numberTexts[i].text = numbers[i].ToString();
        }
    }
}
