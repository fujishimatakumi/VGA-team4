using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpead = 1f;
    [SerializeField] int m_helth = 100;
    [SerializeField] int m_level = 1;
    [SerializeField] float m_Atack = 1f;
    Rigidbody m_rb;
    Animator m_anim;
    [SerializeField] Slider m_HPslider = default;
    [SerializeField] GameObject m_hitCollider;
    //GameObject m_skilPoint;
   // SkilPointManager m_manager;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
        m_HPslider.value = m_helth;
       // m_skilPoint = GameObject.Find("SkilPointManager");
     //   m_manager = m_skilPoint.GetComponent<SkilPointManager>();
       // m_helth = m_helth + m_manager.m_helthEX;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        if (dir == Vector3.zero)
        {
            m_rb.velocity = new Vector3(0f,m_rb.velocity.y,0f);
            m_anim.SetBool("Moving", false);
        }
        else
        {
            m_anim.SetBool("Moving", true);
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;
            this.transform.forward = dir;
            
            Vector3 velo = this.transform.forward * m_moveSpead;
            velo.y = m_rb.velocity.y;
            m_rb.velocity = velo;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            m_anim.SetTrigger("Attack1Trigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject ga = other.gameObject;
            EnemyContoroller ec = ga.GetComponent<EnemyContoroller>();
            ec.DecreaseHelth();
        }
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
