using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private static Text _messageText;
    public void Initialize(int type)
    {
        _messageText = GameObject.Find("Title").GetComponent<Text>();
        if(type == 0)
        {
            _messageText.text = "Game Over";
        }
        else
        {
            _messageText.text = "You Win!";
        }
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        GameObject.Find("Start").GetComponent<Button>().onClick.AddListener(startButton);
        GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(quitButton);
    }

    private void startButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void quitButton()
    {
        QuitGame();
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
