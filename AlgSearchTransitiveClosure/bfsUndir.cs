using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSearchTransitiveClosure
{
    class bfsUndir
    {
        private int countV;
        private List<int>[] adj;

        public bfsUndir(int countV)
        {
            this.countV = countV;
            adj = new List<int>[countV];
            for (int i = 0; i < countV; i++) adj[i] = new List<int>();
        }
        public void AddEdge(int v, int w) { adj[v].Add(w); adj[w].Add(v); }

        public List<List<int>> bfs(int start = 0)
        {
            bool[] visited = new bool[countV];
            List<List<int>> components = new List<List<int>>();
            components.Add(new List<int>());
            int index = 0;

            Queue<int> queue = new Queue<int>();
            visited[start] = true;
            queue.Enqueue(start);
            components[index].Add(start);

            while (true)
            {
                start = queue.Dequeue();

                foreach (int v in adj[start])
                {
                    if (!visited[v])
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                        components[index].Add(v);
                    }
                }
                if (queue.Count == 0)
                {
                    int notVisitedV = Array.IndexOf(visited, false);
                    if (notVisitedV != -1)
                    {
                        visited[notVisitedV] = true;
                        queue.Enqueue(notVisitedV);
                        components.Add(new List<int>());
                        components[++index].Add(notVisitedV);
                    }
                    else break;
                }

            }

            return components;
        }

    }
}
