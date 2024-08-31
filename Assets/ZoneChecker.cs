using TMPro;
using UnityEngine;
public class ZoneChecker : MonoBehaviour
{
    private TextMeshProUGUI t; [SerializeField] public string zone = "No Zone";
    public float objectif = 40f;
    private Timer timerScript; // Start is called before the first frame update
    void Start()
    {
        t = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextMeshProUGUI>();
        GameObject timerObject = GameObject.Find("timer"); if (timerObject != null)
        {
            timerScript = timerObject.GetComponent<Timer>();
        }
    }
    private void OnTriggerEnter(Collider other)
    { // Check if the collider is the camera and if the game has started

        if (other.CompareTag("MainCamera") && timerScript != null) { t.text = zone; timerScript.isGameStarted = true; }
    }
}


