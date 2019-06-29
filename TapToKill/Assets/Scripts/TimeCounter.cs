using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    float gameTime;
    public bool  gameEnd;

    const int timeScaleOnPause = 0;

    [SerializeField] private Text TextGameTime;
    [SerializeField] private GameObject EndGamePanel;

    void Awake() { gameTime = 61.0f; }

    void Update()
    {
        gameTime -= Time.deltaTime;
        TextGameTime.text = "Time: " + ((int)gameTime).ToString();

        if (gameTime <= 0)
            EndGame();
    }

    void EndGame()
    {
        gameEnd = true;
        Time.timeScale = timeScaleOnPause;
        EndGamePanel.SetActive(true);
    }
}
