﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyContoroller : MonoBehaviour
{
    [SerializeField] float m_enemyHP = 100;
    [SerializeField] int m_score = 100;
    //[SerializeField] float m_eAtack = 1f;
    [SerializeField] GameObject m_target;
    [SerializeField] float m_targetMargin = 0.1f;
    [SerializeField] float m_enemySpeadMagni = 1f;
    [SerializeField] Slider m_enemyHPSlider;
    [SerializeField] int m_damage = 10;
    [SerializeField] GameObject m_hitCollider;
    [SerializeField] float m_destroyTime = 5f;
    Animator m_animater;
    Vector3 m_targetPosition;
    NavMeshAgent m_navMesh;
    bool m_flag = false;
    // Start is called before the first frame update
    void Start()
    {
        m_navMesh = GetComponent<NavMeshAgent>();
        m_animater = GetComponent<Animator>();
        m_targetPosition = m_target.transform.position;
        //m_navMesh.speed = m_navMesh.speed * m_enemySpeadMagni;
        //m_enemyHPSlider = GetComponentInChildren<Slider>();
        m_enemyHPSlider.maxValue = m_enemyHP;
        m_enemyHPSlider.value = m_enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, m_target.transform.position) > m_targetMargin)
        {
            m_targetPosition = m_target.transform.position;
            m_navMesh.SetDestination(m_targetPosition);
            if (m_animater)
            {
                m_animater.SetFloat("Speed", m_navMesh.velocity.magnitude);
            }

            if (m_flag)
            {
                Death();
                m_flag = false;
            }
        }
        
    }

    public void UpDateSrider()
    {
        m_enemyHPSlider.value = m_enemyHP;
    }

    public void DecreaseHelth()
    {   
            m_enemyHP -= m_damage;
            m_animater.SetTrigger("Damage");
        if (m_enemyHP <= 0)
        {
            m_flag = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject ga = other.gameObject;
            PlayerController pc = ga.GetComponent<PlayerController>();
            pc.HitDamage(m_damage);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                m_animater.SetTrigger("Attack");
            }
    }

    public void Death()
    {
        m_navMesh.isStopped = true;
        m_animater.SetTrigger("Death");
        Destroy(this.gameObject, m_destroyTime);
    }
    public void ActivCollider()
    {
        m_hitCollider.SetActive(true);
    }

    public void EnableCollider()
    {
        m_hitCollider.SetActive(false);
    }
}
