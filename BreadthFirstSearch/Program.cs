using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjListBFS
{
    class Program
    {
        public class Adjacency                                                  // class of Adjacency with instance variables 
        {
            public int EndVertex { get; set; }                                  // such as neighbor(EndVertex) and weight(cost) of outgoing edge
            public int Weight { get; set; }

            public Adjacency(int e, int w)
            {
                EndVertex = e;
                Weight = w;
            }
            public Adjacency(int s, int e, int w)
            {
                EndVertex = e;
                Weight = w;
            }
        }

        class BasicGraph
        {
            //const int INFINITY = 9999;
            Dictionary<int, List<Adjacency>> myGraph;
            List<int> visited;

            public override string ToString()
            {
                return $"{myGraph}";
            }

            public BasicGraph()
            {
                myGraph = new Dictionary<int, List<Adjacency>>(); // key int value of the Dictionary is the node and values are list of neighbors and outgoing edges
                Console.WriteLine("Visited List Init...");
                visited = new List<int>();

            }


            void AddEdge(int startVertex, Adjacency adj)
            {
                if (myGraph.ContainsKey(startVertex))                            // Key (source vertex) already contained in the dictionary so we keep adding neighbors and weights in its Adjacency list
                {
                    List<Adjacency> adjList = myGraph[startVertex];
                    if (adjList.Contains(adj) == false)
                    {
                        adjList.Add(adj);
                    }
                }
                else                                                            // Adding a new starting vertex (key) and and a list of adjacencies-weights to the Dictionary
                {
                    List<Adjacency> adjList = new List<Adjacency>();
                    adjList.Add(adj);
                    myGraph.Add(startVertex, adjList);
                }
            }

            void Display()
            {
                foreach (var contents in myGraph.Keys)
                {
                    Console.Write("{{Vertex}}\n (" + contents + ") ");
                    foreach (var adjList in myGraph[contents])
                    {
                        Console.Write("[With Neighbor Vertex (" + adjList.EndVertex + ")]");
                    }
                    Console.WriteLine("\n");

                }
            }

            public void initvisited()                               //Initializing the Visited List
            {
                Console.WriteLine("Visited Array Init...");
                Console.Write("  ");
                for (int i = 0; i < myGraph.Count; ++i)
                {
                    visited.Add(0);
                    Console.Write(visited[i] + " ");
                }
                Console.WriteLine();
            }



            public void BFS(int startVert, int endVert)
            {
                int i = startVert;
                Queue<int> q = new Queue<int>();
                Console.WriteLine("---{{BFS}}---");
                Console.Write(i + " -> ");
                visited[i] = 1;
                q.Enqueue(i);
                while (q.Count != 0)
                {
                    i = q.Dequeue();
                    foreach (var j in myGraph[i])
                    {
                        if (j.Weight == 1 && visited[j.EndVertex] == 0)
                        {

                            Console.Write(j.EndVertex + " - > ");
                            visited[j.EndVertex] = 1;
                            if (j.EndVertex == endVert)
                            {
                                Console.WriteLine("Target Node " + endVert + " FOUND");
                                return;
                            }
                            q.Enqueue(j.EndVertex);
                        }
                    }


                }
                Console.WriteLine("Target Node " + endVert + " NOT FOUND");
                return;

            }
            static void Main(string[] args)
            {
                BasicGraph g = new BasicGraph();

                g.AddEdge(0, new Adjacency(1, 1));
                g.AddEdge(0, new Adjacency(2, 1));
                g.AddEdge(0, new Adjacency(3, 1));
                g.AddEdge(1, new Adjacency(4, 1));
                g.AddEdge(2, new Adjacency(4, 1));
                g.AddEdge(2, new Adjacency(1, 1));
                g.AddEdge(2, new Adjacency(5, 1));
                g.AddEdge(3, new Adjacency(5, 1));
                g.AddEdge(3, new Adjacency(6, 1));
                g.AddEdge(3, new Adjacency(2, 1));
                g.AddEdge(4, new Adjacency(5, 1));
                g.AddEdge(4, new Adjacency(7, 1));
                g.AddEdge(5, new Adjacency(7, 1));
                g.AddEdge(5, new Adjacency(6, 1));
                g.AddEdge(6, new Adjacency(7, 1));
                g.AddEdge(7, new Adjacency(1, 0)); /// we also need to create an instance of a node in the graph, even if it has no outgoing edges
                g.Display();
                g.initvisited();
                g.BFS(0, 10); // searching for node 10 -> "NOT FOUND"
                Console.ReadKey();
            }
        }
    }
}