using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1000f;
    [SerializeField] private float rotationSpeed = 100f;

    private Vector2 movementValue;
    private Vector2 lookValue;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //rb = GetComponent<Rigidbody>();
    }

    void Start() // ERROR PROBABLY HERE
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>();//* speed
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>() ; //* rotationSpeed
    }

  

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 force = new Vector3(movementValue.x, 0, movementValue.y) * speed * Time.deltaTime;
        rb.AddRelativeForce(force);
        float torque = lookValue.x * rotationSpeed * Time.deltaTime;
        rb.AddRelativeTorque(0, torque, 0);
    }
}
