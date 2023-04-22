
namespace DataStrucuresAndAlgorithms_Graphs
{
    public class Node<T>
    {
        public int Index { get; set; }
        public T? Data { get; set; }
        public List<Node<T>> Neighbors { get; set; } = new List<Node<T>>();
        public List<int> Weights { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"Node with index {Index}: {Data}, Neighbors: {Neighbors.Count}";
        }
    }
}
