using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    private static Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        CurrentScore = 50;
        UpdateScore();
    }

    public void AddScore()
    {
        CurrentScore = Mathf.Max(0, CurrentScore -1);
        UpdateScore();
        if(CurrentScore == 0)
        {
            Object _menu = Resources.Load("Menu");
            GameObject menu = (GameObject)Object.Instantiate(_menu, new Vector3(0, 0, 0), new Quaternion());
            menu.GetComponent<Menu>().Initialize(1);
            Time.timeScale = 0;
        }
    }

    private void UpdateScore()
    {
        _scoreText.text = string.Format("{0}", CurrentScore).PadLeft(2, '0');
    }
}
