using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public static DeadMenu instance;
    public GameObject pauseMenu;
    public Status pl;
    public bool isPaused
    {
        get;
        private set;
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.hp <= 0)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("DaniScene");
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Debug.Log("Loading");
    }
    public void Menu()
    {
        SceneManager.LoadScene("NereaScene");
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Debug.Log("Loading");
    }
}
