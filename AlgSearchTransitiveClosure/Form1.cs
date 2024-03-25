using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AlgSearchTransitiveClosure
{
    public partial class Form1 : Form
    {
        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void log(string msg = "")
        {
            logTextBox.AppendText(msg + "\r\n");
        }
        void logTransitiveMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    logTextBox.AppendText(matrix[i, j].ToString() + " ");
                }
                log();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";

            try
            {
                int count = int.Parse(countGraph.Text);
                int edges = int.Parse(countEdges.Text);
                int vertices = int.Parse(countVer.Text);
                log("start");

                for (int k = 0; k < count; k++)
                {
                    List<List<int>> graph = Utils.createRandomGraph(vertices, edges);
                    log("graph created");

                    //проверка скорости DSU вместе с формированием

                    sw.Restart();
                    DSU dsu = new DSU(vertices);
                    for (int i = 0; i < graph.Count; i++)
                    {
                        dsu.union(graph[i][0], graph[i][1]);
                    }
                    long timeFormDSU = sw.ElapsedMilliseconds;

                    sw.Restart();
                    int[] parents1 = dsu.searchComponentsWithoutParallel();
                    log("Dsu search Components Without Parallel\t" + ((sw.ElapsedMilliseconds + timeFormDSU)).ToString());

                    sw.Restart();
                    int[] parents2 = dsu.searchComponentsWithParallel1();
                    log("Dsu search Components With Parallel1\t" + ((sw.ElapsedMilliseconds + timeFormDSU)).ToString());

                    sw.Restart();
                    int[] parents3 = dsu.searchComponentsWithParallel2();
                    log("Dsu search Components With Parallel2\t" + ((sw.ElapsedMilliseconds + timeFormDSU)).ToString());

                    if (vertices <= 20) logTransitiveMatrix(Utils.transitiveMatrixFromDSU(parents1, vertices));

                    //проверка bfs

                    sw.Restart();
                    bfsUndir bfs = new bfsUndir(vertices);
                    for (int i = 0; i < graph.Count; i++)
                    {
                        bfs.AddEdge(graph[i][0], graph[i][1]);
                    }
                    List<List<int>> components = bfs.bfs();
                    log("bfs undirected search components\t" + ((sw.ElapsedMilliseconds)).ToString());
                    if (vertices <= 20) logTransitiveMatrix(Utils.transitiveMatrixFromBFSUndir(components, vertices));
                    
                    log();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";

            try
            {
                int count = int.Parse(countGraph.Text);
                int edges = int.Parse(countEdges.Text);
                int vertices = int.Parse(countVer.Text);
                log("start");

                for (int k = 0; k < count; k++)
                {
                    List<List<int>> graph = Utils.createRandomGraph(vertices, edges);
                    log("graph created");

                    //проверка скорости DSU вместе с формированием

                    sw.Restart();
                    List<int>[] dist = Floyd.Alg(graph, vertices);
                    log("Floyd search paths\t" + ((sw.ElapsedMilliseconds)).ToString());
                    if (vertices <= 20) logTransitiveMatrix(Utils.transitiveMatrixFromFloyd(dist, vertices));

                    //проверка bfs

                    sw.Restart();
                    bfsDir bfs = new bfsDir(vertices);
                    for (int i = 0; i < graph.Count; i++)
                    {
                        bfs.AddEdge(graph[i][0], graph[i][1]);
                    }
                    long timeFormBFS = sw.ElapsedMilliseconds;

                    sw.Restart();
                    List<List<int>> paths = bfs.searchTransitiveClosure();
                    log("bfs directed search paths with parallel\t" + ((sw.ElapsedMilliseconds + timeFormBFS)).ToString());

                    sw.Restart();
                    bfs.searchTransitiveClosureWithoutParallel();
                    log("bfs directed search paths\t" + ((sw.ElapsedMilliseconds + timeFormBFS)).ToString());
                    if (vertices <= 20) logTransitiveMatrix(Utils.transitiveMatrixFromBFSDir(paths, vertices));
                    log();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
