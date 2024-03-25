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

        //мне кажется что это плохая реалтзация потоков, потому что каждую итерацию я создаю новый поток,
        //а по факту метод find не такой уж и затратный, тк мы идем по дереву и очень быстро находим родителя
        public int[] searchComponentsWithParallel1()
        {
            int[] graphPa = new int[parents.Count];
            //new ParallelOptions { MaxDegreeOfParallelism = 8 },
            Parallel.For(0, parents.Count, i =>
            {
                graphPa[i] = find(i);
            });

            return graphPa;
        }



        //этот метод немного другой, он быстрее чем версия 1 потому что я не для каждого find вызываю Task
        //то есть я не трачу время на то, чтобы создать Task и запустить его.
        //я это могу не делать, потому что find очень быстро рекурсивно ищет родителя
        public int[] searchComponentsWithParallel2()
        {
            int[] graphPa = new int[parents.Count];

            Parallel.For(0, 8, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i =>
            {
                for (int j = i; j < parents.Count; j += 8)
                {
                    graphPa[j] = find(j);
                }
            });

            //List<Task> tasks = new List<Task>();
            //for (int i = 0; i < 6; i++)
            //{
            //    int currentI = i;
            //    tasks.Add(Task.Run(() =>
            //    {
            //        for (int j = currentI; j < parents.Count; j += 6) graphPa[i] = find(j);
            //    }));
            //}
            //Task.WaitAll(tasks.ToArray());

            return graphPa;
        }
    }
}
