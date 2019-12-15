using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LodeSceneMain()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void LodeSceneOpen()
    {
        SceneManager.LoadScene("openScene");
    }
    
}
