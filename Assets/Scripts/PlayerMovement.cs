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

    IEnumerator Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yield return new WaitForSeconds(0.5f);
        mainCameraContainer.localRotation = Quaternion.Euler(0, 0, 0);
        rotationIsLocked = false;
    }

    void Update()
    {
        
        if(!rotationIsLocked)
            HandleRotation();

        HandleMovement();
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

        Vector3 move = transform.right * x + transform.forward * z;
        charController.Move(move * moveSpeed* Time.deltaTime);

    }
}
