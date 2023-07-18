using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITheme : MonoBehaviour
{
    public GameObject ThemePanel;

    public void Back()
    {
        ThemePanel.SetActive(false);
    }
}
