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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.countGraph = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.countVer = new System.Windows.Forms.TextBox();
            this.countEdges = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.isPrintTansitiveCl = new System.Windows.Forms.CheckBox();
            this.isSaveFile = new System.Windows.Forms.CheckBox();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Запустить алгоритм для неор графа\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Запустить алгоритм для ор графа";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // countGraph
            // 
            this.countGraph.Location = new System.Drawing.Point(15, 29);
            this.countGraph.Name = "countGraph";
            this.countGraph.Size = new System.Drawing.Size(132, 20);
            this.countGraph.TabIndex = 2;
            this.countGraph.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "введите колличество графаов";
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
            // countVer
            // 
            this.countVer.Location = new System.Drawing.Point(15, 67);
            this.countVer.Name = "countVer";
            this.countVer.Size = new System.Drawing.Size(132, 20);
            this.countVer.TabIndex = 11;
            this.countVer.Text = "10";
            // 
            // countEdges
            // 
            this.countEdges.Location = new System.Drawing.Point(15, 108);
            this.countEdges.Name = "countEdges";
            this.countEdges.Size = new System.Drawing.Size(132, 20);
            this.countEdges.TabIndex = 12;
            this.countEdges.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "введите кол вершин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "введите кол ребер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 65);
            this.label3.TabIndex = 9;
            this.label3.Text = "P.S.\r\n1) все время в миллисекундах\r\n3) если будет какая-то ошибка, то можно\r\nпопр" +
    "обовать нажать на кнопку еще раз, у меня\r\nбыло так";
            // 
            // isPrintTansitiveCl
            // 
            this.isPrintTansitiveCl.AutoSize = true;
            this.isPrintTansitiveCl.Location = new System.Drawing.Point(13, 233);
            this.isPrintTansitiveCl.Name = "isPrintTansitiveCl";
            this.isPrintTansitiveCl.Size = new System.Drawing.Size(252, 17);
            this.isPrintTansitiveCl.TabIndex = 15;
            this.isPrintTansitiveCl.Text = "Вывести транзитивное замыкание на экран";
            this.isPrintTansitiveCl.UseVisualStyleBackColor = true;
            // 
            // isSaveFile
            // 
            this.isSaveFile.AutoSize = true;
            this.isSaveFile.Location = new System.Drawing.Point(13, 256);
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
            this.FilenameLabel.Location = new System.Drawing.Point(32, 276);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(62, 13);
            this.FilenameLabel.TabIndex = 17;
            this.FilenameLabel.Text = "имя файла";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.isSaveFile);
            this.Controls.Add(this.isPrintTansitiveCl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countEdges);
            this.Controls.Add(this.countVer);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.countGraph);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Транзитивное замыкание";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox countGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.TextBox countVer;
        private System.Windows.Forms.TextBox countEdges;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isPrintTansitiveCl;
        private System.Windows.Forms.CheckBox isSaveFile;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

