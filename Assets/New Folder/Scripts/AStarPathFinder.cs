using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStarPathFinder
{
    private Dictionary<Node, NodeRecord> openNodes = new();
    private Dictionary<Node, NodeRecord> closedNodes = new();
    private List<Connection> path = new();

    private NodeRecord currentNode;

    public List<Connection> FindPath(Node startNode, Node goalNode)
    {
        openNodes = new();
        closedNodes = new();

        path = new();
        currentNode = new();
        NodeRecord startRecord = new()
        {
            Node = startNode
        };
        startRecord.EstimatedTotalCost = Vector3.Distance(startRecord.Node.Position, goalNode.Position);
        openNodes.Add(startNode, startRecord);
        while (openNodes.Count > 0)
        {
            currentNode = FindNodeWithLowestEstimatedCost();

            if (currentNode.Node == goalNode)
            {
                break;
            }

            List<Connection> connections = currentNode.Node.Connections;
            for (int connectionIndex = 0; connectionIndex < connections.Count; connectionIndex++)
            {
                Connection connection = connections[connectionIndex];
                if (connection.EndNode == currentNode.Node)
                {
                    continue;
                }

                Node node = connection.EndNode;
                NodeRecord endRecord;
                float costSoFar = currentNode.CostSoFar + connection.Cost;
                if (closedNodes.ContainsKey(node))
                {
                    endRecord = closedNodes[node];
                    if (costSoFar >= endRecord.CostSoFar)
                    {
                        continue;
                    }

                    closedNodes.Remove(node);
                }
                else if (openNodes.ContainsKey(node))
                {
                    endRecord = openNodes[node];
                    if (costSoFar >= endRecord.CostSoFar)
                    {
                        continue;
                    }
                }
                else
                {
                    endRecord = new()
                    {
                        Node = node
                    };
                }
                endRecord.CostSoFar = costSoFar;
                float heuristic = Vector3.Distance(node.Position, goalNode.Position);
                endRecord.Heuristic = heuristic;
                endRecord.EstimatedTotalCost = costSoFar + heuristic;
                endRecord.Connection = connection;

                if (!openNodes.ContainsValue(endRecord))
                {
                    openNodes.Add(endRecord.Node ,endRecord);
                }
            }

            openNodes.Remove(currentNode.Node);
            closedNodes.Add(currentNode.Node, currentNode);

        }
        if (currentNode.Node != goalNode)
        {
            return new();
        }
        while (currentNode.Node != startNode)
        {
            path.Add(currentNode.Connection);
            currentNode = closedNodes[currentNode.Connection.StartNode];
        }
        path.Reverse();
        return path; ;
    }

    private NodeRecord FindNodeWithLowestEstimatedCost()
    {
        float lowestEstimatedTotalCost = Mathf.Infinity;
        NodeRecord lowestEstimatedCostNode = new();
        NodeRecord[] records = openNodes.Values.ToArray();
        for (int recordIndex = 0; recordIndex < records.Length; recordIndex++)
        {
            NodeRecord record = records[recordIndex];
            if (record.EstimatedTotalCost < lowestEstimatedTotalCost)
            {
                lowestEstimatedTotalCost = record.EstimatedTotalCost;
                lowestEstimatedCostNode = record;
            }
        }
        return lowestEstimatedCostNode;
    }
}
