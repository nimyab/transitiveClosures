using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AlgSearchTransitiveClosure
{
    class Utils
    {
        const short numberRuns = 3;

        public static List<List<int>> createRandomGraph(int size, int edgesCount)
        {
            var rand = new Random();
            List<List<int>> graph = new List<List<int>>(edgesCount);

            for (int i = 0; i < edgesCount;)
            {
                int x1 = rand.Next(0, size);
                int x2 = rand.Next(0, size);
                if (x1 == x2) continue;
                graph.Add(new List<int> { x1, x2 });
                i++;
            }

            return graph;
        }

        public static int[,] transitiveMatrixFromDSU(int[] parents, int ver)
        {
            int[,] matrix = new int[ver, ver];

            for (int i = 0; i < parents.Length; i++)
            {
                for (int j = 0; j < parents.Length; j++)
                {
                    if (parents[i] == parents[j]) matrix[i, j] = 1;
                }
            }

            return matrix;
        }
        public static int[,] transitiveMatrixFromBFSUndir(List<List<int>> components, int ver)
        {
            int[,] matrix = new int[ver, ver];
            for (int i = 0; i < components.Count; i++)
            {
                for (int j = 0; j < components[i].Count; j++)
                {
                    int currentVer = components[i][j];
                    for (int k = 0; k < components[i].Count; k++)
                    {
                        if (j != k) matrix[currentVer, components[i][k]] = 1;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = 1;
            }
            return matrix;
        }
        public static int[,] transitiveMatrixFromBFSDir(List<List<int>> paths, int ver)
        {
            int[,] matrix = new int[ver, ver];

            for (int i = 0; i < paths.Count; i++)
            {
                int start = paths[i][0];
                for (int j = 0; j < paths[i].Count; j++)
                {
                    if (start != paths[i][j]) matrix[start, paths[i][j]] = 1;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = 1;
            }

            return matrix;
        }
        public static int[,] transitiveMatrixFromFloyd(List<int>[] dists, int ver)
        {
            int[,] matrix = new int[ver, ver];

            for (int i = 0; i < dists.Length; i++)
            {
                for (int j = 0; j < dists[i].Count; j++)
                {
                    if (dists[i][j] == 1) matrix[i, j] = 1;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = 1;
            }

            return matrix;
        }

        public static void logHRToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine("--------------------------------------------------------");
            }
        }
        public static void logGraphToFile(string filename, List<List<int>> graph)
        {

            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine($"{graph.Count} edges");
                graph.ForEach((List<int> comp) =>
                {
                    sw.WriteLine($"{comp[0]} {comp[1]}");
                });
                sw.WriteLine();
            }
        }
        public static void printDataToFile(string filename, int[,] data)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        sw.Write($"{data[i, j]} ");
                    }
                    sw.WriteLine();
                }
                sw.WriteLine();
            }
        }

        public static int[] avaregeForDSU(List<List<int>> graph, int vertices, ref long avgTime)
        {
            Stopwatch sw = new Stopwatch();
            int[] parents = null;
            List<long> times = new List<long>(numberRuns);

            sw.Restart();
            DSU dsu = new DSU(vertices);
            for (int i = 0; i < graph.Count; i++)
            {
                dsu.union(graph[i][0], graph[i][1]);
            }
            long timeFormDSU = sw.ElapsedMilliseconds;

            for (short num = 0; num < numberRuns; num++)
            {
                sw.Restart();
                parents = dsu.searchComponentsWithoutParallel();
                times.Add(sw.ElapsedMilliseconds + timeFormDSU);
            }
            avgTime = times.Sum() / numberRuns;

            return parents;
        }
        public static List<List<int>> avaregeForBFSUndir(List<List<int>> graph, int vertices, ref long avgTime)
        {
            Stopwatch sw = new Stopwatch();
            List<long> times = new List<long>(numberRuns);
            List<List<int>> components = null;

            BFSUndir bfs = new BFSUndir(vertices);
            for (int i = 0; i < graph.Count; i++)
            {
                bfs.AddEdge(graph[i][0], graph[i][1]);
            }

            for (short num = 0; num < numberRuns; num++)
            {
                
                sw.Restart();
                components = bfs.findComponents();
                times.Add(sw.ElapsedMilliseconds);
            }

            avgTime = times.Sum() / numberRuns;
            return components;

        }
        public static int[] avaregeForShiolah(List<List<int>> graph, int vertices, ref long avgTime)
        {
            Stopwatch sw = new Stopwatch();
            int[] answerWithoutParallel = null;
            List<long> times = new List<long>(numberRuns);
            
            for (short num = 0; num < numberRuns; num++)
            {
                sw.Restart();
                Shiolach shiolah = new Shiolach(vertices);
                answerWithoutParallel = shiolah.searchComponentsWithoutParallel(graph);
                times.Add(sw.ElapsedMilliseconds);
            }

            avgTime = times.Sum() / numberRuns;
            return answerWithoutParallel;
        }
        public static int[] avaregeForShiolahParallel(List<List<int>> graph, int vertices, ref long avgTime)
        {
            Stopwatch sw = new Stopwatch();
            int[] answerWithParallel = null;
            List<long> times = new List<long>(numberRuns);

            for (short num = 0; num < numberRuns; num++)
            {
                sw.Restart();
                Shiolach shiolah = new Shiolach(vertices);
                answerWithParallel = shiolah.searchComponentsWithParallel(graph);
                times.Add(sw.ElapsedMilliseconds);
            }

            avgTime = times.Sum() / numberRuns;
            return answerWithParallel;
        }

        public static List<int>[] avaregeForFloyd(List<List<int>> graph, int vertices, ref long avgTime)
        {
            Stopwatch sw = new Stopwatch();
            List<int>[] answerFloyd = null;
            List<long> times = new List<long>(numberRuns);

            for (short num = 0; num < numberRuns; num++)
            {
                sw.Restart();
                answerFloyd = Floyd.Alg(graph, vertices);
                times.Add(sw.ElapsedMilliseconds);
            }

            avgTime = times.Sum() / numberRuns;
            return answerFloyd;
        }
        public static List<List<int>> avaregeForBFSDir(BFSDir bfs, ref long avgTime)
        {
            Stopwatch sw = new Stopwatch();
            List<List<int>> answerBfs = null;
            List<long> times = new List<long>(numberRuns);

            for (short num = 0; num < numberRuns; num++)
            {
                sw.Restart();
                answerBfs = bfs.searchTransitiveClosureWithoutParallel();
                times.Add(sw.ElapsedMilliseconds);
            }

            avgTime = times.Sum() / numberRuns;
            return answerBfs;
        }
        public static List<List<int>> avaregeForBFSDirParallel(BFSDir bfs, ref long avgTime)
        {
            Stopwatch sw = new Stopwatch();
            List<List<int>> answerBfs = null;
            List<long> times = new List<long>(numberRuns);

            for (short num = 0; num < numberRuns; num++)
            {
                sw.Restart();
                answerBfs = bfs.searchTransitiveClosure();
                times.Add(sw.ElapsedMilliseconds);
            }

            avgTime = times.Sum() / numberRuns;
            return answerBfs;
        }
    }
}
