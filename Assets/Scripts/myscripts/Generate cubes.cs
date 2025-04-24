using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generatecubes : MonoBehaviour
{
    [SerializeField] GameObject Spawn;
    [SerializeField] float counter;
    [SerializeField] float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > counter)
        {
            Vector3 ubicacion = new Vector3(transform.position.x, transform.position.y, Random.Range(transform.position.z-2.5f, transform.position.z+1.5f)) ;
           GameObject cube =  Instantiate(Spawn);
            cube.transform.position = ubicacion;
            timer = 0;
        }
    }
}
