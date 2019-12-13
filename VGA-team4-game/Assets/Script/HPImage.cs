using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPImage : MonoBehaviour
{
    [SerializeField] Image m_im = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_im gaugeCtrl = GetComponent<Image>();
        gaugeCtrl.fillAmount =0 ;
    }
}
