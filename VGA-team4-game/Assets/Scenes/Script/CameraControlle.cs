using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlle : MonoBehaviour
{
    [SerializeField] float m_cameraSpead = 1f;
    [SerializeField] Camera m_maincamera;
    // Start is called before the first frame update
    void Start()
    {
        m_maincamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiR = Input.GetAxisRaw("HorizontalR");
        float verR = Input.GetAxisRaw("VerticalR");
        float absHoriR = Mathf.Abs(horiR);
        float absVerR = Mathf.Abs(verR);
        if (absHoriR > 0.1f && absVerR > 0.1f)
        {
            if (absHoriR > absVerR)
            {
                this.gameObject.transform.Rotate(Vector3.up * horiR * m_cameraSpead);
            }
            else
            {
                this.gameObject.transform.Rotate(Vector3.right * verR * m_cameraSpead);
            }
        }
        else
        {
            if (absHoriR > 0.1f)
            {
                this.gameObject.transform.Rotate(Vector3.up * horiR * m_cameraSpead);
            }
            else if (absVerR > 0.1f)
            {
                this.gameObject.transform.Rotate(Vector3.right * verR * m_cameraSpead);
            }
        }

        var angle = this.gameObject.transform.eulerAngles;
        angle.z = 0.0f;
        this.gameObject.transform.eulerAngles = angle;
    }
    
    
}
