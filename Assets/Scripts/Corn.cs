using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Corn : MonoBehaviour
{
    public GameObject SoundCorn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 50) * Time.deltaTime;
        if (transform.position.x < -18)
            Destroy(gameObject);
        transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Chicken")
        {
            if (gameObject.tag == "Corn")
                collision.gameObject.GetComponent<Status>().corn++;

            if (gameObject.tag == "Cob")
                collision.gameObject.GetComponent<Status>().corn += 10;

            Instantiate(SoundCorn);
            Destroy(gameObject);
        }
    }
}
