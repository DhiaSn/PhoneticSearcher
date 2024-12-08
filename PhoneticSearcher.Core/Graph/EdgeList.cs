using System.Collections.ObjectModel;

namespace PhoneticSearcher.Core.Graph
{
    public class EdgeList<T> : Collection<Edge<T>>
    {
        // ***********************Constructors***********************

        public EdgeList()
            : base()
        {
        }

        public EdgeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
            {
                Items.Add(default);
            }
        }

        // ***********************Functions***********************

        public EdgeList<T> Clone()
        {
            var newList = new EdgeList<T>();
            foreach (var edge in Items)
            {
                newList.Add(edge);
            }

            return newList;
        }
    }
}
