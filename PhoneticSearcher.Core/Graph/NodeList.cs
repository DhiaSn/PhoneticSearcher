using System.Collections.ObjectModel;


namespace PhoneticSearcher.Core.Graph
{
    public class NodeList<T> : Collection<Node<T>>
    {
        // ***********************Constructors***********************

        public NodeList()
            : base()
        {
        }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
            {
                Items.Add(default);
            }
        }

        // ***********************Functions***********************

        public void Add(GraphNode<T> item)
        {
            Items.Add(item);
        }

        public NodeList<T> Clone()
        {
            var newList = new NodeList<T>();
            foreach (var node in Items)
            {
                newList.Add((GraphNode<T>)node);
            }

            return newList;
        }

        /// <summary>
        /// Searches the NodeList for a Node containing a particular value.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The Node in the NodeList, if it exists; null otherwise.</returns>
        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (GraphNode<T> node in Items)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
}
