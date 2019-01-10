using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Sprite play;
    public Sprite pause;
    public Button btn;
    bool flag = true;

    
    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ToggleMusic() 
    {
        AudioSource music = GetComponent<AudioSource>();
        
        
        if (flag==true)
        {
            flag = false;
           
            music.Pause();
            btn.GetComponent<Image>().sprite = pause;

        }
        else
        {
            flag = true;
            music.Play();
            btn.GetComponent<Image>().sprite = play;
           
           
        }
        

    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }	
}
