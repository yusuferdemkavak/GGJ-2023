using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public StaminaBar stamBar;
    public float stamina;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public bool isSprinting = false;
    public Animator animator;
    public GameObject ui;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        stamBar = GetComponent<StaminaBar>();
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

        animator.SetFloat("Speed", Mathf.Abs(moveVelocity.x));

        if(Mathf.Abs(moveVelocity.x) > 5)
        {
            animator.SetBool("IsSprinting", isSprinting);
        }
        else
        {
            animator.SetBool("IsSprinting", false);
        }


        if (moveVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveVelocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && gameObject.GetComponent<Inventory>().fruitAmount > 0 && ui.GetComponent<UIManager>().slotNumber == 0)
        {
            gameObject.GetComponent<Inventory>().fruitAmount -= 1;
            stamina += 50;
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
            speed = 8f;
            stamina -= 1;
        }
        else if (isSprinting == false && stamina < 150 && stamina > 1)
        {
            speed = 5f;
            stamina += 0.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Monster")
        {
            animator.SetBool("IsAlive", false);
            ui.GetComponent<UIManager>().didWon = false;
            ui.GetComponent<UIManager>().GameOver();
            Destroy(gameObject, 1f);
        }
    }
}
