using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace AlgSearchTransitiveClosure
{
    class Shiolah
    {
        List<int> parents;

        public Shiolah(int n)
        {
            parents = new List<int>(new int[n]);
            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
            }
        }

        public int[] searchComponentsWithoutParallel(List<List<int>> graph)
        {
            bool flag = true;
            //нахожение в звезде это parents[i] == parents[parents[i]] то есть отец и дед одинаковые ((
            while (flag)
            {
                //мой вариант

                for (int k = 0; k < graph.Count; k++)
                {
                    int i = graph[k][0], j = graph[k][1];
                    if (parents[parents[i]] == parents[i] && parents[i] > parents[j])
                    {
                        parents[parents[i]] = parents[j];
                    }
                    else if (parents[parents[j]] == parents[j] && parents[j] > parents[i])
                    {
                        parents[parents[j]] = parents[i];
                    }
                }

                //это не работает

                //for (int k = 0; k < graph.Count; k++)
                //{
                //    int i = graph[k][0], j = graph[k][1];

                //    //здесь происходит "стягивание" к наименьшей по порядку вершине
                //    if (parents[i] == parents[parents[i]] && parents[j] < parents[i])
                //    {
                //        parents[parents[i]] = parents[j];
                //    }
                //}

                //for (int k = 0; k < graph.Count; k++)
                //{
                //    int i = graph[k][0], j = graph[k][1];

                //    //если есть ребро, а родители разные, стягиваем 
                //    if (parents[i] == parents[parents[i]] && parents[j] != parents[i])
                //    {
                //        parents[parents[i]] = parents[j];
                //    }

                //}

                flag = false;
                for (int i = 0; i < parents.Count; i++)
                {
                    if (parents[parents[i]] != parents[i])
                    {
                        flag = true;
                        break;
                    }
                }

                //укорачивание
                for (int i = 0; i < parents.Count; i++)
                {
                    parents[i] = parents[parents[i]];
                }
            }

            return parents.ToArray();
        }

        
        public int[] searchComponentsWithParallel(List<List<int>> graph)
        {
            bool flag = true;
            while (flag)
            {
                Parallel.For(0, 8, new ParallelOptions { MaxDegreeOfParallelism = 8 }, p =>
                {
                    for (int k = p; k < graph.Count; k += 8)
                    {
                        int i = graph[k][0], j = graph[k][1];
                        if (parents[parents[i]] == parents[i] && parents[i] > parents[j])
                        {
                            parents[parents[i]] = parents[j];
                        }
                        else if (parents[parents[j]] == parents[j] && parents[j] > parents[i])
                        {
                            parents[parents[j]] = parents[i];
                        }
                    }
                });

                //Parallel.For(0, 8, new ParallelOptions { MaxDegreeOfParallelism = 8 }, p =>
                //{
                //    for (int k = p; k < graph.Count; k += 8)
                //    {
                //        int i = graph[k][0], j = graph[k][1];

                //        //если есть ребро, а родители разные, стягиваем 
                //        if (parents[i] == parents[parents[i]] && parents[j] != parents[i])
                //        {
                //            parents[parents[i]] = parents[j];
                //        }
                //    }
                //});

                flag = false;
                for (int i = 0; i < parents.Count; i++)
                {
                    if (parents[parents[i]] != parents[i])
                    {
                        flag = true;
                        break;
                    }
                }

                //укорачивание
                for (int i = 0; i < parents.Count; i++)
                {
                    parents[i] = parents[parents[i]];
                }
            }

            return parents.ToArray();
        }

    }
}
