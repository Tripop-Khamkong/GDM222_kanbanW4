using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Console.Write(" Input (0<=i<n) or a negative integer to stop a progarm ");
        Console.Write("Input the number of nodes in the graph (n): ");
        int n = int.Parse(Console.ReadLine());

        Dictionary<int, List<int>> connections = new Dictionary<int, List<int>>();
        HashSet<int> symbolIndices = new HashSet<int>();
        for (int i = 0; i < n; i++) {
            connections[i] = new List<int>();
        }
        
        while (true) {
            Console.Write("Input the order of the source node : ");
            int i = int.Parse(Console.ReadLine());
            if (i < 0 || i >= n) {
                break;
            }

            Console.Write("Input the order of the destination node : ");
            int j = int.Parse(Console.ReadLine());
            if (j < 0 || j >= n || j == i) {
                break;
            }

            connections[i].Add(j);
            connections[j].Add(i);
        }

        char[] symbols = new char[n];
        int symbolCount = 0;
        for (int i = 0; i < n; i++) {
            int symbolIndex = 0;
            while (true) {
                char symbol = (char)('A' + symbolIndex);
                bool symbolTaken = false;

                foreach (int connectedNode in connections[i]) {
                    if (symbols[connectedNode] == symbol) {
                        symbolTaken = true;

                        break;
                    }
                }
                if (!symbolTaken) {
                    symbols[i] = symbol;
                    break;
                }
                
                if (symbolTaken) {
                    symbolCount++;
                    break;
                }
                symbolIndex++;
            }
        }
    
        Console.Write("Number of Symbols assigned :");
        Console.WriteLine(symbolCount);
    }
}
