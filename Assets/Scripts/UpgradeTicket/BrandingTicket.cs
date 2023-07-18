using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrandingTicket : MonoBehaviour
{
    public TMP_InputField ticketNumberInputField;
    public TMP_InputField ticketHeaderNameInputField;
    public Button pricingButton;
    public Button BuyButton;
    public Button ShowAllPlanesButton;
    public TMP_Text priceText;
    private int ticketUserCanBuy;
    private int ticketCount = 0;
    public TMP_Text TicketHeaderName;

    // Start is called before the first frame update
    void Start()
    {
        ticketNumberInputField.onValueChanged.AddListener(OnTicketNumberCountChanged);
        ticketHeaderNameInputField.onValueChanged.AddListener(OnTicketNameCountChanged);
    }

    private void OnTicketNumberCountChanged(string value)
    {

        if (int.TryParse(value, out ticketCount))
        {
            pricingButton.gameObject.SetActive(true);

        }
        else
        {
            pricingButton.gameObject.SetActive(false);
            priceText.text = string.Empty;
            BuyButton.gameObject.SetActive(false);
        }


    }

    private void OnTicketNameCountChanged(string value)
    {

        TicketHeaderName.text = value;


    }


    public void OnclickPricingButton()
    {
        BuyButton.gameObject.SetActive(true);


        if (ticketCount > 0 && ticketCount <= 120)
        {
            ticketUserCanBuy = 120;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (10.00)";
        }
        if (ticketCount > 120 && ticketCount <= 300)
        {
            ticketUserCanBuy = 300;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (25.00)";
        }
        if (ticketCount > 300 && ticketCount <= 600)
        {
            ticketUserCanBuy = 600;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (50.00)";
        }
        if (ticketCount > 600 && ticketCount <= 1200)
        {
            ticketUserCanBuy = 1200;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (100.00)";
        }
        if (ticketCount > 1200 && ticketCount <= 3000)
        {
            ticketUserCanBuy = 3000;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (200.00)";
        }
        if (ticketCount > 3000 && ticketCount <= 5000)
        {
            ticketUserCanBuy = 5000;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (300.00)";
        }
        if (ticketCount > 5000 && ticketCount <= 7000)
        {
            ticketUserCanBuy = 7000;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (400.00)";
        }
        if (ticketCount > 7000 && ticketCount <= 9000)
        {
            ticketUserCanBuy = 9000;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (500.00)";
        }
        if (ticketCount > 9000 && ticketCount <= 10000)
        {
            ticketUserCanBuy = 10000;
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY (600.00)";
        }
        priceText.text = "You can generate upto " + ticketUserCanBuy + " Tickets at below price";
        if (ticketCount == 0)
        {
            BuyButton.gameObject.SetActive(false);
            pricingButton.gameObject.SetActive(false);
            priceText.text = string.Empty;
        }
    }

    public void OnCLickShowAllPlanesButton()
    {
        gameObject.SetActive(false);
    }
}
