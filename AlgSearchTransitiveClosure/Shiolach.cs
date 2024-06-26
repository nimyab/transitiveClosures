using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace AlgSearchTransitiveClosure
{
    class Shiolach
    {
        List<int> components;

        public Shiolach(int n)
        {
            components = new List<int>(new int[n]);
            for (int i = 0; i < n; i++)
            {
                components[i] = i;
            }
        }

        public int[] searchComponentsWithoutParallel(List<List<int>> graph)
        {
            bool flag = true;

            while (flag)
            {
                flag = false;

                // Первый этап: обновление меток
                for (int k = 0; k < graph.Count; k++)
                {
                    int u = graph[k][0], v = graph[k][1];

                    int compU = components[u];
                    int compV = components[v];

                    if (compU != compV)
                    {
                        if (compU < compV) components[compV] = compU;
                        else components[compU] = compV;
                        flag = true;
                    }
                }

                // Второй этап: обновление компонент
                for (int v = 0; v < components.Count; v++)
                {
                    while (components[v] != components[components[v]])
                    {
                        components[v] = components[components[v]];
                    }
                }       

            }

            return components.ToArray();
        }

        
        public int[] searchComponentsWithParallel(List<List<int>> graph)
        {
            bool flag = true;

            while (flag)
            {
                flag = false;

                // Первый этап: обновление меток
                Parallel.For(0, graph.Count, k =>
                {
                    int u = graph[k][0], v = graph[k][1];

                    int compU = components[u];
                    int compV = components[v];

                    if (compU != compV)
                    {
                        int higtComp = compU > compV ? compU : compV;
                        int lowComp = compU + (compV - higtComp);

                        if (higtComp == components[higtComp])
                        {
                            flag = true;
                            components[higtComp] = lowComp;
                        }
                    }
                });

                Parallel.For(0, components.Count, k =>
                {
                    while (components[k] != components[components[k]])
                    {
                        components[k] = components[components[k]];
                    }
                });
            }

            return components.ToArray();
        }

    }
}
