using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxMin : MonoBehaviour
{
    private float time;
    public float position;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 1)
        {
            transform.localScale += new Vector3(1, 1) * Time.deltaTime;
            transform.position -= new Vector3(position, position) * Time.deltaTime;
            time += Time.deltaTime;
        }
        else
        {
            transform.localScale -= new Vector3(1, 1) * Time.deltaTime;
            transform.position += new Vector3(position, position) * Time.deltaTime;
            time += Time.deltaTime;
            if (time >= 2)
                time = 0;
        }
    }
}
