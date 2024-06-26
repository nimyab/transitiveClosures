using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgSearchTransitiveClosure
{
    public partial class CreateGraphForm : Form
    {
        Graph graph = null;
        public CreateGraphForm(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;
        }

        private void buttonCreateRandomGraph_Click(object sender, EventArgs e)
        {
            try
            {
                int countVers = int.Parse(this.countVer.Text), countEdges = int.Parse(this.countEdges.Text);
                graph.Adj = Utils.createRandomGraph(countVers, countEdges);
                graph.CountVers = countVers;
                graph.CountEdges = countEdges;
                graph.Dir = radioButtonDirGraph.Checked;

                MessageBox.Show("Граф успешно создан");
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("При создании была ошибка\n" + exc.Message);
                Close();
            }
        }

        private void buttonCreateGraphFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog1.FileName;
                    using (StreamReader sr = new StreamReader(@filename))
                    {
                        string[] counts = sr.ReadLine().Split();
                        graph.CountVers = int.Parse(counts[0]);
                        graph.CountEdges = int.Parse(counts[1]);

                        var adj = new List<List<int>>(graph.CountEdges);

                        for (int i = 0; i < graph.CountEdges; i++)
                        {
                            string[] vers = sr.ReadLine().Split();
                            adj.Add(new List<int> { int.Parse(vers[0]), int.Parse(vers[1]) });
                        }

                        graph.Adj = adj;
                        graph.Dir = radioButtonDirGraph.Checked;
                    }
                }
                MessageBox.Show("Граф успешно считан");
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("При чтении была ошибка\n" + exc.Message);
                Close();
            }

        }

    }
}
