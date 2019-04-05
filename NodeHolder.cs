using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeHolder: MonoBehaviour
{
    public List<Vector2> Path { get; set; }
    public Node[,]  Holder { get; set; }
    public int Size { get; set; }

    public void CreateNodeHolder(NodeHolder grid)
    {
        grid.Holder = new Node[grid.Size, grid.Size];

        for (int a = 0; a < grid.Size; a++)
        {
            for (int b = 0; b < grid.Size; b++)
            {                
                grid.Holder[a, b] = new Node()
                {                   
                    Position = new Vector2(a, b),
                    Traversable = true,             
                    CellCost = 10,                  
                    Affinity = 10                   
                };
            }
        }
    }
}