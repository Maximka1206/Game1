using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 5f; // Скорость движения
    public float mouseSensitivity = 2f; // Чувствительность мыши

    private CharacterController controller;
    private float verticalSpeed = 0f;
    private float gravity = -9.8f;
    private Transform cameraTransform;

    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked; // Убираем курсор из окна игры
    }

    void Update()
    {
        // Управление мышью
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, mouseX, 0); // Поворот тела игрока
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90); // Ограничиваем наклон камеры
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Управление движением
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        verticalSpeed += gravity * Time.deltaTime;

        controller.Move(move * speed * Time.deltaTime + Vector3.up * verticalSpeed * Time.deltaTime);

        // Обнуляем вертикальную скорость, если на земле
        if (controller.isGrounded)
        {
            verticalSpeed = 0;
        }
    }
}
