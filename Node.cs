using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node /*: IHeapItem<Node> */
{
    int gValue;
    int hValue;

    public int Gvalue { get => gValue; set => gValue = (int)value; }
    public int HValue { get => hValue; set => hValue = (int)value; }
    public int FValue { get => gValue + hValue; }
    public Node ParentCell { get; set; }
    //int heapIndex;

    public Vector2 Position { get; set; }
    public int CellCost { get; set; }
    public int Affinity { get; set; }
    public bool Traversable { get; set; }
    
    public int GetDistanceMH(Vector2 pointA, Vector2 pointB)
    {
        int x = (int)Math.Abs(pointA.x - pointB.x);
        int y = (int)Math.Abs(pointA.y - pointB.y);
        int z = 10 * (x + y);
        return z;
    }

    //public int HeapIndex
    //{
    //    get
    //    {
    //        return HeapIndex;
    //    }
    //    set
    //    {
    //        HeapIndex = value;
    //    }
    //}

    //public int CompareTo(Node cellToCompare)
    //{
    //    int compare = FValue.CompareTo(cellToCompare.FValue);
    //    if (compare == 0)
    //    {
    //        compare = hValue.CompareTo(cellToCompare.hValue);
    //    }
    //    return -compare;
    //}
}
