using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject m_target;
    [SerializeField] Vector3 m_ofset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = m_target.transform.position;
        this.gameObject.transform.position = pos + m_ofset;
    }
}
