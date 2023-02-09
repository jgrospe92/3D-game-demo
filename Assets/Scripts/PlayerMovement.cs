using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Instantiate the Rigibody
    Rigidbody rb;
    [SerializeField] private float mvmtSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Reference for audio source
    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get this rigidbody of the assigned script
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * mvmtSpeed, rb.velocity.y,verticalInput * mvmtSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground); ;
    }

    // check if player object collided with enemy head
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject); // refers to the enemy parent
            Jump(); // when it collided, the player jumps
        }
    }
}
