using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 170f;

    [SerializeField] private float moveSpeed = 12f;


    private CharacterController charController;

    [SerializeField]private Transform mainCameraContainer;

    float xRotation = 0f;
    bool rotationIsLocked = true;

    private Vector3 lastPosition;
    public float speedMultiplier = 1;

    IEnumerator Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yield return new WaitForSeconds(0.5f);
        mainCameraContainer.localRotation = Quaternion.Euler(0, 0, 0);
        rotationIsLocked = false;

        lastPosition = this.transform.position;
    }

    void Update()
    {
        
        if(!rotationIsLocked)
            HandleRotation();
        
        HandleMovement();
        AddGravity();
    }




    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.Rotate(Vector3.up * mouseX);

        mainCameraContainer.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }


    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        speedMultiplier = 2.0f;
        if (this.transform.position.y > lastPosition.y)
        {
            speedMultiplier = 2.0f;
        }
        else if (this.transform.position.y < lastPosition.y)
        {
            speedMultiplier = 10.0f;
        }

        speedMultiplier = 2.0f;

        Vector3 move = transform.right * x + transform.forward * z;
        charController.Move(move * (moveSpeed*speedMultiplier)* Time.deltaTime);

        if (lastPosition != this.transform.position)
        {
            lastPosition = this.transform.position;
        }
    }

    private void AddGravity()
    {
        charController.Move(Physics.gravity);
    }
}
