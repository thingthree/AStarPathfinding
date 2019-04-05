using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool testActive = false;
    public GameObject enemy;
    void Update()
    {
        if (testActive == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                print("Testing Astar");
                GameObject instantiateEnemy = Instantiate(enemy, new Vector3(2, 2, 0f), Quaternion.identity);                
                testActive = false;
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log(UnityEngine.Random.Range(5, 15));
                Debug.Log(UnityEngine.Random.Range(5, 15));
            }
        }
    }   
}
