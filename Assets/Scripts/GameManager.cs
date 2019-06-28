using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IStartExit
{
    bool OnPause;
    int timeScaleOnPause;
    int timeScaleOnGame;
    float gameTime;
    int score;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject EndGamePanel;
    [SerializeField] private Text TextScore;
    [SerializeField] private Text TextGameTime;
    [SerializeField] private Text EndGameScore;

    void Awake()
    {
        timeScaleOnPause = 0;
        timeScaleOnGame = 1;
        gameTime = 61.0f;
        score = 0;
        Time.timeScale = timeScaleOnGame;
    }

    void Start()
    {
        InvokeRepeating("InstantiateObjects", 0, 3);
    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        TextGameTime.text = "Time: " + ((int)gameTime).ToString();
        TextScore.text = "Score: " + score.ToString();
        if (gameTime <= 0)
            EndGame();
        touch();
    }

    void touch()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
        //    if (hit.collider != null)
        //    {
        //        Destroy(hit.collider.gameObject);
        //        score++;
        //    }
        //}
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (ray.collider != null)
            {
                if (ray.collider.gameObject.tag == "Bomb")
                {
                    if (score > 0)
                        score--;
                }
                else if (ray.collider.gameObject.tag == "Star")
                    score++;
                Destroy(ray.collider.gameObject);
            }
        }
    }

    void InstantiateObjects()
    {
        if (Random.Range(0, 5) > 2)
            Instantiate(new StarFactory().CreateObject());
        else
            Instantiate(new BombFactory().CreateObject());
    }

    void    EndGame()
    {
        OnPause = true;
        Time.timeScale = timeScaleOnPause;
        EndGameScore = TextScore;
        EndGamePanel.SetActive(true);
    }

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
