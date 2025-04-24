using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float MinRotation = 5f;
    [SerializeField] float MaxRotation = 15f;
    [SerializeField] float Speed= 1;
    public float RotationX;
    public float RotationY;
    public float RotationZ;
   
    // Start is called before the first frame update
    void Start()
    {
        RotationX = Random.Range(MinRotation, MaxRotation);
        RotationY = Random.Range(MinRotation, MaxRotation);
        RotationZ = Random.Range(MinRotation, MaxRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 rotationDirection = new Vector3(RotationX, RotationY, RotationZ);
        transform.Rotate(rotationDirection * Speed * Time.deltaTime);
        
    }
}
