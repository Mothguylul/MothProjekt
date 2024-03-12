using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSystem : MonoBehaviour
{
   // public GameObject levelOptions, playAndOptions;
    public Button SwingCave;
    public EndLogic endLogic {  get; private set; }

    private void Start()
    {
        SwingCave.interactable = false;
        endLogic = FindAnyObjectByType<EndLogic>();
        endLogic.HasEndedLevel1 += SetButtonsInteractabel;
    }
    public void MainMenü()
    {
        SceneManager.LoadScene("Main Menü");
        Game.Player.gameObject.SetActive(false);
    }

    public void Level2()
    {      
        SceneManager.sceneLoaded += ActivatePlayerAndResumeGame;
        SceneManager.LoadScene("Level2");
    }
    public void Level1()
    {
        SceneManager.sceneLoaded += ActivatePlayerAndResumeGame;
        SceneManager.LoadScene("Level1");
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

   /* public void Play()
    {
        levelOptions.SetActive(true);
        playAndOptions.SetActive(false);
    }*/
    public void SetButtonsInteractabel()
    {
        SwingCave.interactable = true;
        if (SwingCave.interactable)
            return;
    }
}
