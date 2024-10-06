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
    private Dictionary<int, string> hints1 = new Dictionary<int, string>()
    {
        {1,"In the middle of the next street" },
        {3,"At the end of this road"},
        {2,"At the biggest building" },
        {8,"Near a statue" },
        {7,"In the corner of a nearby parking" },
        {9,"In the entrance of a nearby parking" },
        {5,"In the entrace of a nearby parking" },
        {4,"Somewhere in this parking" },
        {0,"In the next street/parking" },
        {6,"Congrats this is the last hint" },
    };
    private Dictionary<int, string> hints3 = new Dictionary<int, string>()
    {
        {10,"10"}
    };
    private Dictionary<int, string> hints2 = new Dictionary<int, string>()
    {
        {1,"ici indice 1, un autre indice se trouve dans le plus veil endroit de la région"}
    };
    private Dictionary<string, string> historicalInfo = new Dictionary<string, string>()
    {
        {"1","Welcome to UQAR Lévis. Fondé en 1980, le campus de Lévis de l'UQAR est spécialisé dans la formation continue à temps partie en administration, en sciences infirmières et en sciences humaines." },
        {"2","Welcome to quai paquet. En avril 1864, le conseil municipal de Lévis décrète ce lieu comme terminus du traversier. Le chemin de fer Intercolonial atteint l'endroit en 1882. En 1912, le gouvernement du Canada entreprend la construction d'un quai en eau profond en comblant l'espace entre des quais déjà présents dont celui de la compagnie Paquet. L'entreprise y effectue du transbordement de charbon (avant 1950), de sel et de ciment1." },
        {"Youssouf Home","Welcome to Youssouf home, the home of the creator of the game. He studied there for 3 years." },
        {"No Zone","Welcome to the game. You are not in a game zone yet." }
    };
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
            //debugText.text += "entered collision with hint \n";
            counter++;
            //debugText.text += "hintCounter" + counter.ToString() + "\n";
            // Get the hint number from the collided object
            int hintNumber;
            if (int.TryParse(other.name, out hintNumber))
            {
                currentHint = hintNumber;
                ShowHint(currentHint);
               // debugText.text = "hintCounter" + currentHint.ToString() + "\n";
            }

            Destroy(other.gameObject);
        }
    }

    private void ShowHint(int hintNumber)
    {
        hint.text = hints1[hintNumber] + " " + counter + "/10";
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
