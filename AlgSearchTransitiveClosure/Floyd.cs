using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSearchTransitiveClosure
{
    class Floyd
    {
        public static List<int>[] Alg(List<List<int>> edges, int size)
        {
            List<int>[] dist = new List<int>[size];
            //создаю матрицу
            for (int i = 0; i < size; i++)
            {
                dist[i] = new List<int>();
                for (int j = 0; j < size; j++)
                    dist[i].Add(1000);
            }
            //считываю ребра
            for (int i = 0; i < edges.Count; i++)
            {
                dist[edges[i][0]][edges[i][1]] = 1;
            }

            //сам алгоритм
            //Пробегаемся по всем вершинам и ищем более короткий путь
            //через вершину k
            for (int k = 0; k < size; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        //Новое значение ребра равно минимальному между старым
                        //и суммой ребер i <-> k + k <-> j (если через k пройти быстрее)
                        if (dist[i][j] > dist[i][k] + dist[k][j]) dist[i][j] = 1;
                    }
                }
            }
            //
            return dist;
        }
    }
}
