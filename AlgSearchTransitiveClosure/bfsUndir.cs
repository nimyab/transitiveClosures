using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgSearchTransitiveClosure
{
    class BFSUndir
    {
        private int countV;
        private List<int>[] adj;

        public BFSUndir(int countV)
        {
            this.countV = countV;
            adj = new List<int>[countV];
            for (int i = 0; i < countV; i++) adj[i] = new List<int>(countV);
        }
        public void AddEdge(int v, int w) { adj[v].Add(w); adj[w].Add(v); }

        public List<int> bfs(int start, ref bool[] visited)
        {
            List<int> component = new List<int>();
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);
            component.Add(start);

            while (queue.Count > 0)
            {
                start = queue.Dequeue();

                foreach (int v in adj[start])
                {
                    if (!visited[v])
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                        component.Add(v);
                    }
                }

            }

            return component;
        }

        public List<List<int>> findComponents()
        {
            List<List<int>> components = new List<List<int>>();
            bool[] visited = new bool[countV];

            for (int i = 0; i < countV; i++)
            {
                if (!visited[i]) components.Add(bfs(i, ref visited));
            }
            return components;
        }

    }
}
