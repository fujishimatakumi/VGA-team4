﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkilPointManager : MonoBehaviour
{
    [SerializeField] public int m_helthEX = 10;
    [SerializeField] public float m_atackMaguni = 1.1f;
    [SerializeField] public float m_speedMaguni = 1.1f;
    [SerializeField] public int m_skilPoint = 0;
    //GameObject m_playerData;
    //Component m_player;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSkilPoint(int skilpoint)
    {
        m_skilPoint += skilpoint;
    }
}
