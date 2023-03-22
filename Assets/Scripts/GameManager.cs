using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HighScore;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (HighScore < GameObject.FindGameObjectWithTag("Chicken").GetComponent<Status>().corn)
        {
            HighScore = GameObject.FindGameObjectWithTag("Chicken").GetComponent<Status>().corn;
        }
        if (HighScore > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", HighScore);
    }
}
