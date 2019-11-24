using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilPointManager : MonoBehaviour
{
    [SerializeField] int m_helthEX = 10;
    [SerializeField] float m_atackMaguni = 1.1f;
    [SerializeField] float m_speedMaguni = 1.1f;
    [SerializeField] int m_skilPoint = 0;
    GameObject m_playerData;
    Component m_player;
    // Start is called before the first frame update
    void Start()
    {
       
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
