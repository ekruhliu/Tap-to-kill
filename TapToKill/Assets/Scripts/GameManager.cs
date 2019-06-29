using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IStartExit
{
    public bool OnPause;

    const int timeScaleOnPause = 0;
    const int timeScaleOnGame = 1;

    [SerializeField] private GameObject PausePanel;

    void Awake() { Time.timeScale = timeScaleOnGame; }

    public void PauseGame()
    {
        if (!OnPause)
        {
            OnPause = true;
            Time.timeScale = timeScaleOnPause;
            PausePanel.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        OnPause = false;
        Time.timeScale = timeScaleOnGame;
        PausePanel.SetActive(false);
    }

    public void StartGame() { SceneManager.LoadScene("MainGame"); }

    public void ExitGame() { Application.Quit(); }
}
