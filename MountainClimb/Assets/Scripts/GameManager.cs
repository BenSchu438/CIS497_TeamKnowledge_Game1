using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject endLevelMenu;
    public GameObject playerUI;
    public bool finishedLevel = false;

    public GameObject levelBlock;

    private void Start()
    {
        // make sure level starts at regular time scale
        Time.timeScale = 1f;
    }

    // Enable end of level menu
    public void EndLevel()
    {
        finishedLevel = true;
        playerUI.SetActive(false);
        endLevelMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    // Disable the object that was blocking the exit
    public void UnlockEnd()
    {
        levelBlock.SetActive(false);
    }

    public void Pause()
    {
        if(!finishedLevel)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            playerUI.SetActive(false);
        }
        
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        playerUI.SetActive(true);
    }

    // Restart current scene
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load input level
    public void LoadLevel(string n)
    {
        UnloadLevel();
        SceneManager.LoadScene(n);
    }

    // Unload level
    public void UnloadLevel()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        // Aslong as not on main menu screen, pause with 'p'
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (!(SceneManager.GetActiveScene().name.Equals("Menu")) && pauseMenu.activeInHierarchy)
                UnPause();
            else if (!(SceneManager.GetActiveScene().name.Equals("Menu")) && !pauseMenu.activeInHierarchy)
                Pause();
        }
    }
}
