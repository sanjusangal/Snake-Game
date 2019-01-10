using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFood : MonoBehaviour
{	
    public GameObject foodPrefab;
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start ()
    {
		InvokeRepeating("Spawn", 3, 4);
	}

    public void Spawn()
    {
        int y = (int) Random.Range(borderTop.position.y, borderBottom.position.y);
        int x =(int)Random.Range(borderLeft.position.x, borderRight.position.x);
        Instantiate(foodPrefab,new Vector2(x,y),Quaternion.identity);
    }
}
