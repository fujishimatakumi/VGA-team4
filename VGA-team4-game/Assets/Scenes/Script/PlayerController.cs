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
    [SerializeField] float m_resaltMargin = 3f;
    [SerializeField] float m_isGroundedLength = 0.2f;
    [SerializeField] float m_jumpPower = 5f;
    [SerializeField] int m_jumpLimit = 2;
    int m_jumpCounter = 0;
    float m_nowHP;
    Rigidbody m_rb;
    Animator m_anim;
    //[SerializeField] Slider m_HPslider = default;
    [SerializeField] GameObject m_hitCollider;
    [SerializeField] Image m_im = default;
    

    //GameObject m_skilPoint;
   // SkilPointManager m_manager;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
        m_im.fillAmount = m_helth;
        m_nowHP = m_helth;
        //m_HPslider.value = m_helth;
       // m_skilPoint = GameObject.Find("SkilPointManager");
     //   m_manager = m_skilPoint.GetComponent<SkilPointManager>();
       // m_helth = m_helth + m_manager.m_helthEX;
    }

    // Update is called once per frame
    void Update()
    {
        IsAttack();
        if (m_nowHP <= 0)
        {

            GameStatusManager gm = FindObjectOfType<GameStatusManager>();
            gm.GameOver();

        }

        if (Input.GetButtonDown("Fire1"))
        {   
            m_anim.SetTrigger("Attack1Trigger");
            if (IsAttack())
            {   
                return;
            }
        }
        if (!IsAttack())
        {  
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");
            Vector3 dir = Vector3.forward * v + Vector3.right * h;
            if (dir == Vector3.zero)
            {
                m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
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


            if (Input.GetButtonDown("Jump") && IsGrounded() && m_jumpCounter < m_jumpLimit)
            {
                if (m_anim)
                {
                    m_anim.SetTrigger("Jump");
                }
                m_rb.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
                m_jumpCounter++;
            }
            if (Input.GetKey("p"))
            {
                m_nowHP = 0;
            }
        }


        m_jumpCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject ga = other.gameObject;
            EnemyContoroller ec = ga.GetComponent<EnemyContoroller>();
            ec.DecreaseHelth();
            ec.UpDateSrider();
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

    public void HitDamage(int damege)
    {
        m_nowHP = m_nowHP - damege;
        m_im.fillAmount = m_nowHP / m_helth;
    }
    bool IsGrounded()
    {
        // Physics.Linecast() を使って足元から線を張り、そこに何かが衝突していたら true とする
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        Vector3 start = this.transform.position + col.center;   // start: 体の中心
        Vector3 end = start + Vector3.down * (col.center.y + col.height / 2 + m_isGroundedLength);  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする
        return isGrounded;
    }
    bool IsAttack()
    {
        bool isAttack = m_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1");
        return isAttack;
    }
}
