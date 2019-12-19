using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlle : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float horiR = Input.GetAxis("HorizontalR");
        float verR = Input.GetAxis("VerticalR");
        Vector3 dir = Vector3.up * horiR + Vector3.right * verR;

        if ((horiR != 0) || (verR != 0))
        {
            this.gameObject.transform.Rotate(dir);
        }
        else
        {
            this.gameObject.transform.Rotate(Vector3.zero);
        }
    }
}
