using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UIElements;   
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    private VisualElement debugUI;
    private int counter = 0;
    public int currentHint = 1; // Initial hint number
    private TextMeshProUGUI hint; //the int game object
    private bool coroutineIsPlay;
    private Label debugText;
    private bool security = false;
    private string zone = "No Zone";
    private Dictionary<int, string> hintsYoussoufHome = HintData.hintYoussoufHome;
    private Dictionary<int, string> hintsQuaiPaquet = HintData.hintsQuaiPaquet;
    private Dictionary<int, string> hintsUQAR = HintData.hintsUQAR;
    private Dictionary<string, string> historicalInfo = HistoricalInfo.historicalInfo;
    private void Awake()
    {
        debugUI = GetComponent<UIDocument>().rootVisualElement;
        debugText = debugUI.Q<Label>("debugText");
    }
    private void Start()
    {
        zone = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextMeshProUGUI>().text;
        hint = GameObject.FindGameObjectWithTag("hintText").GetComponent<TextMeshProUGUI>();

        debugText.text="App Started";
        hint.text = historicalInfo[zone];
        StartCoroutine(SecurtiyAwakeCollisionWithGemmes());

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a hint
        if (other.CompareTag("hint") && security == true)
        {
            StartCoroutine(IEShowHint());
            debugText.text += "entered collision with hint \n";
            counter++;
            debugText.text += "hintCounter" + counter.ToString() + "\n";
            // Get the hint number from the collided object
            int hintNumber;
            if (int.TryParse(other.name, out hintNumber))
            {
                currentHint = hintNumber;
                ShowHint(currentHint);
                debugText.text = "hintCounter" + currentHint.ToString() + "\n";
            }

            Destroy(other.gameObject);
        }
    }

    private void ShowHint(int hintNumber)
    {
        hint.text = hintsYoussoufHome[hintNumber] + " " + counter + "/10";
    }
    private void Update()
    {
        zone = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextMeshProUGUI>().text;

        if (!coroutineIsPlay)
        {
            hint.text = historicalInfo[zone];
        }
    }

    IEnumerator IEShowHint()
    {
        coroutineIsPlay = true;
        yield return new WaitForSeconds(6f);
        coroutineIsPlay = false;
    }
    IEnumerator SecurtiyAwakeCollisionWithGemmes()
    {
        yield return new WaitForSeconds(10f);
        security = true;
    }
}
