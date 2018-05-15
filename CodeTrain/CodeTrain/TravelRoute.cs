using System;
using System.Collections.Generic;
using System.Linq;
using CodeTrain.DataAlg;

namespace CodeTrain
{
    public class TravelRoute
    {
        private readonly Graph<string> _routes;

        public TravelRoute()
        {
            _routes = new Graph<string>();
        }

        /// <summary>
        /// complexity O(n^2)
        /// </summary>
        public void LoadRoutes(IList<(string from, string to)> routes)
        {
            if(routes == null)
                throw new ArgumentNullException(nameof(routes));
            if (routes.Count == 0)
                throw new ArgumentNullException(nameof(routes));

            foreach (var route in routes)
                AddRoute(route);
        }

        /// <summary>
        /// complexity O(n)
        /// </summary>
        public void AddRoute((string from, string to) route)
        {
            // complexity O(1)
            if (string.IsNullOrWhiteSpace(route.from))
                throw new ArgumentNullException(nameof(route.from));
            if (string.IsNullOrWhiteSpace(route.to))
                throw new ArgumentNullException(nameof(route.to));

            // complexity O(n)
            var nodeFrom = _routes.GetNodeByValue(route.from)?? _routes.AddNode(route.from);

            // complexity O(n)
            var nodeTo = _routes.GetNodeByValue(route.to)?? _routes.AddNode(route.to);

            // complexity O(1)
            _routes.AddDirectedEdge(nodeFrom, nodeTo);
        }

        /// <summary>
        /// complexity  O(n)
        /// <remarks>Despite the fact that complexity of Traverse function is O(2^n) 
        /// in the condition of the task we have simple graph without divide tree, 
        /// and by fact it`s jast cycle with complexity O(n)</remarks>
        /// </summary>
        public IList<(string from, string to)> FindRoute(string from, string to)
        {
            var nodeFrom = _routes.GetNodeByValue(from);
            var route = new List<(string from, string to)>();
            Traverse(nodeFrom, to, route);
            route.Reverse();
            return route;
        }


        /// <summary>
        /// complexity of tree traverse O(2^n)
        /// </summary>
        private static bool Traverse(Node<string> nodeTo, string to,  ICollection<(string from, string to)> routes)
        {
            if (nodeTo.Value.Equals(to))
                return true;

            foreach (var node in nodeTo.Neighbors)
            {
                if (!Traverse(node, to, routes))
                    continue;
                routes.Add((nodeTo.Value, node.Value));
                return true;
            }

            return false;
        }

        /// <summary>
        /// complexity of tree traverse O(2^n)
        /// </summary>
        private static bool Traverse(Node<string> nodeTo, ICollection<(string from, string to)> routes)
        {
            if (nodeTo == null)
                return false;
            if (!nodeTo.Neighbors.Any())
                return true;

            foreach (var node in nodeTo.Neighbors)
            {
                if (!Traverse(node, routes))
                    continue;
                routes.Add((nodeTo.Value, node.Value));
                return true;
            }

            return false;
        }

        /// <summary>
        /// complexity O(n) in the same reason then in FindRoute
        /// </summary>
        public IList<(string from, string to)> GetRoute()
        {
            var route = new List<(string from, string to)>();
            Traverse(FindRoot(_routes), route);
            if (route.Count < _routes.Count-1)
                return null;
            route.Reverse();
            return route;
        }

        /// <summary>
        /// complexity O(n)
        /// </summary>
        private static Node<string> FindRoot(Graph<string> routes)
        {
            foreach (var node in routes.Nodes)
            {
                if (!node.BackNeighbors.Any())
                    return node;
            }

            return null;
        }
    }
}
