using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_Text NameText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void SetName(string name)
    {
        NameText.text = "Your name is: " + name;
        ServerConnector.PlayerName = name;
    }
}
