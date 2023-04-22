
namespace DataStrucuresAndAlgorithms_Graphs
{
    public class Graph<T>
    {
        private bool _isDirected { get; set; } = false;
        private bool _isWeighted { get; set; } = false;

        public List<Node<T>> Nodes { get; set; }

        public Graph(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }


        public Edge<T> this[int from, int to]
        {
            get
            {
                Node<T> nodeFrom = Nodes[from];// the index i reliable, based on the order you insert items.
                Node<T> nodeTo = Nodes[to];

                var nodeToIndex = nodeFrom.Neighbors.IndexOf(nodeTo);
                if (nodeToIndex >= 0)//returns negative if not found.
                {
                    return new Edge<T>
                    {
                        NodeFrom = nodeFrom,
                        NodeTo = nodeTo,
                        Weight = nodeToIndex < nodeFrom.Weights.Count
                        ? nodeFrom.Weights[nodeToIndex]
                        : 0
                        //Weight = nodeFrom.Weights[nodeToIndex],
                    };
                }
                return null;
            }
        }

        public Node<T> AddNode(T value)
        {
            Node<T> node = new Node<T>() { Data = value };
            Nodes.Add(node);
            UpdateIndices();
            return node;
        }
        public void RemoveNode(Node<T> nodeToRemove)
        {
            Nodes.Remove(nodeToRemove);
            UpdateIndices();
            // iterate through all nodes in the graph to remove all edges that are connected with the ndoe that has been remvoed.
            foreach (Node<T> node in Nodes)
            {
                RemoveEdge(node, nodeToRemove);
            }
        }

        private void UpdateIndices()
        {
            int i = 0;
            Nodes.ForEach(n=>n.Index = i++);
        }

        public void AddEdge(Node<T> nodeFrom, Node<T> nodeTo, int weight = 0)
        {
            nodeFrom.Neighbors.Add(nodeTo);
            if (_isWeighted)
                nodeFrom.Weights.Add(weight);
            if (_isDirected)
            {
                nodeTo.Neighbors.Add(nodeFrom);
                if (_isWeighted)
                    nodeTo.Weights.Add(weight);// why does this have to be same weight?
            }
        }

        public void RemoveEdge(Node<T> nodeFrom, Node<T> nodeTo)
        {
            var index = nodeFrom.Neighbors.IndexOf(nodeTo);
            if (index >= 0)
            {
                nodeFrom.Neighbors.RemoveAt(index);
                if (_isWeighted)
                    nodeFrom.Weights.RemoveAt(index);
            }
        }

        public List<Edge<T>> GetEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();

            foreach (Node<T> node in Nodes)
            {
                for (int i = 0; i < node.Neighbors.Count; i++)
                {
                    Edge<T> edge = new Edge<T>
                    {
                        NodeFrom = node,
                        NodeTo = node.Neighbors[i],
                        Weight = i < node.Weights.Count
                          ? node.Weights[i]
                          : 0
                    };
                    edges.Add(edge);
                }
            }
            return edges;
        }
    }
}
