using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int corn;
    public int hp;
    public List<GameObject> particlesDead;
    // Start is called before the first frame update
    void Start()
    {
        corn = 0;
        hp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            for (int i = 0; i < particlesDead.Count; i++)
                Instantiate(particlesDead[i], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
