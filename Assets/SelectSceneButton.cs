using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SelectSceneButton : MonoBehaviour
{
    private VisualElement ui;
    private Button playYoussouf;
    private Button playUQAR;
    private Button playQuaiPaquet;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        playYoussouf = ui.Q<Button>("playYoussouf");
        playUQAR = ui.Q<Button>("playUQAR");
        playQuaiPaquet = ui.Q<Button>("playQuaiPaquet");

        // Add click listeners to each button
        playYoussouf.clicked += () => buttonCallback("YoussoufHome");
        playUQAR.clicked += () => buttonCallback("UQAR");
        playQuaiPaquet.clicked += () => buttonCallback("QuaiPaquet");
    }

    private void buttonCallback(string sceneName)
    {
        // Load the scene called sceneName
        SceneManager.LoadScene(sceneName);
    }
}