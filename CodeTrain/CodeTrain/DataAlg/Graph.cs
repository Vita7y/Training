using System.Collections.ObjectModel;
using System.Linq;

namespace CodeTrain.DataAlg
{
    public class Graph<T>
    {
        public Graph()
        {
            Nodes = new NodeList<T>();
        }

        public Node<T> AddNode(T value)
        {
            var node = new Node<T>(value);
            Nodes.Add(node);
            return node;
        }

        public void AddDirectedEdge(Node<T> from, Node<T> to)
        {
            from.Neighbors.Add(to);
            to.BackNeighbors.Add(from);
        }

        public bool Contains(T value)
        {
            return Nodes.FindByValue(value) != null;
        }

        public Node<T> GetNodeByValue(T value)
        {
            return Nodes.FindByValue(value);
        }

        public NodeList<T> Nodes { get; }

        public int Count => Nodes.Count;
    }

    public class Node<T>
    {
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            Value = data;
            Neighbors = neighbors ?? new NodeList<T>();
            BackNeighbors = BackNeighbors ?? new NodeList<T>();
        }

        public T Value { get; set; }

        public NodeList<T> Neighbors { get; }

        public NodeList<T> BackNeighbors { get; }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public Node<T> FindByValue(T value)
        {
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
}