namespace PhoneticSearcher.Core.Graph
{
    public enum Direction { Directed, Undirected };

    public class Edge<T>
    {
        // ***********************Constructors***********************

        public Edge(GraphNode<T> from, GraphNode<T> to, int cost, Direction direction)
        {
            Add(from, to, cost, direction);
        }

        public Edge(T from, T to, int cost, Direction direction)
        {
            Add(new GraphNode<T>(from), new GraphNode<T>(to), cost, direction);
        }

        protected Edge()
        {
        }

        // ***********************Properties***********************

        public int Cost { get; set; }

        public GraphNode<T> From { get; set; }

        public GraphNode<T> To { get; set; }

        // ***********************Functions***********************

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as Edge<T>;

            if (other == null)
            {
                return false;
            }

            if (From.Equals(other.From)
             && To.Equals(other.To))
            {
                return true;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() + To.GetHashCode();
        }

        public override string ToString()
        {
            return (From != null ? From.ToString() : "") + " -> " + (To != null ? To.ToString() : "");
        }

        protected void Add(GraphNode<T> from, GraphNode<T> to, int cost, Direction direction)
        {
            From = from;
            To = to;
            Cost = cost;

            if (!From.Neighbors.Contains(to))
            {
                From.Neighbors.Add(to);
                From.Costs.Add(cost);
            }

            if (direction == Direction.Undirected)
            {
                if (!To.Neighbors.Contains(from))
                {
                    To.Neighbors.Add(from);
                    To.Costs.Add(cost);
                }
            }
        }
    }
}
