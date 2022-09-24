using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;
    Animator animator;
    float inputX , inputY;
    float stopX,stopY;
    // Start is called before the first frame update
    Vector3 offset;
    void Start()
    {
        offset = Camera.main.transform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Camera.main.transform.position = transform.position + offset;
    }

    void move()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(inputX, inputY).normalized;//标准化后防止xy轴向量值叠加
        rb.velocity = input * speed;

        if(input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        animator.SetFloat("InputX", stopX);
        animator.SetFloat("InputY", stopY);
    }
    
}
