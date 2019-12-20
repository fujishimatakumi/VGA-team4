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
