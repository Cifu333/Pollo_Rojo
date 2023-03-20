using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    private bool jetPack;
    public float jetForce = 2;
    public float jetDown = 6;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            if (rb.velocity.y > 0)
                rb.velocity = rb.velocity / 2;

            jetPack = true;
            rb.AddForce(rb.transform.up * jetForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            //effect.Play();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(-rb.transform.up * jetForce / jetDown * Time.fixedDeltaTime, ForceMode2D.Impulse);
            //effect.Play();
        }
    }


}
