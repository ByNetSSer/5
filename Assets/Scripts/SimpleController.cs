using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5f;

    [Header("Raycast Properties")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private Color rayDebugColor = Color.red;

    [Header("Cinemachine Properties")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private float shakeIntensity = 2.5f;
    [SerializeField] private float shakeDuration = 5f;

    private Vector3 movement;
    private Rigidbody myRB;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), myRB.velocity.y, Input.GetAxisRaw("Vertical")); 

        canJump = Physics.Raycast(transform.position, Vector3.down, rayDistance, groundLayers);

        Debug.DrawRay(transform.position, Vector3.down * rayDistance, rayDebugColor);

        if (Input.GetKeyDown(KeyCode.O))
        {
            cameraController.ShakeCameraSimple(shakeIntensity, shakeDuration);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            cameraController.ShakeCameraGradual(shakeIntensity, shakeDuration);
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = Vector3.Scale(movement, new Vector3(speed, 1, speed));

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
