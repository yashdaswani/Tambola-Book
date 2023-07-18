using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DividendVerify : MonoBehaviour
{
    
    public GameObject Childcont;
    public Image arrow;
    private bool isChildopen = false;

    public void OnClickDividend()
    {
        if(!isChildopen)
        {
            Childcont.SetActive(true);
            arrow.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -90);
            isChildopen = true;
        }
        else
        {
            Childcont.SetActive(false);
            arrow.GetComponent<RectTransform>().rotation = Quaternion.identity;
            isChildopen = false;
        }
        

    }

}

