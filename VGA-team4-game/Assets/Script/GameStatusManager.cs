using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField] Text m_clearRimitText;
    int m_clearRimit;
    GameStatus m_status = GameStatus.BeforeGeneration;
    [SerializeField] float m_generateMargin = 3f;
    float m_timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        m_clearRimitText.text = m_clearRimit.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_clearRimit <= 0)
        {
            GameClear();
        }
    }

    public void UpDateScore(int rimit)
    {
        m_clearRimit -= rimit;
        m_clearRimitText.text = m_clearRimit.ToString();
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverResalt");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClearResalt");
    }
}

enum GameStatus
{
    BeforeGeneration,
    NowGaming,
    GameResalt,
}