namespace Graph
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjacencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.englishenUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianruRUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.matrixesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.sToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishenUSToolStripMenuItem,
            this.russianruRUToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Language";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
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
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // matrixesToolStripMenuItem
            // 
            this.matrixesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjacencyToolStripMenuItem,
            this.incidenceToolStripMenuItem});
            this.matrixesToolStripMenuItem.Name = "matrixesToolStripMenuItem";
            this.matrixesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.matrixesToolStripMenuItem.Text = "Matrixes";
            // 
            // adjacencyToolStripMenuItem
            // 
            this.adjacencyToolStripMenuItem.Name = "adjacencyToolStripMenuItem";
            this.adjacencyToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.adjacencyToolStripMenuItem.Text = "Adjacency";
            this.adjacencyToolStripMenuItem.Click += new System.EventHandler(this.adjacencyToolStripMenuItem_Click);
            // 
            // incidenceToolStripMenuItem
            // 
            this.incidenceToolStripMenuItem.Name = "incidenceToolStripMenuItem";
            this.incidenceToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.incidenceToolStripMenuItem.Text = "Incidence";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutCreatorToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutCreatorToolStripMenuItem
            // 
            this.aboutCreatorToolStripMenuItem.Name = "aboutCreatorToolStripMenuItem";
            this.aboutCreatorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aboutCreatorToolStripMenuItem.Text = "About creator";
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Arial", 14F);
            this.label.Location = new System.Drawing.Point(12, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(785, 25);
            this.label.TabIndex = 6;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.groupBox1.Location = new System.Drawing.Point(558, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 374);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // ColoringMenu
            // 
            this.ColoringMenu.FormattingEnabled = true;
            this.ColoringMenu.Items.AddRange(new object[] {
            "Greedy",
            "Descending",
            "Ascending",
            "Edge Coloring"});
            this.ColoringMenu.Location = new System.Drawing.Point(6, 301);
            this.ColoringMenu.Name = "ColoringMenu";
            this.ColoringMenu.Size = new System.Drawing.Size(228, 21);
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
            this.Coloring.Text = "Graph Coloring";
            this.Coloring.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Coloring.UseVisualStyleBackColor = true;
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
            this.DFS.Text = "Deep-Field Search";
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
            this.move.Text = "Move";
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
            this.remove.Text = "Remove Element";
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
            this.AddE.Text = "Add Edge";
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
            this.AddV.Text = "Add Vertex";
            this.AddV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddV.UseVisualStyleBackColor = true;
            this.AddV.CheckedChanged += new System.EventHandler(this.AddV_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(9, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 379);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // englishenUSToolStripMenuItem
            // 
            this.englishenUSToolStripMenuItem.Name = "englishenUSToolStripMenuItem";
            this.englishenUSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishenUSToolStripMenuItem.Text = "English(en-US)";
            this.englishenUSToolStripMenuItem.Click += new System.EventHandler(this.englishenUSToolStripMenuItem_Click);
            // 
            // russianruRUToolStripMenuItem
            // 
            this.russianruRUToolStripMenuItem.Name = "russianruRUToolStripMenuItem";
            this.russianruRUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.russianruRUToolStripMenuItem.Text = "Russian(ru-RU)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Graph Tool";
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
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjacencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidenceToolStripMenuItem;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DFS;
        private System.Windows.Forms.RadioButton move;
        private System.Windows.Forms.RadioButton remove;
        private System.Windows.Forms.RadioButton AddE;
        private System.Windows.Forms.RadioButton AddV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.RadioButton Coloring;
        private System.Windows.Forms.ComboBox ColoringMenu;
        private System.Windows.Forms.ToolStripMenuItem englishenUSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianruRUToolStripMenuItem;
    }
}

