using System.Collections.Generic;
using UnityEngine;

public class Node
{ 
    public List<Connection> Connections { get; set; }
    public Vector3 Position { get; }

    public Node(Vector3 position)
    {
        Connections = new();
        Position = position;
    }
}
