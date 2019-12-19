using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlle : MonoBehaviour
{
    Camera m_mc;
    Vector3 m_anker;
    Transform m_target;
    // Start is called before the first frame update
    void Start()
    {
        m_mc = this.gameObject.transform.GetComponentInChildren<Camera>();
        m_anker = m_mc.gameObject.transform.position;
        m_target = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horiR = Input.GetAxisRaw("HorizontalR");
        float verR = Input.GetAxisRaw("VerticalR");
        Vector3 dir = Vector3.up * horiR + Vector3.right * verR;
        

        if (dir == Vector3.zero)
        {
            this.gameObject.transform.Rotate(Vector3.zero);
        }
        else
        {
            this.gameObject.transform.Rotate(dir);
        }
    }
}
