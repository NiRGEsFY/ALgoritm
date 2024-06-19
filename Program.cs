namespace ALgoritm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания:");
            int switcher = 0;
            int.TryParse(Console.ReadLine(), out switcher);
            switch(switcher){
                case 1:
                    /*
                    Graph graph = new Graph(8);
                    graph.AddEdge(1, 0);
                    graph.AddEdge(1, 2);
                    graph.AddEdge(1, 3);
                    graph.AddEdge(2, 4);
                    graph.AddEdge(4, 5);
                    graph.AddEdge(6, 7);
                    graph.AddEdge(7, 1);
                    graph.AddEdge(8, 4);
                    graph.AddEdge(5, 4);
                    graph.AddEdge(5, 2);
                    graph.AddEdge(5, 8);

                    graph.IsKColorable(3);

                    Graph graph2 = new Graph(4);
                    graph2.AddEdge(0, 1);
                    graph2.AddEdge(1, 2);
                    graph2.AddEdge(2, 3);
                    graph2.AddEdge(3, 0);

                    List<Tuple<int, int>> cubicSubgraph = graph2.FindCubicSubgraph();

                    if (cubicSubgraph != null)
                    {
                        Console.WriteLine("Подмножество существует:");
                        foreach (var edge in cubicSubgraph)
                        {
                            Console.WriteLine($"{edge.Item1} - {edge.Item2}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Подмножество не существует.");
                    }


                    Graph graph3 = new Graph(5);

                    graph3.AddEdge(0, 1);
                    graph3.AddEdge(1, 2);
                    graph3.AddEdge(2, 3);
                    graph3.AddEdge(3, 4);
                    graph3.AddEdge(4, 0);

                    if (graph3.HasHamiltonianCycle())
                    {
                        Console.WriteLine("Граф имеет гамильтонов цикл");
                    }
                    else
                    {
                        Console.WriteLine("Граф не имеет гамильтонов цикл");
                    }
                    */
                    string[][] rule = new string[][] { 
                        new string[] {"Q0'0R"},
                        new string[] {"Q0'1R"},
                        new string[] {"'1."}
                    };
                    string[][] rule2 = new string[][] {
                        new string[] {"Q0'LR","Q2'1R","Q3'LR","Q31L"},
                        new string[] {"Q0'1R","Q2'0R","Q3'1R","Q0'0L"},
                        new string[] {"Q1'LR","Q2'LR","Q3'LR","'L."}
                    };
                    string[][] rule3 = new string[][] {
                        new string[] {"Q0'dL","Q1'dL","Q2'cL"},
                        new string[] {"Q1'aL","Q2'aL",""},
                        new string[] {"."    ,"."    ,"Q0'a."},
                        new string[] {"Q0'bL","Q1'bL",""}
                    };
                    machineTuring machine = new machineTuring("L110101", ['1', '0', 'L'], rule);
                    machine.setStart(3);
                    machine.Start();
                    machineTuring machine2 = new machineTuring("L110L01L101", ['1', '0', 'L'], rule2);
                    machine2.setStart(5);
                    machine2.Start(); 
                    machineTuring machine3 = new machineTuring("cabdabda", ['a', 'b', 'c', 'd'], rule3);
                    machine3.setStart(7);
                    machine3.Start();
                    break;
                case 2:
                    string[][] rule4 = new string[][] {
                        new string[] {"Q0'1R",},
                        new string[] {"Q0'/R",},
                        new string[] {"."    ,}
                    };
                    machineTuring machine4 = new machineTuring("111111/1111=", ['1','/','='], rule4);
                    machine4.StartMath();
                    break;
                case 3:
                    
                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:
                    break;
            }
        }
    }
}
