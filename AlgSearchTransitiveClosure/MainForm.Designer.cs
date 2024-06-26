namespace AlgSearchTransitiveClosure
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartAlg = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.isPrintTansitiveCl = new System.Windows.Forms.CheckBox();
            this.isSaveFile = new System.Windows.Forms.CheckBox();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CreateGraphButton = new System.Windows.Forms.Button();
            this.showCountVers = new System.Windows.Forms.TextBox();
            this.showCountEdges = new System.Windows.Forms.TextBox();
            this.showType = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkShiolach = new System.Windows.Forms.CheckBox();
            this.checkDSU = new System.Windows.Forms.CheckBox();
            this.checkUndirBFS = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkFloyd = new System.Windows.Forms.CheckBox();
            this.checkDirBFS = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartAlg
            // 
            this.StartAlg.Location = new System.Drawing.Point(17, 387);
            this.StartAlg.Name = "StartAlg";
            this.StartAlg.Size = new System.Drawing.Size(226, 54);
            this.StartAlg.TabIndex = 1;
            this.StartAlg.Text = "Запустить выбранные алгоритмы";
            this.StartAlg.UseVisualStyleBackColor = true;
            this.StartAlg.Click += new System.EventHandler(this.StartAlg_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logTextBox.Location = new System.Drawing.Point(271, 8);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(540, 433);
            this.logTextBox.TabIndex = 10;
            // 
            // isPrintTansitiveCl
            // 
            this.isPrintTansitiveCl.AutoSize = true;
            this.isPrintTansitiveCl.Location = new System.Drawing.Point(12, 321);
            this.isPrintTansitiveCl.Name = "isPrintTansitiveCl";
            this.isPrintTansitiveCl.Size = new System.Drawing.Size(252, 17);
            this.isPrintTansitiveCl.TabIndex = 15;
            this.isPrintTansitiveCl.Text = "Вывести транзитивное замыкание на экран";
            this.isPrintTansitiveCl.UseVisualStyleBackColor = true;
            // 
            // isSaveFile
            // 
            this.isSaveFile.AutoSize = true;
            this.isSaveFile.Location = new System.Drawing.Point(12, 344);
            this.isSaveFile.Name = "isSaveFile";
            this.isSaveFile.Size = new System.Drawing.Size(117, 17);
            this.isSaveFile.TabIndex = 16;
            this.isSaveFile.Text = "Сохранить в файл";
            this.isSaveFile.UseVisualStyleBackColor = true;
            this.isSaveFile.CheckedChanged += new System.EventHandler(this.isSaveFile_CheckedChanged);
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.Location = new System.Drawing.Point(31, 364);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(62, 13);
            this.FilenameLabel.TabIndex = 17;
            this.FilenameLabel.Text = "имя файла";
            // 
            // CreateGraphButton
            // 
            this.CreateGraphButton.Location = new System.Drawing.Point(17, 14);
            this.CreateGraphButton.Name = "CreateGraphButton";
            this.CreateGraphButton.Size = new System.Drawing.Size(226, 45);
            this.CreateGraphButton.TabIndex = 18;
            this.CreateGraphButton.Text = "Создать граф";
            this.CreateGraphButton.UseVisualStyleBackColor = true;
            this.CreateGraphButton.Click += new System.EventHandler(this.CreateGraphButton_Click);
            // 
            // showCountVers
            // 
            this.showCountVers.Enabled = false;
            this.showCountVers.Location = new System.Drawing.Point(17, 65);
            this.showCountVers.Name = "showCountVers";
            this.showCountVers.Size = new System.Drawing.Size(226, 20);
            this.showCountVers.TabIndex = 19;
            // 
            // showCountEdges
            // 
            this.showCountEdges.Enabled = false;
            this.showCountEdges.Location = new System.Drawing.Point(17, 91);
            this.showCountEdges.Name = "showCountEdges";
            this.showCountEdges.Size = new System.Drawing.Size(226, 20);
            this.showCountEdges.TabIndex = 20;
            // 
            // showType
            // 
            this.showType.Enabled = false;
            this.showType.Location = new System.Drawing.Point(17, 117);
            this.showType.Name = "showType";
            this.showType.Size = new System.Drawing.Size(226, 20);
            this.showType.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkShiolach);
            this.panel1.Controls.Add(this.checkDSU);
            this.panel1.Controls.Add(this.checkUndirBFS);
            this.panel1.Location = new System.Drawing.Point(20, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 74);
            this.panel1.TabIndex = 22;
            // 
            // checkShiolach
            // 
            this.checkShiolach.AutoSize = true;
            this.checkShiolach.Location = new System.Drawing.Point(3, 49);
            this.checkShiolach.Name = "checkShiolach";
            this.checkShiolach.Size = new System.Drawing.Size(104, 17);
            this.checkShiolach.TabIndex = 2;
            this.checkShiolach.Text = "Shiolach-Vishkin";
            this.checkShiolach.UseVisualStyleBackColor = true;
            // 
            // checkDSU
            // 
            this.checkDSU.AutoSize = true;
            this.checkDSU.Location = new System.Drawing.Point(3, 26);
            this.checkDSU.Name = "checkDSU";
            this.checkDSU.Size = new System.Drawing.Size(49, 17);
            this.checkDSU.TabIndex = 1;
            this.checkDSU.Text = "DSU";
            this.checkDSU.UseVisualStyleBackColor = true;
            // 
            // checkUndirBFS
            // 
            this.checkUndirBFS.AutoSize = true;
            this.checkUndirBFS.Location = new System.Drawing.Point(3, 3);
            this.checkUndirBFS.Name = "checkUndirBFS";
            this.checkUndirBFS.Size = new System.Drawing.Size(46, 17);
            this.checkUndirBFS.TabIndex = 0;
            this.checkUndirBFS.Text = "BFS";
            this.checkUndirBFS.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkFloyd);
            this.panel2.Controls.Add(this.checkDirBFS);
            this.panel2.Location = new System.Drawing.Point(136, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 74);
            this.panel2.TabIndex = 23;
            // 
            // checkFloyd
            // 
            this.checkFloyd.AutoSize = true;
            this.checkFloyd.Location = new System.Drawing.Point(3, 26);
            this.checkFloyd.Name = "checkFloyd";
            this.checkFloyd.Size = new System.Drawing.Size(95, 17);
            this.checkFloyd.TabIndex = 1;
            this.checkFloyd.Text = "Floyd-Warshall";
            this.checkFloyd.UseVisualStyleBackColor = true;
            // 
            // checkDirBFS
            // 
            this.checkDirBFS.AutoSize = true;
            this.checkDirBFS.Location = new System.Drawing.Point(3, 3);
            this.checkDirBFS.Name = "checkDirBFS";
            this.checkDirBFS.Size = new System.Drawing.Size(46, 17);
            this.checkDirBFS.TabIndex = 0;
            this.checkDirBFS.Text = "BFS";
            this.checkDirBFS.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Для неор графов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Для ор графов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showType);
            this.Controls.Add(this.showCountEdges);
            this.Controls.Add(this.showCountVers);
            this.Controls.Add(this.CreateGraphButton);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.isSaveFile);
            this.Controls.Add(this.isPrintTansitiveCl);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.StartAlg);
            this.Name = "MainForm";
            this.Text = "Транзитивное замыкание";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartAlg;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.CheckBox isPrintTansitiveCl;
        private System.Windows.Forms.CheckBox isSaveFile;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button CreateGraphButton;
        private System.Windows.Forms.TextBox showCountVers;
        private System.Windows.Forms.TextBox showCountEdges;
        private System.Windows.Forms.TextBox showType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkShiolach;
        private System.Windows.Forms.CheckBox checkDSU;
        private System.Windows.Forms.CheckBox checkUndirBFS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkFloyd;
        private System.Windows.Forms.CheckBox checkDirBFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

