using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    public GameObject ThemeOptionsPanel;
   // public GameObject Content;
    public static ThemeManager Instance;

    public Theme currentTheme;
    public event System.Action<Theme> OnThemeChanged;


    private void Awake()
    {
        Instance = this;
    }

    public void ChangeTheme(Theme newTheme)
    {
        currentTheme = newTheme;
        OnThemeChanged?.Invoke(newTheme);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBackButton();
        }
    }

    void HandleBackButton()
    {
        // Check if the panel is active before closing it
        if (ThemeOptionsPanel != null && ThemeOptionsPanel.activeSelf)
        {
            ThemeOptionsPanel.SetActive(false);
        }
    }

        public void OpenSelectThemePanel()
        {
            ThemeOptionsPanel.SetActive(true);
        }



}
