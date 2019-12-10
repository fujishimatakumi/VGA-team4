using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField] Text m_clearRimitText;
    int m_clearRimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
              
    }

    public void UpDateScore(int rimit)
    {
        m_clearRimit = rimit;
        m_clearRimitText.text = m_clearRimit.ToString();
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverResalt");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClearResalt");
    }
}
