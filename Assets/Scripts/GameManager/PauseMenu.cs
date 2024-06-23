using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseScreen;

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseScreen.activeInHierarchy)
                PauseMenuFunc(false);
            else
                PauseMenuFunc(true);
        }
    }*/

    private void PauseMenuFunc(bool status)
    {
        PauseScreen.SetActive(status);

        /*if(status)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;*/
    }

    public void PauseClick()
    {
        PauseScreen.SetActive(true);
        //Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        //Time.timeScale = 1;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
