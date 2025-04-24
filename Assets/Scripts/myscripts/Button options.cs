using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonoptions : MonoBehaviour
{
    [SerializeField] GameObject Camara;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Option()
    {
        Time.timeScale = 0.7f;
        Camara.SetActive(true);
    }
}
