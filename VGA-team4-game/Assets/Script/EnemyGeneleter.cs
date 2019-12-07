using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneleter : MonoBehaviour
{
    [SerializeField] GameObject m_enemyObj;
    [SerializeField] float m_taimeMargin = 1f;
    float m_taimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_taimer = Time.deltaTime;
        if (m_enemyObj)
        {
            if (m_taimer >= m_taimeMargin)
            {
                Instantiate(m_enemyObj, this.gameObject.transform.position, Quaternion.identity);
                m_taimer = 0;
            }
        }
    }
}
