using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField] GameObject m_target;
    RaycastHit m_hitInfo = new RaycastHit();
    [SerializeField] LayerMask m_hitLayer = default;
    float m_targetDis = 0f;
    Vector3 m_defoltPos;
    // Start is called before the first frame update
    void Start()
    {
        m_targetDis = Vector3.Distance(transform.position, m_target.transform.position);
        m_defoltPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_targetDis = Vector3.Distance(transform.position, m_target.transform.position);
        
        Vector3 lookTargetPos = transform.position;
        
            Vector3 cameraPos = m_defoltPos;
            
                Vector3 targetDir = (m_target.transform.position - lookTargetPos).normalized;
                float targetDis = m_targetDis - 0.5f;

                Debug.DrawRay(lookTargetPos, targetDir * targetDis, Color.red);

                bool isHit = Physics.Raycast(lookTargetPos, targetDir, out m_hitInfo, targetDis, m_hitLayer);
                if (isHit)
                {
                    Vector3 hitpos = m_hitInfo.point;
                    Debug.Log("hit");
                    transform.position = hitpos;
                }
            
            transform.localPosition = m_defoltPos;
        
    }
}
