namespace PhoneticSearcher.Core.Graph
{
    /// <summary>
    /// The Node&lt;T&gt; class represents the base concept of a Node for a tree or graph.  It contains
    /// a data item of type T, and a list of neighbors.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the Node.</typeparam>
    /// <remarks>None of the classes in the SkmDataStructures2 namespace use the Node class directly;
    /// they all derive from this class, adding necessary functionality specific to each data structure.</remarks>
    public class Node<T>
    {
        // ***********************Fields***********************

        private List<int> costs;
        private T data;
        private NodeList<T> neighbors = null;

        // ***********************Constructors***********************

        public Node()
        {
        }

        public Node(T value)
            : this(value, null)
        {
        }

        public Node(T value, NodeList<T> neighbors)
        {
            data = value;
            this.neighbors = neighbors;
        }

        // ***********************Properties***********************

        /// <summary>
        /// Returns the set of costs for the edges eminating from this graph node.
        /// The k<sup>th</sup> cost (Cost[k]) represents the cost from the graph node to the node
        /// represented by its k<sup>th</sup> neighbor (Neighbors[k]).
        /// </summary>
        /// <value></value>
        public List<int> Costs
        {
            get
            {
                if (costs == null)
                {
                    costs = new List<int>();
                }

                return costs;
            }
        }

        public bool HasNeighbors
        {
            get
            {
                if (Neighbors == null)
                {
                    return false;
                }

                if (Neighbors.Count == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public NodeList<T> Neighbors
        {
            get
            {
                if (neighbors == null)
                {
                    neighbors = new NodeList<T>();
                }

                return neighbors;
            }

            set
            {
                neighbors = value;
            }
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        // ***********************Functions***********************

        public int CostToNeighbor(GraphNode<T> node)
        {
            int index = Neighbors.IndexOf(node);

            if (index >= 0)
            {
                return Costs[index];
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as Node<T>;

            if (other == null)
            {
                return false;
            }

            if (Value.Equals(other.Value))
            {
                return true;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool IsNeighbor(Node<T> node)
        {
            if (Neighbors.IndexOf(node) == -1)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            if (Value == null)
            {
                return string.Empty;
            }

            return Value.ToString();
        }
    }
}
