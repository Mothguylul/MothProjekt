using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenü()
    {
        SceneManager.LoadScene("Main Menü");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
