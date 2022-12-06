namespace Graph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjacencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ColoringMenu = new System.Windows.Forms.ComboBox();
            this.Coloring = new System.Windows.Forms.RadioButton();
            this.DFS = new System.Windows.Forms.RadioButton();
            this.move = new System.Windows.Forms.RadioButton();
            this.remove = new System.Windows.Forms.RadioButton();
            this.AddE = new System.Windows.Forms.RadioButton();
            this.AddV = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.matrixesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1021, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.sToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Загрузить";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // matrixesToolStripMenuItem
            // 
            this.matrixesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjacencyToolStripMenuItem});
            this.matrixesToolStripMenuItem.Name = "matrixesToolStripMenuItem";
            this.matrixesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.matrixesToolStripMenuItem.Text = "Матрицы";
            // 
            // adjacencyToolStripMenuItem
            // 
            this.adjacencyToolStripMenuItem.Name = "adjacencyToolStripMenuItem";
            this.adjacencyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adjacencyToolStripMenuItem.Text = "Смежность";
            this.adjacencyToolStripMenuItem.Click += new System.EventHandler(this.adjacencyToolStripMenuItem_Click);
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Top;
            this.label.Font = new System.Drawing.Font("Arial", 14F);
            this.label.Location = new System.Drawing.Point(0, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(1021, 60);
            this.label.TabIndex = 6;
            this.label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.ColoringMenu);
            this.groupBox1.Controls.Add(this.Coloring);
            this.groupBox1.Controls.Add(this.DFS);
            this.groupBox1.Controls.Add(this.move);
            this.groupBox1.Controls.Add(this.remove);
            this.groupBox1.Controls.Add(this.AddE);
            this.groupBox1.Controls.Add(this.AddV);
            this.groupBox1.Location = new System.Drawing.Point(777, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 454);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // ColoringMenu
            // 
            this.ColoringMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColoringMenu.Items.AddRange(new object[] {
            "Последовательная",
            "НП - нисходящая",
            "ПН - восходящая",
            "Рёберная"});
            this.ColoringMenu.Location = new System.Drawing.Point(7, 311);
            this.ColoringMenu.Name = "ColoringMenu";
            this.ColoringMenu.Size = new System.Drawing.Size(227, 21);
            this.ColoringMenu.TabIndex = 7;
            // 
            // Coloring
            // 
            this.Coloring.Appearance = System.Windows.Forms.Appearance.Button;
            this.Coloring.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Coloring.Location = new System.Drawing.Point(6, 270);
            this.Coloring.Name = "Coloring";
            this.Coloring.Size = new System.Drawing.Size(228, 35);
            this.Coloring.TabIndex = 6;
            this.Coloring.Text = "Раскраска графа";
            this.Coloring.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Coloring.UseVisualStyleBackColor = true;
            this.Coloring.CheckedChanged += new System.EventHandler(this.Coloring_CheckedChanged);
            this.Coloring.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Coloring_MouseClick);
            // 
            // DFS
            // 
            this.DFS.Appearance = System.Windows.Forms.Appearance.Button;
            this.DFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DFS.Location = new System.Drawing.Point(6, 220);
            this.DFS.Name = "DFS";
            this.DFS.Size = new System.Drawing.Size(228, 35);
            this.DFS.TabIndex = 5;
            this.DFS.Text = "Поиск в глубину";
            this.DFS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DFS.UseVisualStyleBackColor = true;
            this.DFS.CheckedChanged += new System.EventHandler(this.DFS_CheckedChanged);
            // 
            // move
            // 
            this.move.Appearance = System.Windows.Forms.Appearance.Button;
            this.move.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.move.Location = new System.Drawing.Point(6, 119);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(228, 35);
            this.move.TabIndex = 4;
            this.move.Text = "Передвинуть вершину";
            this.move.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.move.UseVisualStyleBackColor = true;
            this.move.CheckedChanged += new System.EventHandler(this.move_CheckedChanged);
            // 
            // remove
            // 
            this.remove.Appearance = System.Windows.Forms.Appearance.Button;
            this.remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.remove.Location = new System.Drawing.Point(6, 169);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(228, 35);
            this.remove.TabIndex = 3;
            this.remove.Text = "Убрать элемент";
            this.remove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.remove.UseVisualStyleBackColor = true;
            this.remove.CheckedChanged += new System.EventHandler(this.remove_CheckedChanged);
            // 
            // AddE
            // 
            this.AddE.Appearance = System.Windows.Forms.Appearance.Button;
            this.AddE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.AddE.Location = new System.Drawing.Point(6, 69);
            this.AddE.Name = "AddE";
            this.AddE.Size = new System.Drawing.Size(228, 35);
            this.AddE.TabIndex = 2;
            this.AddE.Text = "Добавить ребро";
            this.AddE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddE.UseVisualStyleBackColor = true;
            this.AddE.CheckedChanged += new System.EventHandler(this.AddE_Click);
            // 
            // AddV
            // 
            this.AddV.Appearance = System.Windows.Forms.Appearance.Button;
            this.AddV.Checked = true;
            this.AddV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.AddV.Location = new System.Drawing.Point(6, 18);
            this.AddV.Name = "AddV";
            this.AddV.Size = new System.Drawing.Size(228, 35);
            this.AddV.TabIndex = 1;
            this.AddV.TabStop = true;
            this.AddV.Text = "Добавить вершину";
            this.AddV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddV.UseVisualStyleBackColor = true;
            this.AddV.CheckedChanged += new System.EventHandler(this.AddV_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 454);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjacencyToolStripMenuItem;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DFS;
        private System.Windows.Forms.RadioButton move;
        private System.Windows.Forms.RadioButton remove;
        private System.Windows.Forms.RadioButton AddE;
        private System.Windows.Forms.RadioButton AddV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RadioButton Coloring;
        private System.Windows.Forms.ComboBox ColoringMenu;
    }
}

