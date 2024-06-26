namespace AlgSearchTransitiveClosure
{
    partial class CreateGraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonDirGraph = new System.Windows.Forms.RadioButton();
            this.radioButtonUndirGraph = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonCreateRandomGraph = new System.Windows.Forms.Button();
            this.buttonCreateGraphFromFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.countVer = new System.Windows.Forms.TextBox();
            this.countEdges = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioButtonDirGraph
            // 
            this.radioButtonDirGraph.AutoSize = true;
            this.radioButtonDirGraph.Location = new System.Drawing.Point(15, 50);
            this.radioButtonDirGraph.Name = "radioButtonDirGraph";
            this.radioButtonDirGraph.Size = new System.Drawing.Size(118, 17);
            this.radioButtonDirGraph.TabIndex = 0;
            this.radioButtonDirGraph.TabStop = true;
            this.radioButtonDirGraph.Text = "Ориентированный";
            this.radioButtonDirGraph.UseVisualStyleBackColor = true;
            // 
            // radioButtonUndirGraph
            // 
            this.radioButtonUndirGraph.AutoSize = true;
            this.radioButtonUndirGraph.Location = new System.Drawing.Point(15, 27);
            this.radioButtonUndirGraph.Name = "radioButtonUndirGraph";
            this.radioButtonUndirGraph.Size = new System.Drawing.Size(130, 17);
            this.radioButtonUndirGraph.TabIndex = 1;
            this.radioButtonUndirGraph.TabStop = true;
            this.radioButtonUndirGraph.Text = "Неориентированный";
            this.radioButtonUndirGraph.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип графа";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonCreateRandomGraph
            // 
            this.buttonCreateRandomGraph.Location = new System.Drawing.Point(12, 168);
            this.buttonCreateRandomGraph.Name = "buttonCreateRandomGraph";
            this.buttonCreateRandomGraph.Size = new System.Drawing.Size(208, 36);
            this.buttonCreateRandomGraph.TabIndex = 3;
            this.buttonCreateRandomGraph.Text = "Создать случайный граф";
            this.buttonCreateRandomGraph.UseVisualStyleBackColor = true;
            this.buttonCreateRandomGraph.Click += new System.EventHandler(this.buttonCreateRandomGraph_Click);
            // 
            // buttonCreateGraphFromFile
            // 
            this.buttonCreateGraphFromFile.Location = new System.Drawing.Point(12, 251);
            this.buttonCreateGraphFromFile.Name = "buttonCreateGraphFromFile";
            this.buttonCreateGraphFromFile.Size = new System.Drawing.Size(208, 36);
            this.buttonCreateGraphFromFile.TabIndex = 4;
            this.buttonCreateGraphFromFile.Text = "Задать граф из файла";
            this.buttonCreateGraphFromFile.UseVisualStyleBackColor = true;
            this.buttonCreateGraphFromFile.Click += new System.EventHandler(this.buttonCreateGraphFromFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "количество ребер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "количество вершин";
            // 
            // countVer
            // 
            this.countVer.Location = new System.Drawing.Point(12, 101);
            this.countVer.Name = "countVer";
            this.countVer.Size = new System.Drawing.Size(208, 20);
            this.countVer.TabIndex = 17;
            this.countVer.Text = "10";
            // 
            // countEdges
            // 
            this.countEdges.Location = new System.Drawing.Point(12, 142);
            this.countEdges.Name = "countEdges";
            this.countEdges.Size = new System.Drawing.Size(208, 20);
            this.countEdges.TabIndex = 18;
            this.countEdges.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(95, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "ИЛИ";
            // 
            // CreateGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 299);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countEdges);
            this.Controls.Add(this.countVer);
            this.Controls.Add(this.buttonCreateGraphFromFile);
            this.Controls.Add(this.buttonCreateRandomGraph);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonUndirGraph);
            this.Controls.Add(this.radioButtonDirGraph);
            this.Name = "CreateGraphForm";
            this.Text = "Создание графа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonDirGraph;
        private System.Windows.Forms.RadioButton radioButtonUndirGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonCreateRandomGraph;
        private System.Windows.Forms.Button buttonCreateGraphFromFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox countVer;
        private System.Windows.Forms.TextBox countEdges;
        private System.Windows.Forms.Label label2;
    }
}