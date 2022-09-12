using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantAI : MonoBehaviour
{
    public Animator animator;
    public int moveSpeed = 3;
    private Transform player;
    private float timer;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        // Init
        player = FindObjectOfType<PlayerMovement>().transform;
        animator = gameObject.GetComponent<Animator>();
        timer = Random.Range(2,4);
        rb = gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();

        // Initial movement
        RandomMovement();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            RandomMovement();
            timer = Random.Range(2,4);
        }
    }

    void RandomMovement()
    {
        if (Random.Range(0,2) > 0)
        {
            movement.x = Random.Range(-moveSpeed, moveSpeed+1);
            movement.y = 0;
        } else {
            movement.x = 0;
            movement.y = Random.Range(-moveSpeed, moveSpeed+1);
        }
        if (movement.x > 0) {renderer.flipX = false;}
        else {renderer.flipX = true;}
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.deltaTime);
    }
}
