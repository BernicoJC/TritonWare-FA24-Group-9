using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;
    public float speed = 10f;
    //private float dodgingTime = 0.05f;
    public bool cantWalk = false;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // getting movement input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Check if need to flip every frame update
        Flip();
    }

    private void FixedUpdate()
    {
        if (cantWalk)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
    }

    private void Flip()
    {
        // If facing right and input to left, flip (vise versa)
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;

            // transform sprite horizontally
            Vector3 localScale = transform.localScale; // I think since this script is attached to object, it's like this.transform.localScale
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
