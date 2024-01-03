using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    public Node StartNode { get; }
    public Node EndNode { get; }

    public Connection(Node start, Node end)
    {
        StartNode = start;
        EndNode = end;
    }
}
