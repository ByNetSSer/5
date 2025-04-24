
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject[] Puntos;
    [SerializeField] Vector3 Vector;
    [SerializeField] Vector3 Scale;
    public Vector3 scaleVector = Vector3.one;
    // Update is called once per frame
    void Update()
    {
        //Transformar();
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < Puntos.Length; i++)
        {
            Puntos[i].GetComponent<PivodDrawin>().TranslatePivot(Vector);
            Puntos[i].GetComponent<PivodDrawin>().ScalePivot(Scale);
        }
    }
}
