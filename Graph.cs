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

        ConsoleColor[] consoleColor = new ConsoleColor[]
            {
                ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Cyan,
                ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Magenta,
                ConsoleColor.DarkGray, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow
            };

        public Graph(int V)
        {
            this.V = V;
            adj = new List<int>[V];
            for (int i = 0; i < V; ++i)
                adj[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            adj[v-1].Add(w-1);
            adj[w-1].Add(v-1); 
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
            

            if (KColorableUtil(k, color, 0))
            {
                Console.WriteLine($"Граф может быть покрашен в {k} цветов:");
                for (int i = 0; i < V; i++)
                {
                    Console.ForegroundColor = consoleColor[color[i]-1];
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

        public void DisplayGraph()
        {
            for (int v = 0; v < V; ++v)
            {
                Console.Write("\nСписок смежности вершин " + (v+1));
                foreach (var x in adj[v])
                {
                    Console.Write(" -> " + (x+1));
                }
                Console.WriteLine();
            }
        }

        public void GreedyColoring()
        {
            int[] result = new int[V];
            for (int u = 0; u < V; u++)
                result[u] = -1;

            result[0] = 0;

            bool[] available = new bool[V];
            for (int cr = 0; cr < V; cr++)
                available[cr] = false;

            for (int u = 1; u < V; u++)
            {
                foreach (int i in adj[u])
                    if (result[i] != -1)
                        available[result[i]] = true;

                int cr;
                for (cr = 0; cr < V; cr++)
                    if (available[cr] == false)
                        break;

                result[u] = cr;

                foreach (int i in adj[u])
                    if (result[i] != -1)
                        available[result[i]] = false;
            }

            for (int u = 0; u < V; u++)
            {
                Console.ForegroundColor = consoleColor[result[u]];
                Console.WriteLine("Вершина " + (u+1) + " --->  Цвет " + (result[u]+1));
            }
            Console.ForegroundColor= ConsoleColor.White;
        }

        public bool HasHamiltonianCycle()
        {
            bool[] visited = new bool[V];
            List<int> path = new List<int>();
            path.Add(0);
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
