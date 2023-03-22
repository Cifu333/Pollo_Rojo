using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    enum Direction { UP, DOWN };
    Animator anim;
    Rigidbody2D rb;
    public float jetForce = 2;
    public float jetDown = 6;

    private Direction direction;

    private float dashCoolCounter;
    public float dashTime = 1f;

    public float dashDuration = 0.5f;
    private float dashCounter;

    public float dashSpeed;

    public bool dash = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jetForce = jetForce / jetDown;
        direction = Direction.UP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                dash = true;
                if (direction == Direction.UP)
                {
                    if (dashSpeed < 0)
                        dashSpeed = -dashSpeed;
                }
                else if (direction == Direction.DOWN)
                {
                    if (dashSpeed > 0)
                        dashSpeed = -dashSpeed;
                }
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0;

                dashCounter = dashDuration;
            }
        }

        if (dashCounter > 0)
        {
            transform.position += new Vector3(0, dashSpeed) * Time.deltaTime;
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                dashCoolCounter = dashTime;
                dash = false;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (rb.velocity.y < 0)
                rb.velocity = rb.velocity / 2 * Time.deltaTime;
            rb.AddForce(rb.transform.up * jetForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            direction = Direction.UP;
            //effect.Play();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (rb.velocity.y > 0)
                rb.velocity = rb.velocity / 2 * Time.deltaTime;
            rb.AddForce(-rb.transform.up * jetForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            direction = Direction.DOWN;
            //effect.Play();
        }

        if ((rb.velocity.y > 0 || rb.velocity.y < 0) && !Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z) && !dash)
        {
            rb.velocity = rb.velocity / 2 * Time.deltaTime;
        }
    }


}
