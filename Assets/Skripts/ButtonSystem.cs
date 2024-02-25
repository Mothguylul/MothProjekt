using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonSystem : MonoBehaviour
{
    public void MainMenü()
    {
        SceneManager.LoadScene("Main Menü");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
    public void Level2()
    {      
        SceneManager.sceneLoaded += ActivatePlayerAndResumeGame;
        SceneManager.LoadScene("Level2");
    }
    public void ActivatePlayerAndResumeGame(Scene Arg0,LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= ActivatePlayerAndResumeGame;
        Game.Player.transform.position = GameObject.Find("Startpos").transform.position;
        Game.Player.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void Shop()
    {
        SceneManager.sceneLoaded += DeactivatePlayer;
        SceneManager.LoadScene("Garage");
    }
    public void DeactivatePlayer(Scene Arg2, LoadSceneMode arg3)
    {
        SceneManager.sceneLoaded -= DeactivatePlayer;
        Game.Player.gameObject.SetActive(false);
    }
}
