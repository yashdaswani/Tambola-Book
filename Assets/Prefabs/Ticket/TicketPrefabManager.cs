using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TicketPrefabManager : MonoBehaviour
{

    public Theme defaultTheme;
    public Image background;
    public TMP_Text headerText;
    public TMP_Text ticketDetailsText;
    public Image gridBoundary;
    public Image grid;
    public TMP_Text gridText;
    //public Image marked;
    //public TMP_Text markedText;
    public GameObject[] tickets;

    private void Start()
    {
        TicketThemeManager.instance.OnThemeChanged += UpdateTheme;
        UpdateTheme(TicketThemeManager.instance.currentTheme != null ? TicketThemeManager.instance.currentTheme : defaultTheme);    
        ThemeManager.Instance.OnThemeChanged += UpdateTheme;
        UpdateTheme(ThemeManager.Instance.currentTheme != null ? ThemeManager.Instance.currentTheme : defaultTheme); 
        tickets = GameObject.FindGameObjectsWithTag("Ticket");
    }

    private void UpdateTheme(Theme newTheme)
    {
        background.color = newTheme.backGroundColor;
        headerText.color = newTheme.headerTextColor;
        ticketDetailsText.color = newTheme.TicketDetailsColor;
        gridBoundary.color = newTheme.GridBoundaryColor;
        grid.color = newTheme.GridColor;
        gridText.color = newTheme.GridTextColor;
        //marked.color = newTheme.MarkedColor;
        //markedText.color = newTheme.MarkedTextColor;

    }

    private void OnDestroy()
    {
        TicketThemeManager.instance.OnThemeChanged -= UpdateTheme;
    }
}
