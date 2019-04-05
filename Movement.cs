using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void CardinalMovement(Transform inputTransform, NodeHolder nodeHolder, float speed)
    {
        float distance = Vector2.Distance((Vector2)inputTransform.position, nodeHolder.Path[0]);
        if (distance > .025)
        {            
            inputTransform.position = Vector3.MoveTowards(inputTransform.position, nodeHolder.Path[0], Time.deltaTime * speed);
        }
        else
        {
            inputTransform.position = nodeHolder.Path[0];
            nodeHolder.Path.Remove(nodeHolder.Path[0]);
        }        
    }
}

