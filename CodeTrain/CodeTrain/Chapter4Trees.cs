using System.Collections.Generic;
using System.Linq;
using CodeTrain.DataAlg;

namespace CodeTrain
{
    public class Chapter4Trees
    {
        public class Graph<T>
        {
            public class Node<T>
            {
                public Node(T value) : this()
                {
                    Value = value;
                }
                public Node()
                {
                    Nodes = new List<Node<T>>();
                }

                public T Value { get; set; }

                public List<Node<T>> Nodes { get; set; }
            }

            public Graph()
            {
                Points = new List<Node<T>>();
            }

            public List<Node<T>> Points { get; set; }

            public void Add(T from, T to)
            {
                var nFrom = Points.FirstOrDefault(am => am.Value.Equals(from));
                if (nFrom == null)
                {
                    nFrom = new Node<T>(from);
                    Points.Add(nFrom);
                }

                var nTo = Points.FirstOrDefault(am => am.Value.Equals(to));
                if (nTo == null)
                {
                    nTo = new Node<T>(to);
                    Points.Add(nTo);
                }

                nFrom.Nodes.Add(nTo);
            }

            public List<(T from, T to)> FindRoute(T from, T to)
            {
                var nFrom = Points.FirstOrDefault(am => am.Value.Equals(from));
                var nTo = Points.FirstOrDefault(am => am.Value.Equals(to));
                if (nFrom == null || nTo == null)
                    return null;
                return Traverse(nFrom, nTo);

            }

            private List<(T from, T to)> Traverse(Node<T> from, Node<T> to)
            {
                foreach (var node in from.Nodes)
                {
                    if(node.Value.Equals(to.Value))
                        return new List<(T from, T to)>{(from.Value, node.Value)};
                    var res = Traverse(node, to);
                    if (res == null) continue;
                    res.Add((from.Value, node.Value));
                    return res;
                }
                return null;
            }
        }

        ///4.1. Для заданного направленного графа разработайте алгоритм, проверяющий существование маршрута между двумя узлами.
        public static List<(string from, string to)> FindRouteBetweenTwoPoints(List<(string p1, string p2)> pointsList, string from, string to)
        {
            var graph = new Graph<string>();
            foreach (var vector in pointsList)
            {
                graph.Add(vector.p1, vector.p2);
            }

            return graph.FindRoute(from, to);
        }
    }
}