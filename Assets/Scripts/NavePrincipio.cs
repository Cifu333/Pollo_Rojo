using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavePrincipio : MonoBehaviour
{
    public GameObject corn;
    public GameObject cob;
    public int multiply;
    public float speed;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        multiply = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,speed) * multiply * Time.deltaTime;
        if (transform.position.y >= 3.35f && speed > 0)
            speed = -speed;
        if (transform.position.y <= -3.36f && speed < 0)
            speed = -speed;
        transform.eulerAngles += new Vector3(0, 0, 200) * Time.deltaTime;
        if (transform.position.x < 9.15)
        {
            transform.position += new Vector3(speed * 6, 0) * Time.deltaTime;
        }
        time += Time.deltaTime;
        if (time > 2f)
        {
            if (transform.position.x < 9.15)
                if (Random.Range(1, 10) <= 3)
                    speed = -speed;

            if (Random.Range(1,100) <= 25)
                Instantiate(cob, transform.position, Quaternion.identity);
            else
                Instantiate(corn, transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
