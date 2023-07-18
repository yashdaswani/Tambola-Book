using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VerifyUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject DividendsPanel;
    public GameObject SetwisePanel;
    public GameObject CHangeNamePanel;
    public GameObject ReadMePanel;

    public TMP_Text name;
    public TMP_InputField changenameIF;
    public static VerifyUI instance;
    public AddPrefabToChildDIvidend namePrefab;

    [Header("SetWiseSetting")]
    public GameObject SetWiseSettingPanel;
    public Slider DividendPerTicketSLider;
    public TMP_Text DividendPerTicketText;
    public Toggle HouseToggle;
    public Slider DividendPerSetSLider;
    public TMP_Text DividendPerSetText;
    public Slider HousePerSetSLider;
    public TMP_Text HousePerSetText;
    public Slider SheetDividendPerSetSLider;
    public TMP_Text SheetDividendPerSetText;

    public Toggle[] toggles;
    public int currentToggleIndex = 0;

    public TMP_Text DividendPerTicketTextPanel;
    public TMP_Text setwiseText;
    public TMP_Text setwiseTextDesc;
    public GameObject SetwiseCont;

    public GameObject cont;

    [Header("Summary")]
    public GameObject SummaryPanel;
    public GameObject SummaryCont;
    public GameObject SummaryPrefab;
    public TMP_Text TotalDividendPointText;
    public TMP_Text TotalSetWisePointText;

    [HideInInspector] public int totalDividendPoints = 0; public int totalSetWisePoints = 0;


    [Header("PointPanel")]
    public GameObject PointPanel;
    public TMP_InputField points_IF;
    private VerifyChildPrefab currentPrefab;

    [HideInInspector] public int isDividendOpen = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DividendPerTicketSLider.onValueChanged.AddListener((float value) => OnSliderValueChanged(value));
        DividendPerSetSLider.onValueChanged.AddListener((float value1) => OnSliderValueChanged1(value1));
        HousePerSetSLider.onValueChanged.AddListener((float value2) => OnSliderValueChanged2(value2));
        SheetDividendPerSetSLider.onValueChanged.AddListener((float value3) => OnSliderValueChanged3(value3));
        HouseToggle.onValueChanged.AddListener((bool value) => OnToggleValueChanged(value));
        for (int i = 0; i < toggles.Length; i++)
        {
            int index = i;
            toggles[i].onValueChanged.AddListener((isOn) => OnToggleValueChanged(index, isOn));
        }
    }

    private void Update()
    {
        SetwiseContManager.Instance.Changeinsetwise();
        UpdateTotalPoint();
    }

    public void OnToggleValueChanged(int toggleIndex, bool isOn)
    {
        if (isOn)
        {
            currentToggleIndex = toggleIndex;
            if(!(toggleIndex == 0))
            {
                cont.SetActive(true);
            }
            else
            {
                cont.SetActive(false);
            }
        }
    }



    public void OnSliderValueChanged(float sliderValue)
    {
        int intValue = Mathf.RoundToInt(sliderValue);

        UpdateDividendText(intValue);
    }

    public void OnSliderValueChanged1(float sliderValue)
    {
        int intValue = Mathf.RoundToInt(sliderValue);

        if (intValue == 0)
        {
            DividendPerSetText.text = "Unlimited Dividends Per Set";
        }
        else
        {
            DividendPerSetText.text = intValue + " Dividends Per Set (Including HOUSE)";
        }
    }
    public void OnSliderValueChanged2(float sliderValue)
    {
        int intValue = Mathf.RoundToInt(sliderValue);

        if (intValue == 0)
        {
            HousePerSetText.text = "Unlimited Houses Per Set";
        }
        else
        {
            HousePerSetText.text = intValue + " Houses Per Set (Including HOUSE)";
        }
    }
    public void OnSliderValueChanged3(float sliderValue)
    {
        int intValue = Mathf.RoundToInt(sliderValue);

        if (intValue == 0)
        {
            SheetDividendPerSetText.text = "Unlimited Sheet Dividends Per Set";
        }
        else
        {
            SheetDividendPerSetText.text = intValue + " Sheet Dividends Per Set (Including HOUSE)";
        }
    }

    public void OnToggleValueChanged(bool toggleValue)
    {
        int sliderValue = Mathf.RoundToInt(DividendPerTicketSLider.value);
        int intValue = toggleValue ? sliderValue + 1 : sliderValue;

        UpdateDividendText(intValue);
    }

    private void UpdateDividendText(int intValue)
    {
        if (!HouseToggle.isOn)
        {
            if (intValue == 0)
            {
                DividendPerTicketText.text = "Unlimited Dividends Per Ticket";
            }
            else
            {
                DividendPerTicketText.text = intValue + " Dividends Per Ticket (Including HOUSE)";
            }
        }
        else
        {
            if (intValue == 0)
            {
                DividendPerTicketText.text = "No Dividends Only HOUSE";
            }
            else
            {
                DividendPerTicketText.text = intValue + " Dividends Per Ticket + 1 HOUSE";
            }
        }
    }


    public void UpdateTotalPoint()
    {
        if(isDividendOpen==1)
        {
            TotalDividendPointText.text = "Total : " + totalDividendPoints;
            TotalDividendPointText.gameObject.SetActive(true);
            TotalSetWisePointText.gameObject.SetActive(false);
        }
        else
        {
            TotalSetWisePointText.text = "Total : " + totalSetWisePoints;
            TotalDividendPointText.gameObject.SetActive(false);
            TotalSetWisePointText.gameObject.SetActive(true);
        }
        
    }

    

    public void OnClickReadMe()
    {
        ReadMePanel.gameObject.SetActive(true);
    }


    public void onClickDIvidendBtn()
    {
        DividendsPanel.SetActive(true);
        SetwisePanel.SetActive(false);
        isDividendOpen = 1;
    }
    public void onClickSetwiseBtn()
    {
        DividendsPanel.SetActive(false);
        SetwisePanel.SetActive(true);
        isDividendOpen = 0;
    }

    

    public void OnCLickSettingButton()
    {
        SetWiseSettingPanel.SetActive(true);
    }

    public void ExitSetwisesetting()
    {
        SetWiseSettingPanel.SetActive( false);
    }

    public void SaveSetwiseSetting()
    {
        SetWiseSettingPanel.SetActive(false);
        
    }

    public void exitChangeNameBtn()
    {
        CHangeNamePanel.SetActive(false);
    }

    public void OpenNamePanel(AddPrefabToChildDIvidend _prefab)
    {
        namePrefab = _prefab;
        CHangeNamePanel.SetActive(true);
    }

    public void SaveChangeNameBtn()
    {
        CHangeNamePanel.SetActive(false);
        namePrefab.ChangeName();
    }

    public void ExitPointPanel()
    {
        PointPanel.SetActive(false);
    }


    public void OpenPointPanel(VerifyChildPrefab prefab)
    {
        currentPrefab = prefab;
        PointPanel.SetActive(true);
    }

    public void SavePointPane()
    {
        PointPanel.SetActive(false);
        currentPrefab.SavePoint();
    }

    public void OpenSummaryPanel()
    {
        SummaryPanel.SetActive(true) ;
    }
    public void CloseSummaryPanel()
    {
        SummaryPanel.SetActive(false) ;
    }
}
