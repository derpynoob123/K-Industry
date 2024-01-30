public class Connection
{
    public Node StartNode { get; }
    public Node EndNode { get; }
    public float Cost { get; }

    public Connection(Node start, Node end, float cost)
    {
        StartNode = start;
        EndNode = end;

        if (cost < 0)
        {
            Cost = 0;
        }
        else
        {
            Cost = cost;
        }
    }
}
