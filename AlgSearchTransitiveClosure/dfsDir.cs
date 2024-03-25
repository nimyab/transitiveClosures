using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSearchTransitiveClosure
{
    class bfsDir
    {
        private int countV;
        private List<int>[] adj;

        public bfsDir(int countV)
        {
            this.countV = countV;
            adj = new List<int>[countV];
            for (int i = 0; i < countV; i++) adj[i] = new List<int>();
        }
        public void AddEdge(int v, int w) { adj[v].Add(w); }

        public List<int> bfs(int start)
        {
            bool[] visited = new bool[countV];
            List<int> vertices = new List<int>() { start };

            Queue<int> queue = new Queue<int>();
            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                start = queue.Dequeue();

                foreach (int v in adj[start])
                {
                    if (!visited[v])
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                        vertices.Add(v);
                    }
                }
            }
            return vertices;
        }

        public List<List<int>> searchTransitiveClosure()
        {
            List<List<int>> paths = new List<List<int>>();
            //
            Parallel.For(0, countV, new ParallelOptions { MaxDegreeOfParallelism = 8 }, (i) =>
            {
                paths.Add(bfs(i));
            });
            return paths;
        }
        public List<List<int>> searchTransitiveClosureWithoutParallel()
        {
            List<List<int>> paths = new List<List<int>>();

            for (int i = 0; i < countV; i++)
            {
                paths.Add(bfs(i));
            }
            return paths;
        }
    }
}
