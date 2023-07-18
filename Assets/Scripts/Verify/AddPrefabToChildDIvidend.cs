using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPrefabToChildDIvidend : MonoBehaviour
{
    public static AddPrefabToChildDIvidend instance;
    public GameObject childDetailsPrefab;
    public Button editButton;
    public Button plusButton;
    public Button minusButton;
    public GameObject plusMinusCont;
    public TMP_Text number;
    public Toggle toggle;
    private bool previousToggleState = false;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        previousToggleState = toggle.isOn;
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        UpdateTextWidth();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumber();
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (!isOn)
        {
            GameObject cont = gameObject.transform.GetChild(1).gameObject;
            cont.SetActive(false);
            editButton.gameObject.SetActive(false);
            plusMinusCont.gameObject.SetActive(false);
            for (int i =1;i<cont.transform.childCount;i++)
            {
                Destroy(cont.transform.GetChild(i).gameObject);
            }
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 70f);
            }
        }
        else
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 50f);
            }
            OnclickToggle();
        }
    }

    public void OnclickToggle()
    {
        editButton.gameObject.SetActive(true);
        plusMinusCont.gameObject.SetActive(true);

        GameObject cont = gameObject.transform.GetChild(1).gameObject;
        cont.SetActive(true);
        if(cont.transform.childCount==0)
        {
            GameObject go = Instantiate(childDetailsPrefab, cont.transform);
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = cont.transform.childCount.ToString() + " . " + gameObject.name;
            GameObject go_summary = Instantiate(VerifyUI.instance.SummaryPrefab, VerifyUI.instance.SummaryCont.transform);
            go_summary.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (VerifyUI.instance.SummaryCont.transform.childCount - 1).ToString() + ". " + gameObject.name;
           
        }
        
    }

    public void onclickPlusButton()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 50f);
        }
        GameObject go = Instantiate(childDetailsPrefab, gameObject.transform.GetChild(1).transform);
        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = gameObject.transform.GetChild(1).childCount.ToString() +" . " +gameObject.name;
        GameObject go_summary = Instantiate(VerifyUI.instance.SummaryPrefab, VerifyUI.instance.SummaryCont.transform);
        go_summary.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (VerifyUI.instance.SummaryCont.transform.childCount-1).ToString() + ". " + gameObject.name;
    }
    public void onclickMinusButton()
        
    {
        GameObject cont = gameObject.transform.GetChild(1).gameObject;
        int n = cont.transform.childCount;
        if (n>0)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y - 50f);
            }

            Destroy(cont.transform.GetChild(n - 1).gameObject);
        }
        
    }

    public void UpdateNumber()
    {
        GameObject cont = gameObject.transform.GetChild(1).gameObject;
        int n = cont.transform.childCount;
        number.text = n.ToString();
        for(int i = 0;i< n; i++)
        {
            GameObject prefab = cont.transform.GetChild(i).gameObject;
            prefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i+1).ToString() +". "+ gameObject.name;
        }

    }

    public void onEditClickButton()
    {
        VerifyUI.instance.name.text = gameObject.name;
        VerifyUI.instance.changenameIF.text = gameObject.name;
        VerifyUI.instance.OpenNamePanel(this);
    }

    public void ChangeName()
    {
        string changeNametext = VerifyUI.instance.changenameIF.text;
        UpdateSummaryPrefabPoints(this.gameObject,changeNametext);
        this.gameObject.name = changeNametext;
        gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = changeNametext;

    }

    public void UpdateTextWidth()
    {
        // Get the preferred width of the text
        Text text = toggle.transform.GetChild(1).GetComponent<Text>();
        float preferredWidth = text.preferredWidth;

        // Adjust the width of the RectTransform
        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(preferredWidth + 30, rectTransform.sizeDelta.y );
    }


    public void UpdateSummaryPrefabPoints(GameObject gameObject,string changeNametext)
    {
        GameObject summaryCOnt = VerifyUI.instance.SummaryCont;
        int n = summaryCOnt.transform.childCount;
        for(int i= 1 ; i < n; i++)
        {
            GameObject summaryContPrefab = summaryCOnt.transform.GetChild(i).gameObject;
            string name = summaryContPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            int dotIndex = name.IndexOf('.');
            if (dotIndex != -1)
            {
                // Remove the index and dot
                name = name.Substring(dotIndex + 1).TrimStart();
                
            }
            name = name.Replace(".", "");
            if (gameObject.name == name)
            {
                summaryContPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i + ". " + changeNametext;
            }
        }

    }


}
