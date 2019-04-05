using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Diagnostics;
public class AStar : MonoBehaviour
{
    public bool SeekPath(NodeHolder nodeHolder, Vector2 target, Vector2 start)
    {
        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(nodeHolder.Holder[(int)start.x, (int)start.y]);

        while (openSet.Count > 0) 
        {
            Node current = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].FValue < current.FValue || openSet[i].FValue == current.FValue)
                {
                    if (openSet[i].HValue < current.HValue)
                        current = openSet[i];
                }
            }

            openSet.Remove(current);
            closedSet.Add(current);

            if (current == nodeHolder.Holder[(int)target.x, (int)target.y])
            {
                nodeHolder.Path = new List<Vector2>();

                while (current.Position != start)
                {
                    nodeHolder.Path.Add(current.Position);
                    current = current.ParentCell;
                }
                nodeHolder.Path.Reverse();
                return true;
            }

            Vector2[] adjacentCells = new Vector2[4]
            {
                current.Position + Vector2.up,
                current.Position + Vector2.down,
                current.Position + Vector2.left,
                current.Position + Vector2.right,
            };

            foreach (Vector2 adjacentCell in adjacentCells)
            {
                Node node = nodeHolder.Holder[(int)adjacentCell.x, (int)adjacentCell.y];

                if (node.Traversable == true && !closedSet.Contains(node))
                {
                    if (current.Gvalue + node.GetDistanceMH(current.Position, node.Position) < node.Gvalue || !openSet.Contains(node))
                    {
                        node.Gvalue = current.Gvalue + node.GetDistanceMH(current.Position, node.Position);
                        node.HValue = node.GetDistanceMH(target, node.Position);
                        node.ParentCell = current;

                        if (!openSet.Contains(node))
                        {
                            openSet.Add(node);
                        }
                    }
                }
            }
        };
        return false;
    }

    public Vector2 SeekTarget(NodeHolder grid)
    {
        return new Vector2(UnityEngine.Random.Range(1, grid.Size - 1), UnityEngine.Random.Range(1, grid.Size - 1));
    }

    public void CheckCellFitness(NodeHolder grid, Vector2 to, Vector2 target)
    {
        Node loopCell = grid.Holder[(int)to.x, (int)to.y];

        
    }

}
