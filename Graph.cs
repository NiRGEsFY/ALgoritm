using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALgoritm
{
    public class Graph
    {
        private int V;
        private List<int>[] adj;

        public Graph(int V)
        {
            this.V = V;
            adj = new List<int>[V];
            for (int i = 0; i < V; ++i)
                adj[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            if(v >= V)
                v = V-1;
            if (w >= V)
                w = V-1;
            adj[v].Add(w);
            adj[w].Add(v); 
        }

        private bool IsKColorable(int[] color, int v, int c)
        {
            for (int i = 0; i < adj[v].Count; i++)
                if (color[adj[v][i]] == c)
                    return false;
            return true;
        }

        private bool KColorableUtil(int k, int[] color, int v)
        {
            if (v == V)
                return true;

            for (int c = 1; c <= k; c++)
            {
                if (IsKColorable(color, v, c))
                {
                    color[v] = c;

                    if (KColorableUtil(k, color, v + 1))
                        return true;

                    color[v] = 0;
                }
            }

            return false;
        }

        public bool IsKColorable(int k)
        {
            int[] color = new int[V];
            for (int i = 0; i < V; i++)
                color[i] = 0;
            ConsoleColor[] consoleColor = new ConsoleColor[] 
            { 
                ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Cyan,
                ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Magenta,
                ConsoleColor.DarkGray, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow
            };

            if (KColorableUtil(k, color, 0))
            {
                Console.WriteLine($"Граф может быть покрашен в {k} цветов:");
                for (int i = 0; i < V; i++)
                {
                    Console.ForegroundColor = consoleColor[color[i]];
                    Console.WriteLine($"Вершина {i + 1} -> Цвет {color[i]}");
                }
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.WriteLine($"Граф не может быть покрашен в {k} цветов.");
                return false;
            }
        }

        public List<Tuple<int, int>> FindCubicSubgraph()
        {
            List<Tuple<int, int>> edgeSubset = new List<Tuple<int, int>>();
            int[] degree = new int[V];

            foreach (int v in Enumerable.Range(0, V))
            {
                foreach (int u in adj[v])
                {
                    if (degree[v] < 3 && degree[u] < 3)
                    {
                        edgeSubset.Add(Tuple.Create(v, u));
                        degree[v]++;
                        degree[u]++;
                    }
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (degree[i] != 3 && degree[i] != 0)
                {
                    return null;
                }
            }

            return edgeSubset;
        }

        public bool HasHamiltonianCycle()
        {
            bool[] visited = new bool[V];
            List<int> path = new List<int>();
            path.Add(0); // Start from vertex 0
            visited[0] = true;

            return HasHamiltonianCycleUtil(0, visited, path, V);
        }
        private bool HasHamiltonianCycleUtil(int v, bool[] visited, List<int> path, int V)
        {
            if (path.Count == V)
            {
                // Check if the last vertex connects to the first vertex
                return adj[v].Contains(path[0]);
            }

            foreach (int neighbor in adj[v])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    path.Add(neighbor);

                    if (HasHamiltonianCycleUtil(neighbor, visited, path, V))
                        return true;

                    visited[neighbor] = false;
                    path.RemoveAt(path.Count - 1);
                }
            }

            return false;
        }
    }
}
