using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float turnSmooth;
    float turnVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 movement = new Vector3(x, 0f, z).normalized;

        if(movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(movement * speed * Time.deltaTime);

        }
    }
}
