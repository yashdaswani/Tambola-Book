using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;



public class BoardManager : MonoBehaviour 
{
    public static BoardManager Instance;

    public GameObject numberPrefab; // Prefab for the number tile
    public RectTransform boardContainer; // Parent object to hold the number tiles
    public GridLayoutGroup gridLayout; // Grid layout component for the board container

    private const int boardSizeX = 9; // Number of columns
    private const int boardSizeY = 10; // Number of rows

    private GameObject previousNumberTile; // Reference to the previous number tile
    private float delay = 2;
    private bool IsGameStarted = false;
    public GameObject COnfirmStartPanel;

    List<int> availableNumbers = new List<int>(); // List to store available numbers
    public Stack<int> generatedNumbersStack = new Stack<int>();

    public TMP_Text TimeText;
    public TMP_Text topNumbersText;
    public TMP_Text TotalNumberGeneratedText;
    private int TotalNumber = 0;

    public Coroutine autoGenerateCoroutine; // Reference to the auto-generate coroutine
    private bool autoGenerateNextNumber; // Flag to control automatic number generation

    public Button SoundBtn;
    public Sprite soundOn;
    public Sprite soundOff;
    private int issoundOn = 1;

    public TMP_Text RecentNumberText;
    public GameObject BTN_Cont;

    public Toggle[] toggles;
    public int currentToggleIndex;
    public Slider slider;
    public TMP_Text delayText;

    public TMP_Text claimNotification;
    public bool showingNoti = false;

    [Header("All number Clips")]

    [SerializeField] AudioSource numberVoiceSource;
    [SerializeField] AudioClip[] allAudioClips;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreateNumberBoard();
        InitializeAvailableNumbers();
       // slider.value = 2f;
        for (int i = 0; i < toggles.Length; i++)
        {
            int index = i;
            toggles[i].onValueChanged.AddListener((isOn) => OnToggleValueChanged(index, isOn));
        }

