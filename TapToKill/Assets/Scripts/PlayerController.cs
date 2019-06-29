using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int score;
    [SerializeField] private Text TextScore;
    [SerializeField] private TimeCounter timeCounter;
    [SerializeField] private GameManager gameManager;

    private void Awake() { score = 0; }

    private void Update()
    {
        TextScore.text = "Score: " + score.ToString();
        touch();
    }

    void touch()
    {
        if (!timeCounter.gameEnd && !gameManager.OnPause)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Bomb")
                    {
                        if (score > 0)
                            score--;
                    }
                    else if (hit.collider.gameObject.tag == "Star")
                        score++;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
