using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {	

    public void LoadLevel()
    {
        //var button = EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log(button);
    }

    public void FirstButton()
    {
        PlayerPrefs.SetInt("btn" , 1);
        SceneManager.LoadScene("snakeGame");
    }
    public void SecondButton()
    {
        PlayerPrefs.SetInt("btn", 2);
        SceneManager.LoadScene("snakeGame");
    }
    public void ThirdButton()
    {
        PlayerPrefs.SetInt("btn", 3);
        SceneManager.LoadScene("snakeGame");
    }
    
}
