using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        Graph graph = new Graph();
        string saveFilePath;

        public MainForm()
        {
            InitializeComponent();

            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            UpdateGraphData();
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

        private void StartAlg_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";



            if (graph.Dir) this.StartAlgForDirGraph();
            else this.StartAlgForUndirGraph();
        }

        private void StartAlgForUndirGraph()
        {
            try
            {
                int edges = this.graph.CountEdges;
                int vertices = this.graph.CountVers;
                List<List<int>> graph = this.graph.Adj;
                log("start");

                if (isSaveFile.Checked) Utils.logGraphToFile(saveFilePath, graph);

                //проверка скорости DSU вместе с формированием
                if (checkDSU.Checked)
                {
                    long avgTimeForDSU = 0;
                    int[] parents = Utils.avaregeForDSU(graph, vertices, ref avgTimeForDSU);

                    log("Dsu search Components Without Parallel\t" + avgTimeForDSU.ToString() + " ms");

                    if(isPrintTansitiveCl.Checked || isSaveFile.Checked)
                    {
                        int[,] matrix = Utils.transitiveMatrixFromDSU(parents, vertices);
                        if (isPrintTansitiveCl.Checked) logTransitiveMatrix(matrix);
                        if (isSaveFile.Checked) Utils.printDataToFile(saveFilePath, matrix);
                    }
                }
                //проверка bfs
                if (checkUndirBFS.Checked)
                {
                    long avgTimeForBFS = 0;
                    List<List<int>> components = Utils.avaregeForBFSUndir(graph, vertices, ref avgTimeForBFS);

                    log("bfs undirected search components\t" + avgTimeForBFS.ToString() + " ms");

                    if (isPrintTansitiveCl.Checked || isSaveFile.Checked)
                    {
                        int[,] matrix = Utils.transitiveMatrixFromBFSUndir(components, vertices);
                        if (isPrintTansitiveCl.Checked) logTransitiveMatrix(matrix);
                        if (isSaveFile.Checked) Utils.printDataToFile(saveFilePath, matrix);
                    }
                }
                //проверка Шиолаха-Вишкина
                if (checkShiolach.Checked)
                {
                    long avgTimeForShiolah = 0;
                    int[] answerWithoutParallel = Utils.avaregeForShiolah(graph, vertices, ref avgTimeForShiolah);
                    log("shiolah search components without parallel\t" + avgTimeForShiolah.ToString() + " ms");

                    long avgTimeForShiolahParallel = 0;
                    int[] answerWithParallel = Utils.avaregeForShiolahParallel(graph, vertices, ref avgTimeForShiolahParallel);
                    log("shiolah search components with parallel\t" + avgTimeForShiolahParallel.ToString() + " ms");

                    if (isPrintTansitiveCl.Checked || isSaveFile.Checked)
                    {
                        int[,] matrix = Utils.transitiveMatrixFromDSU(answerWithParallel, vertices);
                        if (isPrintTansitiveCl.Checked) logTransitiveMatrix(matrix);
                        if (isSaveFile.Checked) Utils.printDataToFile(saveFilePath, matrix);
                    }
                }

                log("stop");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void StartAlgForDirGraph()
        {
            try
            {
                int edges = this.graph.CountEdges;
                int vertices = this.graph.CountVers;
                List<List<int>> graph = this.graph.Adj;
                log("start");

                if (isSaveFile.Checked) Utils.logGraphToFile(saveFilePath, graph);

                //проверка скорости Флойда
                if (checkFloyd.Checked)
                {
                    long avgTimeForFloyd = 0;
                    List<int>[] dist = Utils.avaregeForFloyd(graph, vertices, ref avgTimeForFloyd);

                    log("Floyd search paths\t" + (avgTimeForFloyd).ToString() + " ms");

                    if (isPrintTansitiveCl.Checked || isSaveFile.Checked)
                    {
                        int[,] matrix = Utils.transitiveMatrixFromFloyd(dist, vertices);
                        if (isPrintTansitiveCl.Checked) logTransitiveMatrix(matrix);
                        if (isSaveFile.Checked) Utils.printDataToFile(saveFilePath, matrix);
                    }
                }

                //проверка bfs
                if (checkDirBFS.Checked)
                {
                    BFSDir bfs = new BFSDir(vertices);
                    for (int i = 0; i < graph.Count; i++)
                    {
                        bfs.AddEdge(graph[i][0], graph[i][1]);
                    }

                    long avgTimeForBFSParallel = 0;
                    Utils.avaregeForBFSDirParallel(bfs, ref avgTimeForBFSParallel);
                    log("bfs directed search paths with parallel\t" + (avgTimeForBFSParallel).ToString() + " ms");

                    long avgTimeForBFS = 0;
                    List<List<int>> paths = Utils.avaregeForBFSDir(bfs, ref avgTimeForBFS);
                    log("bfs directed search paths\t" + (avgTimeForBFS).ToString() + " ms");
                    

                    if (isPrintTansitiveCl.Checked || isSaveFile.Checked)
                    {
                        int[,] matrix = Utils.transitiveMatrixFromBFSDir(paths, vertices);
                        if (isPrintTansitiveCl.Checked) logTransitiveMatrix(matrix);
                        if (isSaveFile.Checked) Utils.printDataToFile(saveFilePath, matrix);
                    }
                }

                log("stop");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
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

        private void CreateGraphButton_Click(object sender, EventArgs e)
        {
            CreateGraphForm createGraphForm = new CreateGraphForm(graph);
            createGraphForm.ShowDialog();
            UpdateGraphData();
        }

        public void UpdateGraphData()
        {
            if (graph.CountVers == -1)
            {
                this.showCountEdges.Text = "Нет данных, нужно задать граф";
                this.showCountVers.Text = "Нет данных, нужно задать граф";
                this.showType.Text = "Нет данных, нужно задать граф";
                panel1.Enabled = false;
                panel2.Enabled = false;
            }
            else
            {
                this.showCountEdges.Text = "Ребер: " + graph.CountEdges.ToString();
                this.showCountVers.Text = "Вершин: " + graph.CountVers.ToString();
                this.showType.Text = graph.Dir ? "Ориентированный" : "Неориентированный";
                if (graph.Dir)
                {
                    panel1.Enabled = false;
                    panel2.Enabled = true;
                }
                else
                {
                    panel1.Enabled = true;
                    panel2.Enabled = false;
                }
            }
        }
    }
}
