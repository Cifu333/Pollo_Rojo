using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationGenerator : MonoBehaviour
{
    public GameObject star;
    public GameObject planet;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 1f)
        {
            if (Random.Range(1, 100) <= 1)
                Instantiate(planet, new Vector3(transform.position.x, Random.Range(-3.35f, 3.35f)), Quaternion.identity);
            else
                Instantiate(star, new Vector3(transform.position.x, Random.Range(-4.35f,4.35f)), Quaternion.identity);
            time = 0;
            if (Random.Range(1, 50) <= 3)
                time++;
        }

    }
}
