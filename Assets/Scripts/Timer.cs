using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // Initial time in seconds
    private TextMeshProUGUI timerText;
  public bool isGameStarted = false;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && isGameStarted)
        {
            timeRemaining -= Time.deltaTime; // Reduce timeRemaining by deltaTime

            // Format timeRemaining into minutes and seconds
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            // Update the UI Text element
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // Time's up!
            timerText.text = "Time's Up!";
        }
    }
}
