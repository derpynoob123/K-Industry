using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathFinder
{
    private List<NodeRecord> openNodes = new List<NodeRecord>();
    private List<NodeRecord> closedNodes = new List<NodeRecord>();
    private List<Node> pathList = new List<Node>();

    private NodeRecord currentNode;

    public List<Node> FindPath(Node startNode, Node goalNode)
    {
        openNodes = new List<NodeRecord>();
        closedNodes = new List<NodeRecord>();

        List<Node> path = new List<Node>();
        currentNode = new NodeRecord();
        NodeRecord startRecord = new NodeRecord();
        startRecord.Node = startNode;
        startRecord.EstimatedTotalCost = Vector3.Distance(startRecord.Node.Position, goalNode.Position);
        openNodes.Add(startRecord);
        while (openNodes.Count > 0)
        {
            currentNode = FindNodeWithLowestEstimatedCost();

            if (currentNode.Node == goalNode)
            {
                break;
            }

            for (int nodeIndex = 0; nodeIndex < neighbourNodes.Count; nodeIndex++)
            {
                Node node = neighbourNodes[nodeIndex];
                NodeRecord endRecord;
                if (graph.IsNodeAWall(node))
                {
                    continue;
                }
                if (IsClosed(node))
                {
                    continue;
                }
                else if (IsOpen(node))
                {
                    endRecord = FindOpenNode(node);
                }
                else
                {
                    endRecord = new NodeRecord();
                    endRecord.Node = node;
                }

                float costSoFar = Vector3.Distance(node.Position, currentNode.Node.Position) + currentNode.CostSoFar;
                endRecord.CostSoFar = costSoFar;
                float heuristic = Vector3.Distance(node.Position, goalNode.Position);
                endRecord.Heuristic = heuristic;
                endRecord.EstimatedTotalCost = costSoFar + heuristic;
                endRecord.FromNode = currentNode;

                if (!openNodes.Contains(endRecord))
                {
                    openNodes.Add(endRecord);
                }
            }

            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);

        }
        if (currentNode.Node != goalNode)
        {
            return new List<Node>();
        }
        else
        {
            while (currentNode.Node != startNode)
            {
                path.Add(currentNode.Node);
                currentNode = currentNode.FromNode;
            }
            return path;
        }
    }

    private NodeRecord FindNodeWithLowestEstimatedCost()
    {
        float lowestEstimatedTotalCost = Mathf.Infinity;
        NodeRecord lowestEstimatedCostNode = new NodeRecord();
        for (int nodeIndex = 0; nodeIndex < openNodes.Count; nodeIndex++)
        {
            NodeRecord node = openNodes[nodeIndex];
            if (node.EstimatedTotalCost < lowestEstimatedTotalCost)
            {
                lowestEstimatedTotalCost = node.EstimatedTotalCost;
                lowestEstimatedCostNode = node;
            }
        }
        return lowestEstimatedCostNode;
    }

    private NodeRecord FindOpenNode(Node node)
    {
        for (int nodeIndex = 0; nodeIndex < openNodes.Count; nodeIndex++)
        {
            if (openNodes[nodeIndex].Node == node)
            {
                return openNodes[nodeIndex];
            }
        }
        return openNodes[0];
    }

    private NodeRecord FindClosedNode(Node node)
    {
        for (int nodeIndex = 0; nodeIndex < closedNodes.Count; nodeIndex++)
        {
            if (closedNodes[nodeIndex].Node == node)
            {
                return closedNodes[nodeIndex];
            }
        }
        return closedNodes[0];
    }

    private bool IsOpen(Node node)
    {
        for (int nodeIndex = 0; nodeIndex < openNodes.Count; nodeIndex++)
        {
            if (openNodes[nodeIndex].Node == node)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsClosed(Node node)
    {
        for (int nodeIndex = 0; nodeIndex < closedNodes.Count; nodeIndex++)
        {
            if (closedNodes[nodeIndex].Node == node)
            {
                return true;
            }
        }
        return false;
    }
}
