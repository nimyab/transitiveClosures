using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace AlgSearchTransitiveClosure
{
    class Utils
    {
        public static List<List<int>> createRandomGraph(int size, int edgesCount)
        {
            var rand = new Random();
            List<List<int>> graph = new List<List<int>>(edgesCount);

            for (int i = 0; i < edgesCount;)
            {
                int x1 = rand.Next(0, size - 1);
                int x2 = rand.Next(0, size - 1);
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
                    if (i != j && parents[i] == parents[j]) matrix[i, j] = 1;
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

            return matrix;
        }

        public static int[,] transitiveMatrixFromFloyd(List<int>[] dists, int ver)
        {
            int[,] matrix = new int[ver, ver];

            for (int i = 0; i < dists.Length; i++)
            {
                for (int j = 0; j < dists[i].Count; j++)
                {
                    if (dists[i][j] == 1 && i != j) matrix[i, j] = 1;
                }
            }

            return matrix;
        }
    }
}
