﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField] Text m_clearRimitText;
    [SerializeField] public int m_clearRimit;
    GameStatus m_status = GameStatus.BeforeGeneration;
    [SerializeField] public float m_generateMargin = 3f;
    [SerializeField] public int m_decleacRimit = 1;
    public float m_timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        m_clearRimitText.text = "あと" + m_clearRimit.ToString() + "体倒せ！";
    }

    // Update is called once per frame
    void Update()
    {
        if (m_clearRimit <= 0)
        {
            GameClear();
        }

        if (Input.GetKey("o"))
        {
            GameClear();
        }
    }

    public void UpDateScore()
    {
        m_clearRimit -= m_decleacRimit;
        m_clearRimitText.text = "あと" + m_clearRimit.ToString() + "倒せ！";
    }
    public void GameOver()
    {
        Initiate.Fade("GameOverResalt",Color.black,2);
    }

    public void GameClear()
    {
        Initiate.Fade("GameClearResalt",Color.black,2);
    }
}

enum GameStatus
{
    BeforeGeneration,
    NowGaming,
    GameResalt,
}