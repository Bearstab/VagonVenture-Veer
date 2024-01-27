using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momentum : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Horizontal") * speed;
        Vector3 moveDirection = transform.forward * moveAmount;
        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else
        {
            float rotationDifference = Quaternion.Angle(transform.rotation, originalRotation);
            if (rotationDifference > 0.1f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
