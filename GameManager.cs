using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Test testScript;
    public static Movement movementScript;
    void Start()
    {
        testScript = GetComponent<Test>();
        movementScript = GetComponent<Movement>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            testScript.testActive = true;
            print("Running a test");
        }
    }
}
