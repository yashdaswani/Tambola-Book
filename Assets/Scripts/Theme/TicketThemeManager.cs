using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketThemeManager : MonoBehaviour
{

    public Theme currentTheme;
    public event System.Action<Theme> OnThemeChanged;
    public static TicketThemeManager instance;

    private void Awake()
    {
        instance = this;
    }
   

    public void ChangeTheme(Theme newTheme)
    {
        currentTheme = newTheme;
        OnThemeChanged?.Invoke(newTheme);
    }
}
