using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementcubes : MonoBehaviour
{
   [SerializeField] float Speed = 5f;
    [SerializeField] float Force;
    public bool gravedad = false;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime,transform.position.y, transform.position.z);
        if (gravedad)
        {
            
        }
    }
    private void Start()
    {
        Play.Onplay += Getforce;
        Destroy(this.gameObject,20);
    }
    public void Getforce()
    {
       // transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * Force* Time.deltaTime);
        //transform.(Vector3.up * Force);
        gravedad = true;
    }
    private void OnEnable()
    {
        Play.Onplay += Getforce;
    }
    private void OnDisable()
    {
        Play.Onplay -= Getforce;
    }
}
