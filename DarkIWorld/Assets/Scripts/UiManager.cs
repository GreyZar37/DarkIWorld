using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject playerUI;

    public AudioSource SfxSource;
    public AudioClip onHover;
    public AudioClip clicked;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pauseUI.activeSelf)
            {

                resumeGame();
            }
            else
            {

                pauseGame();
            }
        }
    }

    public void quit()
    {
        SfxSource.PlayOneShot(clicked);
        Application.Quit();
    }

    public void resumeGame()
    {
        SfxSource.PlayOneShot(clicked);
        pauseUI.SetActive(false);
        playerUI.SetActive(true);
        Cursor.visible = false;



        Time.timeScale = 1;
        GameManager.currentGameState = gameState.playing;

    }
    public void pauseGame()
    {
        Cursor.visible = true;
        pauseUI.SetActive(true);
        playerUI.SetActive(false);


        Time.timeScale = 0;
        GameManager.currentGameState = gameState.paused;
    }
    public void startGame()
    {
        SfxSource.PlayOneShot(clicked);
        Cursor.visible = false;
        SceneManager.LoadScene("Game Scene");
    }

    public void onHover_()
    {
        SfxSource.PlayOneShot(onHover);
    }
    public void clicked_()
    {
        SfxSource.PlayOneShot(clicked);
    }
    public void returnToMainMenu()
    {
        SfxSource.PlayOneShot(clicked);
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
