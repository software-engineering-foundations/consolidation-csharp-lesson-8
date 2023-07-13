using System.Collections;
using consolidation_csharp_lesson_8;
using NUnit.Framework;

namespace consolidation_csharp_lesson_7;

public class TestChallenges
{
    private static void SetUpEdgeBetweenVertices<T>(Vertex<T> a, Vertex<T> b, Edge e)
    {
        a.Edges[e] = b;
        b.Edges[e] = a;
    }


    public static IEnumerable GetDijkstraTestCases
    {
        get
        {
            var vertexA = new Vertex<object>();
            var vertexB = new Vertex<object>();
            var vertexC = new Vertex<object>();
            var vertexD = new Vertex<object>();
            var vertexE = new Vertex<object>();
            var vertexF = new Vertex<object>();

            var edge1 = new Edge() {Length = 14};
            var edge2 = new Edge() {Length = 7};
            var edge3 = new Edge() {Length = 9};
            var edge4 = new Edge() {Length = 10};
            var edge5 = new Edge() {Length = 15};
            var edge6 = new Edge() {Length = 11};
            var edge7 = new Edge() {Length = 2};
            var edge8 = new Edge() {Length = 9};
            var edge9 = new Edge() {Length = 6};

            SetUpEdgeBetweenVertices(vertexA, vertexB, edge2);
            SetUpEdgeBetweenVertices(vertexA, vertexC, edge1);
            SetUpEdgeBetweenVertices(vertexA, vertexD, edge3);
            SetUpEdgeBetweenVertices(vertexD, vertexB, edge4);
            SetUpEdgeBetweenVertices(vertexE, vertexB, edge5);
            SetUpEdgeBetweenVertices(vertexC, vertexD, edge7);
            SetUpEdgeBetweenVertices(vertexC, vertexF, edge8);
            SetUpEdgeBetweenVertices(vertexD, vertexE, edge6);
            SetUpEdgeBetweenVertices(vertexF, vertexE, edge9);

            var graph = new Graph<object>() {
                Vertices = new List<Vertex<object>>() {vertexA, vertexB, vertexC, vertexD, vertexE, vertexF}
            };

            yield return new TestCaseData(
                graph,
                vertexA,
                vertexA,
                0
            );

            yield return new TestCaseData(
                graph,
                vertexA,
                vertexB,
                7
            );
            
            yield return new TestCaseData(
                graph,
                vertexA,
                vertexC,
                11
            );

            yield return new TestCaseData(
                graph,
                vertexA,
                vertexF,
                20
            );  

            yield return new TestCaseData(
                graph,
                vertexF,
                vertexE,
                6
            );                   
        }
    }

    [TestCaseSource(nameof(GetDijkstraTestCases))]
    public void TestDijkstra(Graph<object> graph, Vertex<object> start, Vertex<object> end, int expectedDistance)
    {
        var shortestPathDictionary = graph.DijkstraShortestPath(start);
        var result = shortestPathDictionary[end];
        Assert.That(result, Is.EqualTo(expectedDistance));
    }
}