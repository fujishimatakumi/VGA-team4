using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpead;
    [SerializeField] int m_helth = 100;
    [SerializeField] int m_level = 1;
    [SerializeField] float m_Atack = 1f;
    Rigidbody m_rb;
    Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
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
            m_anim.SetBool("Attack1Trigger", true);
        }

    }
}
