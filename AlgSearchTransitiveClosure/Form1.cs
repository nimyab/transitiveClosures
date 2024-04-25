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
    public partial class MainForm : Form
    {
        Stopwatch sw = new Stopwatch();
        string saveFilePath;

        public MainForm()
        {
            InitializeComponent();

            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
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

                    long avgTimeForDSU = 0;
                    int[] parents = Utils.avaregeForDSU(graph, vertices, ref avgTimeForDSU);

                    log("Dsu search Components Without Parallel\t" + avgTimeForDSU.ToString());

                    if (isPrintTansitiveCl.Checked) logTransitiveMatrix(Utils.transitiveMatrixFromDSU(parents, vertices));

                    //проверка bfs

                    //bfsUndir bfs = new bfsUndir(vertices);
                    //for (int i = 0; i < graph.Count; i++)
                    //{
                    //    bfs.AddEdge(graph[i][0], graph[i][1]);
                    //}
                    //sw.Restart();
                    //List<List<int>> components = bfs.bfs();
                    //log("bfs undirected search components\t" + ((sw.ElapsedMilliseconds)).ToString());

                    long avgTimeForBFS = 0;
                    List<List<int>> components = Utils.avaregeForBFSUndir(graph, vertices, ref avgTimeForBFS);
                    log("bfs undirected search components\t" + avgTimeForBFS.ToString());
                    if (isPrintTansitiveCl.Checked) logTransitiveMatrix(Utils.transitiveMatrixFromBFSUndir(components, vertices));

                    //проверка Шиолаха-Вишкина

                    long avgTimeForShiolah = 0;
                    int[] answerWithoutParallel = Utils.avaregeForShiolah(graph, vertices, ref avgTimeForShiolah);
                    log("shiolah search components without parallel\t" + avgTimeForShiolah.ToString());

                    long avgTimeForShiolahParallel = 0;
                    int[] answerWithParallel = Utils.avaregeForShiolahParallel(graph, vertices, ref avgTimeForShiolahParallel);
                    log("shiolah search components with parallel\t" + avgTimeForShiolahParallel.ToString());

                    if (isPrintTansitiveCl.Checked) logTransitiveMatrix(Utils.transitiveMatrixFromDSU(answerWithoutParallel, vertices));

                    //вывод в файл
                    if (isSaveFile.Checked)
                    {
                        log("start write to file: " + FilenameLabel.Text);
                        Utils.logBRToFile(saveFilePath);
                        Utils.logGraphToFile(saveFilePath, graph);
                        Utils.logTransitiveMatrixFromDSUToFile(saveFilePath, parents, vertices);
                        Utils.logTransitiveMatrixFromBFSUndirToFile(saveFilePath, components, vertices);
                        Utils.logTransitiveMatrixFromDSUToFile(saveFilePath, answerWithoutParallel, vertices);
                        Utils.logBRToFile(saveFilePath);
                        log("stop wrtite to file");
                    }

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

                    //проверка скорости Флойда

                    sw.Restart();
                    List<int>[] dist = Floyd.Alg(graph, vertices);
                    log("Floyd search paths\t" + ((sw.ElapsedMilliseconds)).ToString());
                    if (isPrintTansitiveCl.Checked) logTransitiveMatrix(Utils.transitiveMatrixFromFloyd(dist, vertices));

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
                    if (isPrintTansitiveCl.Checked) logTransitiveMatrix(Utils.transitiveMatrixFromBFSDir(paths, vertices));



                    //вывод в файл
                    if (isSaveFile.Checked)
                    {
                        log("start write to file: " + FilenameLabel.Text);
                        Utils.logBRToFile(saveFilePath);
                        Utils.logGraphToFile(saveFilePath, graph);
                        Utils.logTransitiveMatrixFromFloydToFile(saveFilePath, dist, vertices);
                        Utils.logTransitiveMatrixFromBFSDirToFile(saveFilePath, paths, vertices);
                        //еще одна для Пурдома будет
                        Utils.logBRToFile(saveFilePath);
                        log("stop wrtite to file");
                    }

                    log();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void isPrintTansitiveCl_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isSaveFile_CheckedChanged(object sender, EventArgs e)
        {
            if (!isSaveFile.Checked)
            {
                saveFilePath = "";
                FilenameLabel.Text = "";
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveFilePath = saveFileDialog.FileName;
                FilenameLabel.Text = saveFileDialog.FileName.Split('\\').Last();
            }
        }
    }
}
