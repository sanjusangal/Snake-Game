using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    Vector2 dir = Vector2.zero;
    List<Transform> tail = new List<Transform>();
    public AudioSource foodGulf;
    public AudioSource gameOver;
    private bool ate = false;
    private int score = 0;
    public GameObject tailPrefab;
	
    void Start()
    {
        int level = PlayerPrefs.GetInt("btn");
        if (level == 1)
        {
            InvokeRepeating("Move", 0.3f, 0.09f);
        }
        else if (level == 2)
        {
            InvokeRepeating("Move", 0.3f, 0.06f);
        }
        else if (level == 3)
        {
            InvokeRepeating("Move", 0.3f, 0.03f);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("food"))
        {
            Debug.Log("hi");
            foodGulf.Play();
            // Get longer in next Move call
            ate = true;
            score ++;
            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else
        {
            gameOver.Play();
            PlayerPrefs.SetInt("score",score);
            SceneManager.LoadScene("Result");
            // ToDo 'You lose' screen
        }
    }

    public void LeftClick()
    {
        Debug.Log("hi");
        dir = -Vector2.right;  
    }

    public void RightClick()
    {
        dir = Vector2.right;
    }

    public void UpClick()
    {
        dir = Vector2.up;
    }

    public void DownClick()
    {
        dir = -Vector2.up;
    }  
       
    void Update ()
    {     
	    if (Input.GetKey(KeyCode.RightArrow))
	        dir = Vector2.right;
	    else if (Input.GetKey(KeyCode.DownArrow))
	        dir = -Vector2.up;    
	    else if (Input.GetKey(KeyCode.LeftArrow))
	        dir = -Vector2.right; 
	    else if (Input.GetKey(KeyCode.UpArrow))
	        dir = Vector2.up;
    }

   public void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        print(dir);
        if (ate)
        {
            GameObject g = (GameObject) Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0,g.transform);
            ate = false;
        }
        else if(tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0,tail.Last());
            tail.RemoveAt(tail.Count-1);
        }
    }
}
     