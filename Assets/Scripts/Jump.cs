using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    private bool jetPack;
    public float jetForce = 2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            jetPack = true;
            rb.AddForce(rb.transform.up * jetForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            //effect.Play();
        }
    }


}