        if(PlayerPrefs.HasKey("Sound"))
        {
            issoundOn = PlayerPrefs.GetInt("Sound");
        }
        else
        {
            PlayerPrefs.SetInt("Sound", issoundOn);
        }

    }

    void InitializeAvailableNumbers()
    {
        for (int i = 1; i <= 90; i++)
        {
            availableNumbers.Add(i); // Add all numbers from 1 to 90 to the available numbers list
        }
    }

    void CreateNumberBoard()
    {
        // Set the cell size and spacing of the grid layout
        gridLayout.cellSize = new Vector2(boardContainer.rect.width / boardSizeX, boardContainer.rect.height / boardSizeY);
        gridLayout.spacing = Vector2.zero;

        // Calculate the starting position of the board
        float startX = -(boardContainer.rect.width / 2) + (gridLayout.cellSize.x / 2);
        float startY = (boardContainer.rect.height / 2) - (gridLayout.cellSize.y / 2);

        int number = 1;

        // Create number tiles and position them on the board
        for (int y = 0; y < boardSizeY; y++)
        {
            for (int x = 0; x < boardSizeX; x++)
            {
                // Instantiate the number tile prefab
                GameObject numberTile = Instantiate(numberPrefab, boardContainer);

                // Set the number text on the tile
                TextMeshProUGUI numberText = numberTile.GetComponentInChildren<TextMeshProUGUI>();
                numberText.text = number.ToString();

                // Set the name of the tile to its corresponding number
                numberTile.name = number.ToString();

                // Set the position of the tile
                RectTransform numberTileTransform = numberTile.GetComponent<RectTransform>();
                numberTileTransform.anchoredPosition = new Vector2(startX + (gridLayout.cellSize.x * x), startY - (gridLayout.cellSize.y * y));

                number++;
            }
        }
    }

    public void NextNumberButton()
    {

        if (IsGameStarted)
        {
           
            if (availableNumbers.Count == 0)
            {
                Debug.Log("No available numbers left.");
                return;
            }

            if (autoGenerateNextNumber)
            {
                // If auto-generate flag is true, exit the function to prevent manual number generation
                return;
            }

            int randomIndex = UnityEngine.Random.Range(0, availableNumbers.Count); // Generate a random index
            int randomNum = availableNumbers[randomIndex]; // Get the random number from the available numbers list

            // Find the number tile with the generated random number
            GameObject currentNumberTile = boardContainer.Find(randomNum.ToString())?.gameObject;
            // Add the generated number to the stack

            if (currentNumberTile != null)
            {
                currentNumberTile.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                // Change the background color of the current number tile to red
                Image currentNumberTileImage = currentNumberTile.GetComponent<Image>();
                currentNumberTileImage.color = Color.red;

                // Change the background color of the previous number tile to blue (if any)
                if (previousNumberTile != null)
                {
                    Image previousNumberTileImage = previousNumberTile.GetComponent<Image>();
                    previousNumberTileImage.color = Color.blue;
                }


                previousNumberTile = currentNumberTile; // Update the reference to the previous number tile
                availableNumbers.RemoveAt(randomIndex); // Remove the generated number from the available numbers list

                RecentNumberText.text = randomNum.ToString();
                numberVoiceSource.clip = allAudioClips[randomNum - 1];
                numberVoiceSource.Play();
                for (int i = 0; i < BTN_Cont.transform.childCount; i++)
                {
                    BTN_Cont.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
                StartCoroutine(DisplayNumberGenerated());
                TotalNumber++;
                TotalNumberGeneratedText.text = "Total " + TotalNumber.ToString();
                DateTime currentDateTime = DateTime.Now;
                string dayName = currentDateTime.ToString("dddd");
                string date = currentDateTime.ToString("MM/dd/yyyy");
                string time = currentDateTime.ToString("HH:mm:ss");

                TimeText.text = dayName + " " + date + " " + time;

                generatedNumbersStack.Push(randomNum); // Push the generated number to the stack

                // Update the top numbers text
                UpdateTopNumbersText();
                SearchTicket.instance.MarkNumberonTickets(randomNum);
                SearchTicket.instance.MarkedTicket(randomNum);
                TicketVerification.instance.MarkedTicketVerificationNumber(randomNum);
            }

        }
        else
        {
            COnfirmStartPanel.SetActive(true);
        }
    }


    public void OnClaim()
    {
         showingNoti = false;
    }


    IEnumerator DisplayNumberGenerated()
    {
        yield return new WaitForSeconds(2);
        RecentNumberText.text = "";

        for (int i = 0; i < BTN_Cont.transform.childCount; i++)
        {
            BTN_Cont.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }



    void UpdateTopNumbersText()
    {
        // Clear the top numbers text
        topNumbersText.text = "";

        // Create a temporary stack to hold the top 5 numbers
        Stack<int> tempStack = new Stack<int>();

        // Iterate through the generated numbers stack and add the top 5 numbers to the temporary stack
        int count = 0;
        foreach (int number in generatedNumbersStack)
        {
            if (count >= 5)
                break;

            tempStack.Push(number);
            count++;
        }

        // Create a temporary list to hold the reversed numbers
        List<int> reversedNumbers = new List<int>(tempStack);

        // Reverse the order of the numbers
        reversedNumbers.Reverse();

        // Iterate through the reversed numbers and update the top numbers text
        foreach (int number in reversedNumbers)
        {
            // If the number is the top element in the stack, set its font color to red
            if (number == generatedNumbersStack.Peek())
                topNumbersText.text += "<color=red>" + number.ToString() + "</color> " + "<--";
            else
                topNumbersText.text += "<color=blue>" + number.ToString() + "</color> " + "<--";
        }
    }

    public void CancelStartGAME()
    {
        COnfirmStartPanel.SetActive(false);
    }

    public void yesStartGame()
    {
        IsGameStarted = true;
        COnfirmStartPanel.SetActive(false);
    }



    public void ShareButton()
    {
        StartCoroutine(TakeScreenShotAndShare());
    }

    IEnumerator TakeScreenShotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D tx = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tx.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tx.Apply();

        string path = Path.Combine(Application.temporaryCachePath, "sharedImage.png");//image name
        File.WriteAllBytes(path, tx.EncodeToPNG());

        Destroy(tx); //to avoid memory leaks

        new NativeShare()
            .AddFile(path)
            .SetSubject("This is my score")
            .SetText("share your score with your friends")
            .Share();


    }

    public void OnToggleValueChanged(int toggleIndex, bool isOn)
    {
        if (isOn)
        {
            currentToggleIndex = toggleIndex;
            if (toggleIndex == 0)
            {
                // Manual generation selected
                slider.gameObject.SetActive(false);
                delay = 2;
                if (autoGenerateCoroutine != null)
                {
                    // Stop the auto-generate coroutine
                    StopCoroutine(autoGenerateCoroutine);
                    autoGenerateCoroutine = null;
                }
            }
            else if (toggleIndex == 1)
            {
                // Automatic generation selected
                slider.gameObject.SetActive(true);
                delay = slider.value;
                if (autoGenerateCoroutine != null)
                {
                    // Start the auto-generate coroutine
                    StopCoroutine(autoGenerateCoroutine);
                    autoGenerateCoroutine = StartCoroutine(AutoGenerateNumbersCoroutine(delay));
                }
                else
                {
                    autoGenerateCoroutine = StartCoroutine(AutoGenerateNumbersCoroutine(delay));
                }
            }
        }
    }
    public void OnSliderValueChanged()
    {
        UpdateDelayText(slider.value);
        if (autoGenerateCoroutine != null)
        {
            // Start the auto-generate coroutine
            StopCoroutine(autoGenerateCoroutine);
            delay = slider.value;
            autoGenerateCoroutine = StartCoroutine(AutoGenerateNumbersCoroutine(delay));
        }
        else
        {
            autoGenerateCoroutine = StartCoroutine(AutoGenerateNumbersCoroutine(delay));
        }
    }

    public void OnclaimNotifi()
    {
        if (autoGenerateCoroutine != null)
        {
            StopCoroutine(autoGenerateCoroutine);
            claimNotification.gameObject.SetActive(true);
        }
    }
    public IEnumerator AutoGenerateNumbersCoroutine(float delay)
    {
        
        delay = slider.value;
        yield return new WaitForSeconds(delay);
        while(showingNoti)
        {
            yield return null;
        }
       
        NextNumberButton();
        if(currentToggleIndex==1)
        {
            if (autoGenerateCoroutine != null)
            {
                // Start the auto-generate coroutine
                StopCoroutine(autoGenerateCoroutine);
                delay = slider.value;
                autoGenerateCoroutine = StartCoroutine(AutoGenerateNumbersCoroutine(delay));
            }
            else
            {
                autoGenerateCoroutine = StartCoroutine(AutoGenerateNumbersCoroutine(delay));
            }
        }
    }

    public void UpdateDelayText(float delayValue)
    {
        delayText.text = "Delay: " + delayValue + " Seconds";
    }


    public void OnclickSoundButton()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            SoundBtn.GetComponent<Image>().sprite = soundOff;
            numberVoiceSource.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = soundOn;
            numberVoiceSource.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Sound", 1);
        }
    }


}
