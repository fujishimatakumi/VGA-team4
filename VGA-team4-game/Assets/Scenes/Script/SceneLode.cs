using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLode : MonoBehaviour
{
    public bool m_resultFlug = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_resultFlug)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                LodeSceneMain();
            }
        }
        else if (!m_resultFlug)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                LodeSceneOpen();
            }
        }
    }

    public void LodeSceneMain()
    {
        Initiate.Fade("mainScene",Color.black,2f);

    }

    public void LodeSceneOpen()
    {
        Initiate.Fade("openScene",Color.black,2f);

    }
    
}
