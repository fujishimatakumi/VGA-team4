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
                this.gameObject.transform.Rotate(Vector3.up * horiR);
            }
            else
            {
                this.gameObject.transform.Rotate(Vector3.right * verR);
            }
        }
        else
        {
            if (absHoriR > 0.1f)
            {
                this.gameObject.transform.Rotate(Vector3.up * horiR);
            }
            else if (absVerR > 0.1f)
            {
                this.gameObject.transform.Rotate(Vector3.right * verR);
            }
        }

        var angle = this.gameObject.transform.eulerAngles;
        angle.z = 0.0f;
        this.gameObject.transform.eulerAngles = angle;
    }
}
