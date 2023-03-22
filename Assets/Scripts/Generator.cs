using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject enemy;
    public float limity = 4f;
    public int maxEnemys = 8;
    private int enemys;
    public int enemyCount;
    public GameObject player;
    private Status corn;
    private int dificulty;

    public int asteroides_actuales = 0;
    // Start is called before the first frame update
    void Start()
    {
        dificulty = 0;
        corn = player.GetComponent<Status>();
        enemys = 1;
        enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while(enemyCount < enemys)
        {
            Vector3 pos = new Vector3(11.25f, Random.Range(-4.3f, 4.3f));
            GameObject temp = Instantiate(enemy, pos, Quaternion.identity);
            temp.gameObject.transform.parent = gameObject.transform;
            enemyCount++;
        }
        if ((int)(corn.corn / 60) > dificulty)
        {
            dificulty++;
            if (enemys < maxEnemys)
                enemys++;
        }

    }
}
