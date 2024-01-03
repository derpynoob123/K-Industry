using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{ 
    public List<Connection> Connections { get; set; }
    public Vector3 Position { get; }
    public GameObject ID { get; }

    public Node(GameObject gameObject)
    {
        Position = gameObject.transform.position;
        ID = gameObject;
    }
}
