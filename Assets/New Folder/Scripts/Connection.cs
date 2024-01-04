using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    public Node StartNode { get; }
    public Node EndNode { get; }
    public float Cost { get; }

    public Connection(Node start, Node end, float cost)
    {
        StartNode = start;
        EndNode = end;
        Cost = cost;
    }
}
