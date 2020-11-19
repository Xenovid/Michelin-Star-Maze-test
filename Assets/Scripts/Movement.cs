using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject statimaBar;
    //public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public float gravity = -9.81f;
    public float sprintSpeed;
    public float maxStatima;

    public Transform groundCheck;
    public float groundDistace;
    public LayerMask groundMask;
    private bool isSprinting = false;
    private float statima;

    bool isGrounded;
    Vector3 velocity;

    private void Start()
    {
        statima = maxStatima;
    }

    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistace, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(statima > 0 && Input.GetAxis("Sprint") == 1)
        {
            isSprinting = true;
            statima -= Time.deltaTime;
        }
        else
        {
            isSprinting = false;
            if (statima <= maxStatima)
            {
                statima += 4 * Time.deltaTime;
            }
        }

        if(direction.magnitude >= 0.1f){
            if (isSprinting)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir * speed * Time.deltaTime + (Time.deltaTime * moveDir * Input.GetAxis("Sprint") * (sprintSpeed - 1)));
            }
            else
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir * speed * Time.deltaTime);
            }
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
