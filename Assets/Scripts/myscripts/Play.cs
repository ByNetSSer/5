using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Play : MonoBehaviour
{
    public static event Action Onplay;
    [SerializeField] GameObject Camara;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PLayButton()
    {
        Camara.SetActive(false) ;
        Onplay.Invoke();
    }
    public void PLayButtonTest()
    {
        Debug.Log("Se dio al boton");
    }
    private void OnEnable()
    {
        Onplay += PLayButtonTest;
    }
    private void OnDisable()
    {
        Onplay -= PLayButtonTest;
    }
}
