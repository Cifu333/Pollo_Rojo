using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Chicken")
        {
            if (gameObject.tag == "Corn")
                collision.gameObject.GetComponent<Status>().corn++;

            if (gameObject.tag == "Cob")
                collision.gameObject.GetComponent<Status>().corn += 10;
            
            Destroy(gameObject);
        }
    }
}
