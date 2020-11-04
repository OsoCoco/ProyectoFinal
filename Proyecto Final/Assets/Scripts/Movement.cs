using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Movement : NetworkBehaviour
{
    Vector3 startPos = new Vector3(0, 1, 0);
    public float speed = 6f;
    public float turningSmoothtime = 0.1f;
    float turningSmoothVelocity;
    Joystick joystick;


    CharacterController characterController;
        
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        joystick = FindObjectOfType<Joystick>();
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
            Move();
    }

    void Move()
    {
        float z = joystick.Vertical;
        float x = joystick.Horizontal;

        Vector3 direction = new Vector3(x, 0, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turningSmoothVelocity, turningSmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
