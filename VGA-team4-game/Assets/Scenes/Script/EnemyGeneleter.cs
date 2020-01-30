using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneleter : MonoBehaviour
{
    [SerializeField] GameObject m_enemyObj;
    [SerializeField] float m_taimeMargin = 1f;
    float m_taimer = 0;
    [SerializeField] bool m_flag = false;
    public static int m_rimit;
    GameStatusManager m_gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("GameStatusManager");
        m_gameStatus = go.GetComponent<GameStatusManager>();
        m_rimit = 0;
        StartGenerat();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_flag)
        {
            if (m_enemyObj)
            {
                m_taimer += Time.deltaTime;
                if (m_taimer >= m_taimeMargin)
                {
                    Instantiate(m_enemyObj, this.gameObject.transform.position, Quaternion.identity);
                    m_rimit++;
                    m_taimer = 0;
                }
            }
        }
        if (m_rimit >= m_gameStatus.m_clearRimit)
        {
            StopGenerat();
        }
        else if (m_rimit < m_gameStatus.m_clearRimit)
        {
            StartGenerat();
        }
    }

    public void StartGenerat()
    {
        m_flag = true;
    }

    public void StopGenerat()
    {
        m_flag = false;
    }
}
