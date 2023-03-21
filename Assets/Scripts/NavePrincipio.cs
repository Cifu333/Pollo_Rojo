using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavePrincipio : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed,-speed) * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, 200) * Time.deltaTime;
        if (transform.localScale.x > 0)
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
    }
}
