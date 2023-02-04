using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float stamina;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public bool isSprinting = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (stamina > 150)
        {
            stamina = 150;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
        if (stamina <= 0 || stamina <= 1)
        {
            speed = 5f;
            stamina += 0.01f;
        }

        if (isSprinting && stamina >= 1)
        {
            speed = 7f;
            stamina -= 1;
        }
        else if (isSprinting == false && stamina < 150 && stamina > 1)
        {
            speed = 5f;
            stamina += 0.5f;
        }
    }
}
