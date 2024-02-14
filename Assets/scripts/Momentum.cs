using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momentum : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float maxTiltAngle = 35f;
    public float maxNegativeTiltAngle = -35f;
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
        Vector3 moveDirection = new Vector3(moveAmount, 0f, speed); // Z ekseninde sabit bir hızda ilerleme ekledik
        rb.velocity = moveDirection;

        if (Input.GetKey(KeyCode.A))
        {
            float tiltAngle = Mathf.Clamp(transform.localEulerAngles.x - rotationSpeed * Time.deltaTime, -maxTiltAngle, maxNegativeTiltAngle);
            Vector3 newRotation = new Vector3(tiltAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.localEulerAngles = newRotation;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            float tiltAngle = Mathf.Clamp(transform.localEulerAngles.x + rotationSpeed * Time.deltaTime, -maxNegativeTiltAngle, maxTiltAngle);
            Vector3 newRotation = new Vector3(tiltAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.localEulerAngles = newRotation;
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

