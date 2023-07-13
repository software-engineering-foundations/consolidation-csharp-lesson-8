namespace consolidation_csharp_lesson_8;

public class Graph<T>
{
    public List<Vertex<T>>? Vertices { get; set; }

    public Dictionary<Vertex<T>, int> DijkstraShortestPath(Vertex<T> source)
    {
        throw new NotImplementedException();
    }
}

public class Edge
{
    public int Length { get; set; }
}

public class Vertex<T>
{
    public T? Value { get; set; }

    // every edge consists of distance and a vertex
    public Dictionary<Edge, Vertex<T>> Edges { get; set; } = new Dictionary<Edge, Vertex<T>>();
}