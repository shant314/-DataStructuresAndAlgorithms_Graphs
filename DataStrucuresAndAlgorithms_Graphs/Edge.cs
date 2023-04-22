
namespace DataStrucuresAndAlgorithms_Graphs
{
    public class Edge<T>
    {
        public Node<T> NodeFrom { get; set; } = new Node<T>();
        public Node<T> NodeTo { get; set; } = new Node<T>();
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Edge: {NodeFrom.Data} -> {NodeTo.Data}, Weight: {Weight}";
        }
    }
}
