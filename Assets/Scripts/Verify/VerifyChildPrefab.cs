using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerifyChildPrefab : MonoBehaviour
{ 

    public TMP_Text PointText;
    private int previousPoint;
   

    public void onClickPrefab()
    {
        VerifyUI.instance.OpenPointPanel(this);
        string text = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        int spaceIndex = text.IndexOf(' ');
        if (spaceIndex != -1)
        {
            // Get the substring before the space character
            string numberString = text.Substring(0, spaceIndex);

            // Try parsing the substring as an integer
            if (int.TryParse(numberString, out int extractedNumber))
            {
                previousPoint= extractedNumber;
            }
        }
    }

    public void SavePoint()
    {

        PointText.text = VerifyUI.instance.points_IF.text + " Points";
        if(VerifyUI.instance.isDividendOpen==1)
        {
            int n;
            if (int.TryParse(VerifyUI.instance.points_IF.text, out n))
            {
                Debug.Log(n);
                VerifyUI.instance.totalDividendPoints -= previousPoint;
                VerifyUI.instance.totalDividendPoints += n;
                Debug.Log(VerifyUI.instance.totalDividendPoints);
            }
        }
        else
        {
            int n;
            if (int.TryParse(VerifyUI.instance.points_IF.text, out n))
            {
                Debug.Log(n);
                VerifyUI.instance.totalSetWisePoints -= previousPoint;
                VerifyUI.instance.totalSetWisePoints += n;
                Debug.Log(VerifyUI.instance.totalSetWisePoints);
            }
        }
        
    }

    public void updateSummaryPoint()
    {
        GameObject summaryCOnt = VerifyUI.instance.SummaryCont;
        int n = summaryCOnt.transform.childCount;
        for (int i = 1; i < n; i++)
        {
            GameObject summaryContPrefab = summaryCOnt.transform.GetChild(i).gameObject;
            string points = summaryContPrefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            string name = summaryContPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            int spaceIndex = points.IndexOf(' ');
            int p;
            if (spaceIndex != -1)
            {
                // Get the substring before the space character
                string numberString = points.Substring(0, spaceIndex);

                // Try parsing the substring as an integer
                if (int.TryParse(numberString, out int extractedNumber))
                {
                    p = extractedNumber;
                }
            }

            if (gameObject.name == name)
            {
                summaryContPrefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }


}
