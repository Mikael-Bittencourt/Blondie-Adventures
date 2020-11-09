using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

      public void Level_1()
    {
       SceneManager.LoadScene("Level 1");
    }

     public void Level_2()
    {
       SceneManager.LoadScene("Level 2");
    }

     public void Level_3()
    {
       SceneManager.LoadScene("Level 3");
    }

    public void Level_4()
    {
       SceneManager.LoadScene("Level 4");
    }

    public void Level_5()
    {
       SceneManager.LoadScene("Level 5");
    }

     public void QuitGame()
    {
       Debug.Log("Quitting game...");
       Application.Quit();
    }

     public void LoadMenu()
    {
       SceneManager.LoadScene("Main_Menu");
    }

}
