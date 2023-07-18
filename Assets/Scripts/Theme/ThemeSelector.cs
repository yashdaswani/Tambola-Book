using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSelector : MonoBehaviour
{
    public Theme theme;

    public void SelectTheme()
    {
        ThemeManager.Instance.ChangeTheme(theme);
        TicketThemeManager.instance.ChangeTheme(theme);
    }
}