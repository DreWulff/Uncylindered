using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform fist;
    Vector2 movement;
    private float inputX;
    private float inputY;
    private float moveSpeedDiag;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        inputX = Input.GetAxisRaw("Horizontal");
        // movement.x = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        if (inputX * inputY != 0)
        {
            moveSpeedDiag = Mathf.Sqrt(moveSpeed*moveSpeed/2);
            movement.x = inputX * moveSpeedDiag;
            movement.y = inputY * moveSpeedDiag;
        }
        else
        {
            movement.x = inputX * moveSpeed;
            movement.y = inputY * moveSpeed;
        }
        if ((inputX == 0) && (inputY == 0))
        {
            angle = 0;
        }
        else
        {
            angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg + 90;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // Fist origin rotation
        fist.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }
}
