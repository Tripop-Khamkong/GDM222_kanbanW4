using System;
using System.Collections.Generic;

namespace DirectedGraph
{
    class Program
    {
        static bool isReachable(int s, int d, List<int>[] adj, bool[] visited)
        {
            if (s == d)
                return true;

            visited[s] = true;

            foreach (int i in adj[s])
            {
                if (!visited[i] && isReachable(i, d, adj, visited))
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.Write("Input the number of nodes in the graph: ");
            int n = int.Parse(Console.ReadLine());

            List<int>[] adj = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
            }

            Console.WriteLine("Enter edges (i j):");
            while (true)
            {
            
                int i = int.Parse(Console.ReadLine());
                if (i < 0 || i > n)
                    break;
                    
                int j = int.Parse(Console.ReadLine());

                adj[i].Add(j);
            }

            Console.Write("Input the order of the source node : ");
            int s = int.Parse(Console.ReadLine());

            Console.Write("Input the order of the destination node : ");
            int d = int.Parse(Console.ReadLine());
            
            bool[] visited = new bool[n];
            if (isReachable(s, d, adj, visited))
                Console.WriteLine("Reachable");
            else
                Console.WriteLine("Unreachable");
        }
    }
}