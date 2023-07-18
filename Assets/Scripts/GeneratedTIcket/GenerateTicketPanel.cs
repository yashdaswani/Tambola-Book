using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTicketPanel : MonoBehaviour
{
    private int totalnumberofPlayer;
    public GameObject GenerateTicketPanelPrefab;
    public Transform transform;
    public static GenerateTicketPanel instance;
    private int currentindex;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        totalnumberofPlayer = GameManager.Instance.TotalNumberOFPlayer;
        for(int i = 0; i < totalnumberofPlayer; i++)
        {
            Instantiate(GenerateTicketPanelPrefab,transform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBackButton();
        }
    }

    public void GeneratePanelAFteraddingPlayer()
    {
        Instantiate(GenerateTicketPanelPrefab, transform);
    }

    public void MakeActivePanel(int index)
    {
         GameObject activePanel = transform.GetChild(index).gameObject;
         activePanel.SetActive(true);
         currentindex = index;
    }

    void HandleBackButton()
    {
        if(transform.GetChild(currentindex).gameObject != null && transform.GetChild(currentindex).gameObject.activeSelf)
        {
            transform.GetChild(currentindex).gameObject.SetActive(false);

        }
    }





    }
