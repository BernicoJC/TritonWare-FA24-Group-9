using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    // private bool isFacingRight = true;
    public float speed = 10f;
    //private float dodgingTime = 0.05f;
    public bool cantWalk = false;
    [SerializeField] private Rigidbody2D rb;

    public GameObject doctor;
    public GameObject doctor_side;
    private RearrangeDoctor rearrangeDoctor;
    private RearrangeDoctorSide rearrangeDoctorSide;
    private Vector3 localScale;

    private Animator doctorAnimator;
    private Animator doctorSideAnimator;

    void Start()
    {
        transform.position = new Vector3(50f, -50f, 0f);
        localScale = transform.localScale;
        rearrangeDoctor = doctor.GetComponent<RearrangeDoctor>();
        rearrangeDoctorSide = doctor_side.GetComponent<RearrangeDoctorSide>();

        doctorAnimator = doctor.GetComponent<Animator>();
        doctorSideAnimator = doctor_side.GetComponent<Animator>();

        doctor.SetActive(true);
        doctor_side.SetActive(false);
        rearrangeDoctor.front();

    }

    // Update is called once per frame
    void Update()
    {
        // getting movement input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        // Check if need to flip every frame update
        ChangeDirection();
        ChangeAnimation();
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

    private void ChangeDirection()
    {
        // If facing right and input to left, flip (vise versa)
        // if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        // {
        //     isFacingRight = !isFacingRight;

        //     // transform sprite horizontally
        //     Vector3 localScale = transform.localScale; // I think since this script is attached to object, it's like this.transform.localScale
        //     localScale.x *= -1f;
        //     transform.localScale = localScale;
        // }

        if (horizontal != 0)
        {
            transform.localScale = localScale;
            doctor.SetActive(false);
            doctor_side.SetActive(true);
            if (horizontal < 0)
            {
                rearrangeDoctorSide.left();
            }
            if (horizontal > 0)
            {
                rearrangeDoctorSide.right();
                Vector3 flipScale = localScale;
                flipScale.x *= -1;
                transform.localScale = flipScale;
            }
        }
        if (vertical != 0)
        {
            transform.localScale = localScale;
            doctor.SetActive(true);
            doctor_side.SetActive(false);
            if (vertical < 0)
            {
                rearrangeDoctor.front();
            }
            if (vertical > 0)
            {
                Vector3 flipScale = localScale;
                flipScale.x *= -1;
                transform.localScale = flipScale;
                rearrangeDoctor.back();
            }
        }
    }

    private void ChangeAnimation()
    {
        if (horizontal == 0 && vertical == 0)
        {
            if (doctor.activeSelf)
            {
                doctorAnimator.SetBool("isWalking", false);
            }
            if (doctor_side.activeSelf)
            {
                doctorSideAnimator.SetBool("isWalking", false);
            }
        }
        else
        {
            if (doctor.activeSelf)
            {
                doctorAnimator.SetBool("isWalking", true);
            }
            if (doctor_side.activeSelf)
            {
                doctorSideAnimator.SetBool("isWalking", true);
            }
        }
    }
}
