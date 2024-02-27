using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

[SerializeField] float xSpeed = 30f;
[SerializeField] float ySpeed = 30f;
[SerializeField] float xClamp = 10f;
[SerializeField] float yClamp = 8f;

[SerializeField] float positionPitchFactor = -2f;
[SerializeField] float controlPitchFactor = -5f;
[SerializeField] float positionYawFactor = 3f;
[SerializeField] float controlRollFactor = -5f;

[SerializeField] float minFlightHight = 0.5f;

private Vector2 movementInput;
private PlayerControls inputControls;

    private void Awake() {
        inputControls = new PlayerControls();
        inputControls.Train.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }


    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + movementInput.y * controlPitchFactor;

        float yaw = 0f;
        float roll = 0f;
        if(transform.localPosition.y >= minFlightHight)
        {
            yaw = transform.localPosition.x * positionYawFactor;
            roll = movementInput.x * controlRollFactor;
        }
  
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessTranslation()
    {
        float xMove = xSpeed * movementInput.x * Time.deltaTime;
        float yMove = ySpeed * movementInput.y * Time.deltaTime;

        float newY = Mathf.Clamp(transform.localPosition.y + yMove, 0f, yClamp);
        float newX = Mathf.Clamp(transform.localPosition.x + xMove, -xClamp, xClamp);

        if(newY < minFlightHight)
        {
            newX = 0;
        }

        transform.localPosition = new Vector3(newX, newY, 0f);
    }

    private void OnEnable() {
        inputControls.Enable();
    }

    private void OnDisable() {
        inputControls.Disable();
    }
    
}
