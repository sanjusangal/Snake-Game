using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    public Text score;
    public Text highScore;

    void Start ()
    {
		Score();
	}   

    public void Score()
    {
        int num = PlayerPrefs.GetInt("score");
        
        score.text = num.ToString();
        
        
    }

    public void RePlay()
    {        
        SceneManager.LoadScene("MainMenu");
    }
    public void Update()
    {
        if (int.Parse(score.text) > int.Parse(highScore.text))
        {
            highScore.text = score.text;
            PlayerPrefs.SetInt("int.Parse(highScore.text)",int.Parse(score.text));
            highScore.text= (PlayerPrefs.GetInt("int.Parse(highScore.text)")).ToString();
        }
    }
}
