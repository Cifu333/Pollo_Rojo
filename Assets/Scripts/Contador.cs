using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public GameObject player;
    public int corn;
    public float time = 0;
    private Status playerC;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        playerC = player.GetComponent<Status>();
        corn = playerC.corn;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.corn > corn)
        {
            
            if (playerC.corn - corn > 100)
                time += 1000 * Time.deltaTime;

            else if (playerC.corn - corn > 10)
                time += 100 * Time.deltaTime;

            else
                time += 10 * Time.deltaTime;


            if (time >= 1)
            {
                corn++;
                time = 0;
            }
        }
        else if (playerC.corn < corn)
        {

            if (corn - playerC.corn > 100)
                time += 1000 * Time.deltaTime;

            else if (corn - playerC.corn > 10)
                time += 100 * Time.deltaTime;

            else
                time += 10 * Time.deltaTime;

            if (time >= 1)
            {
                corn--;
                time = 0;
            }
        }
        text.text = corn.ToString("0");

    }
}
