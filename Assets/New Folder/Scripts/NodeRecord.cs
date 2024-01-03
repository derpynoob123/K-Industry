public class NodeRecord
{
    public Node Node { get; set; }
    public float CostSoFar { get; set; }
    public float Heuristic { get; set; }
    public float EstimatedTotalCost { get; set; }
    public Connection Connection { get; set; }
}
