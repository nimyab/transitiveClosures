using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSearchTransitiveClosure
{
    class DSU
    {
        List<int> parents;
        List<int> rank;

        public List<int> getParent() { return parents; }
        public DSU(int n)
        {
            parents = new List<int>(new int[n]);
            rank = new List<int>(new int[n]);
            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
                rank[i] = 0;
            }
        }

        private int find(int V)
        {
            if (V == parents[V]) return V;
            return parents[V] = find(parents[V]);
        }

        public bool union(int a, int b)
        {
            a = find(a);
            b = find(b);
            if (a == b) return false;//не будет слияния

            if (rank[a] > rank[b]) (a, b) = (b, a);
            parents[b] = a;
            if (rank[a] == rank[b]) rank[a]++;

            return true;
        }

        public int[] searchComponentsWithoutParallel()
        {
            int[] graphPa = new int[parents.Count];

            for (int i = 0; i < parents.Count; i++)
            {
                graphPa[i] = find(i);
            }

            return graphPa;
        }
    }
}
