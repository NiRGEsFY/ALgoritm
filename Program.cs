﻿namespace ALgoritm
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
                    Console.WriteLine("\n");
                    machineTuring machine = new machineTuring("L110101", ['1', '0', 'L'], rule);
                    machine.setStart(3);
                    machine.Start();
                    Console.WriteLine("\n");
                    machineTuring machine2 = new machineTuring("L110L01L101", ['1', '0', 'L'], rule2);
                    machine2.setStart(5);
                    machine2.Start();
                    Console.WriteLine("\n");
                    machineTuring machine3 = new machineTuring("cabdabda", ['a', 'b', 'c', 'd'], rule3);
                    machine3.setStart(7);
                    machine3.Start();
                    Console.WriteLine("\n");
                    string[][] rule4 = new string[][] {
                        new string[] {"Q0'1R",},
                        new string[] {"Q0'/R",},
                        new string[] {"."    ,}
                    };
                    machineTuring machine4 = new machineTuring("111111/1111=", ['1', '/', '='], rule4);
                    machine4.StartMath();

                    Console.WriteLine("\n\nФакториал f(x) = x!\n" +
                                      "Факториал является классическим примером примитивно-рекурсивной функции.\n" +
                                      "Базовый случай: \'f(0) = 1\'\n" +
                                      "Рекурсивный случай: \'f(x+1) = (x + 1) * f(x)\'\n");
                    Console.WriteLine("Функция квадратного корня не является примитивно-рекурсивой, так как ее\n" +
                                      "нельзя выразить через базовые примитивные функции и операции.");
                    Console.WriteLine("Функция f(x,y) = (x+y)-y - примитивная рекурсия.\n" +
                                      "f(x,y) = x + y ");
                    Console.WriteLine("Примитивная рекурсия доказана для функций \" f(x)=x!;f(x,y)=(x + y)-y \" " +
                                      "\n f=x^1/2 не является примитивно-рекурсивной функцией.");

                    static string ApplyMarkovRules(string input)
                    {
                        for (char a = '0'; a <= '5'; a++)
                        {
                            if (input.StartsWith(a.ToString()))
                            {
                                input = input.Substring(1) + a;
                                break;
                            }
                        }

                        for (char b = '0'; b <= '5'; b++)
                        {
                            if (input.EndsWith(b.ToString()))
                            {
                                input = b + "#" + input.Substring(0, input.Length - 1);
                                break;
                            }
                        }
                        input = input.Replace("#", "");

                        return input;
                    }

                    string input = "012345";
                    string output = ApplyMarkovRules(input);
                    Console.WriteLine(output);

                    static string ApplyMarkovRules2(string input)
                    {
                        string temp = input;
                        input = "#" + input + "@";

                        while (input.Contains("a") || input.Contains("b"))
                        {
                            if (input.StartsWith("#"))
                            {
                                input = input.Substring(1).Replace("a", "").Replace("b", "") + "#";
                            }
                            else if (input.EndsWith("@"))
                            {
                                input = "@" + input.Substring(0, input.Length - 1).Replace("a", "").Replace("b", "");
                            }
                        }

                        input = input.Replace("#a@", "#").Replace("#b@", "#");

                        return temp.Remove((int)(temp.Length / 2),1);
                    }

                    Console.WriteLine("\n\nРеализация алгоритма Маркова для \n" +
                                      "удаления среднего символа из слова\n" +
                                      "нечётной длины в алфавите {a, b}:");

                    string text = "abababababa";
                    string textAfter = ApplyMarkovRules2(text);
                    Console.WriteLine(textAfter);


                    static int ComputeFunction(int x)
                    {
                        if (x % 3 == 0)
                        {
                            return x / 3;
                        }
                        else
                        {
                            return x;
                        }
                    }
                    Console.WriteLine("\n\nЭмулятор машины с неограниченными регистрами.");
                    Console.Write("Введите x: ");
                    int x = int.Parse(Console.ReadLine());
                    int y = ComputeFunction(x);
                    Console.WriteLine($"Результат y(x): {y}");

                    break;
                case 2:
                    
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
