using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyContoroller : MonoBehaviour
{
    [SerializeField] int m_enemyHP = 100;
    [SerializeField] int m_score = 100;
    [SerializeField] float m_eAtack = 1f;
    [SerializeField] GameObject m_target;
    [SerializeField] float m_targetMargin = 0.1f;
    [SerializeField] Animator m_animater;
    [SerializeField] float m_enemySpeadMagni = 1f;
    Slider m_enemyHPSlider;
    Vector3 m_targetPosition;
    NavMeshAgent m_navMesh;
    // Start is called before the first frame update
    void Start()
    {
        m_navMesh = GetComponent<NavMeshAgent>();
        m_targetPosition = m_target.transform.position;
        m_navMesh.speed = m_navMesh.speed * m_enemySpeadMagni;
        m_enemyHPSlider = GetComponentInChildren<Slider>();
        m_enemyHPSlider.maxValue = m_enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(m_targetPosition, m_target.transform.position) > m_targetMargin)
        {
            m_targetPosition = m_target.transform.position;
            m_navMesh.SetDestination(m_targetPosition);
        }

        if (m_animater)
        {
            m_animater.SetFloat("Speed", m_navMesh.velocity.magnitude);
        }
    }
}
