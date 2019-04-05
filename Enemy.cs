using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Enemy : MonoBehaviour
{
    private List<Vector2> targets = new List<Vector2>();
    private bool pathFound;
    private AStar astar;
    private NodeHolder nodeHolder;
    public float speed = .05f;
    void Awake()
    {
        astar = GetComponent<AStar>();
        nodeHolder = GetComponent<NodeHolder>();
        nodeHolder.Size = 20;
        nodeHolder.CreateNodeHolder(nodeHolder);
        pathFound = false;
    }
    private void Update()
    {
        if (targets == null || targets.Count < 1)
        {
            targets.Add(astar.SeekTarget(nodeHolder));
        }
        else
        {
            while (pathFound == false)
            {
                pathFound = astar.SeekPath(nodeHolder, targets[0], transform.position);
            }
            return;
        }        
    }    

    private void FixedUpdate()
    {
        if (pathFound == true)
        {
            if (nodeHolder.Path.Count > 0)
            {
                GameManager.movementScript.CardinalMovement(transform, nodeHolder, speed);
            }
            else
            {
                targets.Remove(targets[0]);
                pathFound = false;
            }
        }
    }
}

